using MapMyNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeroconf;

namespace MapMyNet.Services
{
    public static class mDNSService
    {
        public static List<ZeroConfigDomain> Domains = new List<ZeroConfigDomain>();
        public static IReadOnlyList<IZeroconfHost> Hosts;
        public static async void Start()
        {
            var zeroConfDomains = await ZeroconfResolver.BrowseDomainsAsync();
            foreach(var serviceType in zeroConfDomains)
            {
                foreach(var domain in serviceType)
                {
                    var parts = domain.Split(':');
                    Domains.Add(new ZeroConfigDomain()
                    {
                        Service = serviceType.Key,
                        DomainName = parts[1],
                        IPAddress = parts[0],
                    });
                }
                
            }
            Hosts = await ZeroconfResolver.ResolveAsync(zeroConfDomains.Select(g => g.Key));
        }
    }
}
