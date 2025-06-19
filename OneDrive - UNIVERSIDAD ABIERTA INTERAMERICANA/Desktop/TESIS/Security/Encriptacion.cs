using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Seguridad
{
    public static class Encriptacion
    {
        public static string EncriptarPassword(string pPassword)
        {
            try
            {
                byte[] encriptado = Encoding.Unicode.GetBytes(pPassword);
                string resultado = Convert.ToBase64String(encriptado);
                return resultado;

            }
            catch (CryptographicException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }

        }
        public static string Desencriptar(string pPassword)
        {
            try
            {
                byte[] desencrriptar = Convert.FromBase64String(pPassword);
                string resultado = Encoding.Unicode.GetString(desencrriptar);
                return resultado;
            }
            catch (CryptographicException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { }
        }
    }
}
    
