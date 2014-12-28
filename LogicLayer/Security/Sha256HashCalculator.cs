using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Security
{
    public class Sha256HashCalculator : IHashCalculator
    {
        private const int MinSaltSize = 4;
        private const int MaxSaltSize = 8;

        private const int HashSize = 32;

        public string Calculate(string raw, byte[] saltBytes = null)
        {
            if (saltBytes == null || !saltBytes.Any())
            {
                saltBytes = new byte[new Random().Next(MinSaltSize, MaxSaltSize)];
                using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
                {
                    rngCryptoServiceProvider.GetNonZeroBytes(saltBytes);
                }
            }

            using (var sha = new SHA256Managed())
            {
                return Convert.ToBase64String(
                    sha.ComputeHash(Encoding.UTF8.GetBytes(raw).Concat(saltBytes).ToArray())
                        .Concat(saltBytes).ToArray());
            }
        }

        public bool Check(string raw, string hash)
        {
            return Calculate(raw, Convert.FromBase64String(hash).Skip(HashSize).ToArray()).Equals(hash);
        }
    }
}
