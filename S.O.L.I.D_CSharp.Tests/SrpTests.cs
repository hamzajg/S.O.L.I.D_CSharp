using System;
using System.IO;
using S.O.L.I.D_CSharp.SRP;
using Xunit;

namespace S.O.L.I.D_CSharp.Tests
{
    /// <summary>
    /// SRP: <see cref="Journal"/> owns the entries, <see cref="Persistence"/>
    /// owns the file. Neither has to know how the other does its job.
    /// </summary>
    public class SrpTests
    {
        [Fact]
        public void AddEntryReturnsTheNextEntryNumber()
        {
            var journal = new Journal();

            var first = journal.AddEntry("I cried today");
            var second = journal.AddEntry("I ate a bug");

            Assert.Equal(first + 1, second);
        }

        [Fact]
        public void ToStringListsTheEntriesInOrder()
        {
            var journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");

            var lines = journal.ToString().Split(Environment.NewLine);

            Assert.Equal(2, lines.Length);
            Assert.EndsWith(": I cried today", lines[0]);
            Assert.EndsWith(": I ate a bug", lines[1]);
        }

        [Fact]
        public void RemoveEntryDropsTheEntry()
        {
            var journal = new Journal();
            journal.AddEntry("kept");
            journal.AddEntry("removed");

            journal.RemoveEntry(1);

            Assert.Contains("kept", journal.ToString());
            Assert.DoesNotContain("removed", journal.ToString());
        }

        [Fact]
        public void RemoveEntryRejectsAnIndexThatDoesNotExist()
        {
            var journal = new Journal();

            Assert.Throws<ArgumentOutOfRangeException>(() => journal.RemoveEntry(3));
        }

        [Fact]
        public void SaveWritesTheJournalToDisk()
        {
            var path = TempFile();
            try
            {
                var journal = new Journal();
                journal.AddEntry("saved entry");

                new Persistence().SaveToFIle(journal, path, overwrite: true);

                Assert.True(File.Exists(path));
                Assert.Contains("saved entry", File.ReadAllText(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void SaveKeepsAnExistingFileUnlessOverwriteIsAsked()
        {
            var path = TempFile();
            try
            {
                File.WriteAllText(path, "original");
                var journal = new Journal();
                journal.AddEntry("new entry");

                new Persistence().SaveToFIle(journal, path);

                Assert.Equal("original", File.ReadAllText(path));
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void LoadReadsBackWhatSaveWrote()
        {
            var path = TempFile();
            try
            {
                var journal = new Journal();
                journal.AddEntry("first");
                journal.AddEntry("second");
                new Persistence().SaveToFIle(journal, path, overwrite: true);

                var loaded = Persistence.Load(path);
                var lines = loaded.ToString().Split(Environment.NewLine);

                Assert.Equal(2, lines.Length);
                // The prefix is re-assigned on load, not copied into the text.
                Assert.Matches(@"^\d+: first$", lines[0]);
                Assert.Matches(@"^\d+: second$", lines[1]);
            }
            finally
            {
                File.Delete(path);
            }
        }

        [Fact]
        public void LoadRejectsAMissingFile()
        {
            Assert.Throws<FileNotFoundException>(() => Persistence.Load(TempFile()));
        }

        private static string TempFile()
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }
    }
}
