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
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }

        /// <summary>
        /// Reads a journal saved by <see cref="SaveToFIle"/>.
        /// </summary>
        /// <remarks>
        /// Only the entry text is kept: the "n: " prefix is this process's
        /// numbering and is reassigned by <see cref="Journal.AddEntry"/>, so
        /// loading must not copy it into the text of the entry.
        /// </remarks>
        public static Journal Load(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (!File.Exists(filename))
                throw new FileNotFoundException("no journal to load", filename);

            var journal = new Journal();
            foreach (var line in File.ReadAllLines(filename))
            {
                if (line.Length == 0)
                    continue;

                var separator = line.IndexOf(": ", StringComparison.Ordinal);
                var text = separator >= 0 ? line.Substring(separator + 2) : line;
                journal.AddEntry(text);
            }
            return journal;
        }

        public void Load(Uri uri)
        {

        }
    }
}
