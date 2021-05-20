using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinelecBE
{
    public class LocalDb
    {
        Dictionary<string, Tunnel> tunnels = new Dictionary<string, Tunnel>();

        public void SetTunnel (string name, int length, bool isfree)
        {
            if (tunnels.ContainsKey(name))
            {
                tunnels[name].Length = length;
                tunnels[name].IsFree = isfree;
            }
            else
                tunnels.Add(name, new Tunnel() {Name = name, Length = length, IsFree = isfree });
        }

        public List<Tunnel> GeTtunnels(string name)
        {
            List<Tunnel> tunnelList = new List<Tunnel>();
            if (!string.IsNullOrWhiteSpace(name))
                tunnelList.Add(tunnels[name]);
            else
                foreach (string tunnelName in tunnels.Keys)
                    tunnelList.Add(tunnels[tunnelName]);
            return tunnelList;
        }
    }
}
