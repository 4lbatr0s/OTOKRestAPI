using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //explanation: 
    /*
        - Take hashed SecurityKey value of securityKey
        - Use securityKey and HmacSha512 algorithm to create a token for the credentials.   
     */
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
