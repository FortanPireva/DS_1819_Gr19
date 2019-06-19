using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer.JWT
{
    interface JwtAuthContainerModel
    {
        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }
        Claim[] claims { get; set; }

    }
}
