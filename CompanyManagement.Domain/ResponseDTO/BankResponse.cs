using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Responses
{
  public  class BankResponse
    {
        public int BankDetailID { get; set; }
        public int UserID { get; set; }
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }


    }
}
