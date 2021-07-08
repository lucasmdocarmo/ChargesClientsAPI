using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Core.Shared.Exceptions
{
    public class GatewayException: Exception
    {
        public override string Message { get; }
        public bool Error { get; }
        public GatewayException(string message) : base(message)
        {
            this.Message = message;
        }
        public GatewayException(string message, bool error) : base(message)
        {
            this.Message = message;
            this.Error = error;
        }
    }
}
