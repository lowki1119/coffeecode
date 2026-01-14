using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SecretService;

public class VaultResponse
{
    [JsonPropertyName("auth")]
    public AuthInfo Auth { get; set; }

    public class AuthInfo
    {
        [JsonPropertyName("client_token")]
        public string ClientToken { get; set; }
    }
}

