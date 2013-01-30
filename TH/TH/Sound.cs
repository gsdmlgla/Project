using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TH
{
    class Sound
    {
        private byte[] information;
        public Sound()
        {
            //
        }
        public MemoryStream getStream()
        {
            return new MemoryStream(information);
        }
        public Sound(string path)
        {
            load(path);
        }

        public bool load(FileStream fs)
        {
            try
            {
                if (fs.Length > int.MaxValue)
                {
                    Console.Out.WriteLine("Too Long");
                    return false;
                }
                fs.Read(information, 0, (int)fs.Length);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
        public bool load(String path)
        {
            try
            {
                information = File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.StackTrace);
                return false;
            }
            return true;
        }
    }
}
