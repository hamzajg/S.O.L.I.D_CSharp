using System;
namespace S.O.L.I.D_CSharp.DIP
{

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }
    public class Person
    {
        public string Name;
        //public DateTime DateOfBirth;
        public Person()
        {
        }
    }
}
