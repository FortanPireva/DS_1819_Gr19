using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer.JWT
{
    interface IAuthService
    {
        string SecretKey { get; set; }
        bool isTokenValid(string token);
        string GenerateToken(JwtAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims { get; set; }
    }
}
