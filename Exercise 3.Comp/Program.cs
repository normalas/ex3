using System;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using Humanizer.Bytes;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full path to the file to compress: ");
            string input = Console.ReadLine();
            string fileToCompress = @""+ input;
            long inFileSizeInBytes;

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            using (var inFile = File.OpenRead(fileToCompress))
            {
                inFileSizeInBytes = inFile.Length;

                using (var outFile = File.Create(fileToCompress + ".gz"))
                {

                    using (var compressor = new GZipStream(outFile, CompressionMode.Compress))
                    {
                        inFile.CopyTo(compressor);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Compressed a file of size {(new ByteSize(inFileSizeInBytes)).Megabytes:N} (MB) in {stopwatch.ElapsedMilliseconds / 1000} seconds.");
        }
    }
}
