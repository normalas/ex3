using Humanizer.Bytes;
using System;
using System.Diagnostics;
using System.IO.Compression;
using static System.IO.File;

namespace Exercise3.DeComp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to the file you wish to decompress: ");
            string Input = Console.ReadLine();
            var FileToDecompress = @"" + Input;
            long inFileSizeInBytes;

            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            using (var inFile = OpenRead(FileToDecompress))
            {
                inFileSizeInBytes = inFile.Length;

                // This was the easiest (?) way I could figure out (or, you know, more-or-less directly copy from the sample)
                // to do the decompression.
                using (var outFile = Create(FileToDecompress.Remove((FileToDecompress.Length-8)) +"_new.txt"))
                {
                    using (var compressor = new GZipStream(outFile, CompressionMode.Decompress))
                    {
                    }
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Decompressed a file of size {(new ByteSize(inFileSizeInBytes)).Megabytes:N} (MB) in {stopwatch.ElapsedMilliseconds/1000} seconds.");
        }
    }
}
