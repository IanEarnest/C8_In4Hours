using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic.Entities
{
    //  Enum Status  (Unconfirmed, New, Assigned, Resolved, Verified, Reopen, Closed)
    public enum Status
    {
        Unconfirmed = 1, 
        New, 
        Assigned, 
        Resolved, 
        Verified, 
        Reopen, 
        Closed
    }
}
