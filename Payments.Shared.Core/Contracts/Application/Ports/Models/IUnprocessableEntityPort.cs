using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Core.Shared.Contracts.Application.Ports.Models
{
    public interface IUnprocessableEntityPort
    {
        void UnprocessableEntity(string errorMessage);
    }
}
