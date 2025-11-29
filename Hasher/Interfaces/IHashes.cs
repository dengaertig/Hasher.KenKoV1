using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hasher.Interfaces
{
    internal interface IHashes
    {

        string GenerateSalt(int length);
        
        string GeneratePasswordHash(string password, string salt, string pepper, int iterations);

        bool VerifyPassword(string password, string salt, string pepper, int iterations, string hashToCompare);

        string GenerateRandomPassword();

    }
}
