using Humanizer.Bytes;
using System;
using System.Diagnostics;
using System.IO.Compression;
using static System.IO.File;

namespace Exercise_3.DeComp
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

                using (var outFile = Create(FileToDecompress))
                {
                    using (var compressor = new GZipStream(outFile, CompressionMode.Decompress))
                    {
                        inFile.CopyTo(compressor);
                    }
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Decompressed a file of size {(new ByteSize(inFileSizeInBytes)).Megabytes:N} (MB) in {stopwatch.ElapsedMilliseconds/1000} seconds.");
        }
    }
}
