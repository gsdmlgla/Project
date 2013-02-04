using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TH
{
    /// <summary>
    /// This class represents a Sound from a file.
    /// This can be played through SoundPlayer.
    /// </summary>
    class Sound
    {
        /// <summary>
        /// Sound information transformed into bytes. 
        /// </summary>
        private byte[] information;
        /// <summary>
        /// Default constructor. 
        /// You must load file manually after.
        /// </summary>
        public Sound()
        {
            //
        }
        /// <summary>
        /// Constructor that takes a path to a .wav file. 
        /// It loads the file. 
        /// </summary>
        /// <param name="path"></param>
        public Sound(string path)
        {
            load(path);
        }
        /// <summary>
        /// Returns a memorystream to loaded file. 
        /// Every returned stream is unique.
        /// </summary>
        /// <returns>Stream to the memory. </returns>
        public MemoryStream getStream()
        {
            return new MemoryStream(information);
        }
        /// <summary>
        /// Loads a file from a file path. 
        /// return false upon failure. 
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>True upon success.</returns>
        public bool load(String path)
        {
            try
            {
                if (!path.EndsWith(".wav"))
                {
                    return false;
                }
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
