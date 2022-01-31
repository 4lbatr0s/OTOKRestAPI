using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {    //I'll just assing values to the passwordHash and passwordSalt because they've got out keys. 
        //we do not need to write an extra return statement.
        public static void CreatePasswordHash(string password, out byte [] passwordHash, out byte[] passwordSalt) //its static for we'll never create instance of it.
        {
            //disposable pattern using 
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //it returns the key in he HMAC calculation, creates specific values for each user.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //first get the byte equievalent of the password, then hash it.
            }
        }

        public static bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }

            }

            return true;
        }
    }
}
