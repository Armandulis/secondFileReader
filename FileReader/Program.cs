using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileReader
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Methods methods = new Methods();
            methods.ReadJson();
        }


    }
}
