using System;
using System.Security.Cryptography.X509Certificates;

namespace X509Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // The path to the certificate.
            string Certificate = "ucoole.nokeys.cer";
            //string Certificate = "ucoole.withkey.cer";
            //string Certificate = "ucoole.withkey.withpwd.cer";

            // Load the certificate into an X509Certificate object.
            X509Certificate cert = new X509Certificate(Certificate);

            // Get the value.
            string resultsTrue = cert.ToString(true);

            // Display the value to the console.
            Console.WriteLine(resultsTrue);

            // Get the value.
            string resultsFalse = cert.ToString(false);

            // Display the value to the console.
            Console.WriteLine(resultsFalse);
        }
    }
}