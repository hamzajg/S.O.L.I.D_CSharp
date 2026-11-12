using System.Collections.Generic;
using System.Linq;
using S.O.L.I.D_CSharp.DIP;
using Xunit;

namespace S.O.L.I.D_CSharp.Tests
{
    /// <summary>
    /// DIP: <see cref="Research"/> depends on
    /// <see cref="IRelationshipBrowser"/>, not on
    /// <see cref="Relationships"/>, so any store that can answer the question
    /// works — including a fake that never touches the low-level list.
    /// </summary>
    public class DipTests
    {
        [Fact]
        public void RelationshipsFindsTheChildrenOfANamedParent()
        {
            var john = new Person { Name = "John" };
            var chris = new Person { Name = "Chris" };
            var mary = new Person { Name = "Mary" };
            var relationships = new Relationships();
            relationships.AddParentAndChild(john, chris);
            relationships.AddParentAndChild(john, mary);

            var children = relationships.FindAllChildrenOf("John").Select(p => p.Name);

            Assert.Equal(new[] { "Chris", "Mary" }, children);
        }

        [Fact]
        public void RelationshipsReturnsNothingForAnUnknownParent()
        {
            var relationships = new Relationships();
            relationships.AddParentAndChild(new Person { Name = "John" }, new Person { Name = "Chris" });

            Assert.Empty(relationships.FindAllChildrenOf("Nobody"));
        }

        [Fact]
        public void ResearchAsksTheBrowserForTheChildren()
        {
            var browser = new FakeBrowser("Chris", "Mary");

            _ = new Research(browser);

            Assert.Equal(1, browser.Calls);
            Assert.Equal("John", browser.AskedAbout);
        }

        [Fact]
        public void ResearchWorksWithAnyBrowser()
        {
            // An empty implementation is enough: the high-level module has no
            // other requirement than the interface.
            var browser = new FakeBrowser();

            var research = new Research(browser);

            Assert.NotNull(research);
            Assert.Equal(1, browser.Calls);
        }

        private sealed class FakeBrowser : IRelationshipBrowser
        {
            private readonly IEnumerable<Person> children;

            public FakeBrowser(params string[] names)
            {
                children = names.Select(name => new Person { Name = name }).ToList();
            }

            public int Calls { get; private set; }

            public string AskedAbout { get; private set; }

            public IEnumerable<Person> FindAllChildrenOf(string name)
            {
                Calls++;
                AskedAbout = name;
                return children;
            }
        }
    }
}
