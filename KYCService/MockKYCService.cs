using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYCService
{
    /// <summary>
    /// Mock KYCService to simulate a KYC provider.
    /// </summary>
    public class MockKYCService : IKYCService
    {
        public bool CheckUser(string name)
        {
            return name.Length > 5;
        }
    }
}
