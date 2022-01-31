using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //actual token that we're going to give to user for it's credential values.
        public DateTime Expiration { get; set; }
    }
}
