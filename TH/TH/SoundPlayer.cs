using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.DirectX.DirectSound;


namespace TH
{
    class SoundPlayer
    {
        private static Device device;
        private static IntPtr gameWindowHandle;
        private static Dictionary<int, SecondaryBuffer> loops = new Dictionary<int, SecondaryBuffer>();
        private static int loopID = 0;

        private SoundPlayer(IntPtr gameWindowHandle)
        {
            //
        }
        public static void Init(IntPtr gameWindowHandle)
        {
            DevicesCollection devices = new DevicesCollection();
            List<DeviceInformation> deviceInfos = new List<DeviceInformation>();
            foreach (DeviceInformation d in devices)
            {
                deviceInfos.Add(d);
            }
            device = new Device(deviceInfos[1].DriverGuid);
            device.SetCooperativeLevel(gameWindowHandle, CooperativeLevel.Normal);
        }
        public static void play(Sound e)
        {
            MemoryStream ms = e.getStream();
            SecondaryBuffer buffer = new SecondaryBuffer(ms, device);
            buffer.Play(0, BufferPlayFlags.Default);
        }
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
        public static int playInLoop(Sound e)
        {
            MemoryStream ms = e.getStream();
            SecondaryBuffer buffer = new SecondaryBuffer(ms, device);
            buffer.Play(0, BufferPlayFlags.Looping);

            loops.Add(loopID, buffer);
            return loopID++;
        }
    }
}
