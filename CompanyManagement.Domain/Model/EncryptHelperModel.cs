using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Domain.Model
{
    public class EncryptHelperModel
    {
            public string SaltKey { get; set; }

            public string SaltKeyIV { get; set; }

            public string Value { get; set; }

            public byte[] EncryptString { get; set; }
    }
}
