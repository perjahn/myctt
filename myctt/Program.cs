using Microsoft.Web.XmlTransform;
using System;

namespace myctt
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: myctt <sourcefile> <transformfile> <outfile>");
                return 1;
            }

            string sourcefile = args[0];
            string transformfile = args[1];
            string destinationfile = args[2];

            if (Transform(sourcefile, transformfile, destinationfile))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private static bool Transform(string sourcefile, string transformfile, string destinationfile)
        {
            var logger = new MyLogger();

            using (var xdoc = new XmlTransformableDocument())
            {
                xdoc.PreserveWhitespace = true;
                xdoc.Load(sourcefile);

                using (var xmlTransform = new XmlTransformation(transformfile, logger))
                {
                    if (!xmlTransform.Apply(xdoc))
                    {
                        return false;
                    }
                    xdoc.Save(destinationfile);
                }
            }

            return true;
        }
    }
}
