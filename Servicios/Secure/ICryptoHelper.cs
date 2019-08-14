using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Secure
{
    public interface ICryptoHelper
    {
        string Encrypt(string sOriginalText);
        string Decrypt(string sEncriptedText);
        string GeneratePassword(int length);
    }
}
