using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HimaanApp.Services
{
    public interface IFirebaseAuthenticator
    {
        /// <summary>
        /// Firebase login with email ans password.
        /// </summary>
        /// <return>OAuth token</return>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
