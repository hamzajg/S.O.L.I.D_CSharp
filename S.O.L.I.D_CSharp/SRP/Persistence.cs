using System;
using System.IO;

namespace S.O.L.I.D_CSharp.SRP
{
    public class Persistence
    {
        public Persistence()
        {
        }

        public void SaveToFIle(Journal j, string filename, bool overwrite = false)
        {
            if(overwrite && !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }

        public static Journal Load(string filename)
        {
            return null;
        }
        public void Load(Uri uri)
        {

        }
    }
}
