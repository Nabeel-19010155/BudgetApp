using System.Security.Cryptography;
using System.Text;


namespace BudgetWebApp19010155.Models
{
    public partial class LoginInfo
    {
        public int UId { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }

        public virtual BasicInfo BasicInfo { get; set; }
        public virtual PropertyInfoBuy PropertyInfoBuy { get; set; }
        public virtual PropertyInfoRent PropertyInfoRent { get; set; }
        public virtual VehicleInfo VehicleInfo { get; set; }


        //_______________________________code attribution_______________________________
        //Author:   Dmitry Polomoshnov
        //Link:     https://stackoverflow.com/questions/3984138/hash-string-in-c-sharp
        public byte[] GetHash(string password)
        {
            using (HashAlgorithm alg = SHA256.Create())
                return alg.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public string GetHashString(string password)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in GetHash(password))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        //______________________________________end______________________________________

        
    }

}
