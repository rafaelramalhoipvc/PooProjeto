/*
 
*
@file AdministradorController.cs
@author Nelson (a20743@alunos.ipca.pt)
@author Rafael (a16452@alunos.ipca.pt)
@brief
@date Dezembro
*
@copyright Copyright (c) 2023
*
*/
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Controllers
{
    /// <summary>
    /// Controlador responsável por interligar as interações do administrador entre o modelo e a visualização.
    /// </summary>
    public class AdministradorController
    {
        #region Propriedades
        /// <summary>
        /// Obtém ou define o modelo de administrador.
        /// </summary>
        public Administrador administradorModel;

        /// <summary>
        /// Obtém ou define a visualização de administrador.
        /// </summary>
        public AdministradorView administradorView;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa uma nova instância da classe AdministradorController.
        /// </summary>
        /// <param name="administradorModel">O modelo de administrador.</param>
        /// <param name="administradorView">A visualização de administrador.</param>
        public AdministradorController(Administrador administradorModel, AdministradorView administradorView)
        {
            this.administradorModel = administradorModel;
            this.administradorView = administradorView;
        }
        #endregion
    }
}
