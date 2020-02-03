using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Security.Cryptography;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the full path to the file to compress: ");
            string input = Console.ReadLine();
            string fileToCompress = @""+ input;
            long inFileSizeInBytes;


            var rijndaelEncryptionAlgorithm = new RijndaelManaged();
            rijndaelEncryptionAlgorithm.GenerateKey();
            rijndaelEncryptionAlgorithm.GenerateIV();

            Console.WriteLine(fileToCompress);
        }
    }
}
