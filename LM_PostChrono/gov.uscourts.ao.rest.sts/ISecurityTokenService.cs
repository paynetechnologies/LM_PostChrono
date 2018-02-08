using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gov.uscourts.ao.rest.sts
{
    public interface ISecurityTokenService
    {
        void CheckSTS();
        string GetSTS();
        string GetSTS(string baseUrl, string user, string pass);
    }
}
