﻿using System;
using System.Collections.Generic;

namespace S.O.L.I.D_CSharp.SRP
{
    public class Journal
    {

        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {

            entries.Add($"{++count}: {text}");
            return count; // memenyo
        } 
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
        public Journal()
        {
        }
    }
}
