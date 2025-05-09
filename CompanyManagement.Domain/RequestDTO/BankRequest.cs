using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Request
{
public    class BankRequest
    {
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public string IFSCCode { get; set; }

    }
}
