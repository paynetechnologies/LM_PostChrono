using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gov.uscourts.ao.rest.ts.Interfaces
{
    public interface ITSRestStaff
    {
        int GetAuthorCode(string districtId);
    }
}
