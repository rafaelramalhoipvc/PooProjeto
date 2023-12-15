using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Models;

namespace Controllers
{
    public class ClienteController
    {
        public Cliente clienteModel;
        public ClienteView clienteView;

        public ClienteController(Cliente clienteModel, ClienteView clienteView)
        {
            this.clienteModel = clienteModel;
            this.clienteView = clienteView;
        }
    }
}
