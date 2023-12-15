using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Controllers
{
    public class AdministradorController
    {
        public Administrador administradorModel;
        public AdministradorView administradorView;

        public AdministradorController(Administrador administradorModel, AdministradorView administradorView)
        {
            this.administradorModel = administradorModel;
            this.administradorView = administradorView;
        }
    }
}
