using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Filed.Services.Payment.Models
{
    public class RequiredFiledException : Exception
    {
        public string FieldName { get; private set; }
        public override string Message
        {
            get
            {
                return $"Missing Required Field {FieldName}";
            }
        }
        public RequiredFiledException(string fieldName) 
        {
            this.FieldName = fieldName;
        }

    }
}
