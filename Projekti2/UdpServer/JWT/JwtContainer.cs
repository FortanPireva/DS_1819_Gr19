using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace UdpServer.JWT
{
    class JwtContainer:JwtAuthContainerModel
    {
        public int ExpireMinutes { get; set; } = 10080;
        public string SecretKey { get; set; } = "asdfasdfadsfadsfasdf";//mirret prej celsit privat te serverit
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }
        public Claim[] claims { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
