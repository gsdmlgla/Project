using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    abstract class CommandStream
    {
        protected List<Controller> connectedPlayers;

        /// <summary>
        /// Players who wish to receive information from this stream must connect first. 
        /// </summary>
        /// <param name="toBeConnected"></param>
        public void connect(Controller toBeConnected)
        {
            connectedPlayers.Add(toBeConnected);
        }
        public void disconnect(Controller toBeDisConnected)
        {
            while (connectedPlayers.Remove(toBeDisConnected)) { }
        }
    }
}
