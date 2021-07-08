using Microsoft.AspNetCore.Mvc;
using Payments.Clientes.Application.UseCases.CreateClient.Boundaries;
using Payments.Clientes.Application.UseCases.CreateClient.Ports;
using Payments.Core.Shared.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Clientes.Application.UseCases.CreateClient.Presenter
{
    public class CreateClientPresenter : BasePresenter, ICreateClientPort
    { 
        public void Created(CreateClientOutput output)
        {
            base.ViewModelResult = new CreatedResult(string.Empty, output);
        }

        public void Created()
        {
            base.ViewModelResult = new CreatedResult(string.Empty,null);
        }
    }
}
