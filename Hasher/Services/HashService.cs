using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation; 

namespace Hasher.Services
{
    public class HashService : Interfaces.IHashes
    {
      
        private const int SaltLength = 16; 
        private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA512; 
        private const int HashLength = 32; 

        public HashService() { }

        public string GenerateSalt(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Länge muss größer als 0 sein.", nameof(length));
            }

            byte[] salt = RandomNumberGenerator.GetBytes(length);

            return Convert.ToBase64String(salt);
        }

        public string GeneratePasswordHash(string password, string salt, string pepper, int iterations)
        {
            

            string saltedPassword = password + pepper;

        
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes = KeyDerivation.Pbkdf2(saltedPassword, saltBytes, Prf, iterations, HashLength);

            return Convert.ToBase64String(hashBytes);
        }

      
        public bool VerifyPassword(string password, string salt, string pepper, int iterations, string hashToCompare)
        {
            
            string newHash = GeneratePasswordHash(password, salt, pepper, iterations);

            return newHash.Equals(hashToCompare, StringComparison.Ordinal);
        }

      
        public string GenerateRandomPassword()
        {
         
            throw new NotImplementedException();
        }
    }
}