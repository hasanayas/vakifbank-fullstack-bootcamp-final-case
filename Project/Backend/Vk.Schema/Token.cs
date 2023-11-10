using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Schema;

public class TokenRequest
{
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
}

public class TokenResponse
{
    public string Token { get; set; }
}