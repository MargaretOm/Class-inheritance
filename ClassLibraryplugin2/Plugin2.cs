using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ClassLibraryplugin2
{
    public class Plugin2 : Class1
    {
        public string Name { get; } = "Zip";

        public string Format { get; } = ".zip";

        public string inputFile;

        public Plugin2() { }

        public void Compress(string inputFile, string outputFile)
        {
            using (FileStream input = File.OpenRead(inputFile))
            using (FileStream output = File.Create(outputFile))
            using (ZipArchive zip = new ZipArchive(output, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = zip.CreateEntry(Path.GetFileName(inputFile));
                using (Stream stream = entry.Open())
                {
                    input.CopyTo(stream);
                }
            }
        }

        public void Decompress(string inputFile, string outputFile)
        {
            ZipFile.ExtractToDirectory(inputFile, Path.GetDirectoryName(outputFile));
        }
    }
}
