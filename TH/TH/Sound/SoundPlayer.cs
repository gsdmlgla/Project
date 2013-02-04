using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.DirectX.DirectSound;


namespace TH
{
    /// <summary>
    /// SoundPlayer can play sound.
    /// </summary>
    class SoundPlayer
    {
        private static Device device;
        private static IntPtr gameWindowHandle;
        private static Dictionary<int, SecondaryBuffer> loops = new Dictionary<int, SecondaryBuffer>();
        private static int loopID = 0;
        /// <summary>
        /// Private Constructor to prevent accidental inheritance.
        /// </summary>
        /// <param name="gameWindowHandle"></param>
        private SoundPlayer()
        {
            //
        }

        /// <summary>
        /// Initializes the SoundPlayer.
        /// Uses the default Sound device installed in the machine.
        /// Should be able to change the device in settings.
        /// </summary>
        /// <param name="gameWindowHandle"></param>
        public static void Init(IntPtr gameWindowHandle)
        {
            SoundPlayer.gameWindowHandle = gameWindowHandle;
            DevicesCollection devices = new DevicesCollection();
            List<DeviceInformation> deviceInfos = new List<DeviceInformation>();
            foreach (DeviceInformation d in devices)
            {
                deviceInfos.Add(d);
            }
            device = new Device(deviceInfos[1].DriverGuid);
            device.SetCooperativeLevel(SoundPlayer.gameWindowHandle, CooperativeLevel.Normal);
        }
        /// <summary>
        /// Plays sound. 
        /// </summary>
        /// <param name="e">Sound to play</param>
        public static void play(Sound e)
        {
            MemoryStream ms = e.getStream();
            SecondaryBuffer buffer = new SecondaryBuffer(ms, device);
            buffer.Play(0, BufferPlayFlags.Default);
        }
        /// <summary>
        /// Stops a loop matching loopID.
        /// </summary>
        /// <param name="loopID">loopID</param>
        public static void stopLoop(int loopID)
        {
            if (loops.ContainsKey(loopID))
            {
                SecondaryBuffer value;
                if (loops.TryGetValue(loopID, out value))
                {
                    value.Stop();
                    loops.Remove(loopID);
                }
            }
        }
        /// <summary>
        /// plays a sound in loop.
        /// </summary>
        /// <param name="e">Sound to play in loop</param>
        /// <returns>loopID assigned to the loop.</returns>
        public static int playInLoop(Sound e)
        {
            MemoryStream ms = e.getStream();
            //Can cause out of memory exception.
            SecondaryBuffer buffer = new SecondaryBuffer(ms, device);
            buffer.Play(0, BufferPlayFlags.Looping);

            loops.Add(loopID, buffer);
            return loopID++;
        }
    }
}
