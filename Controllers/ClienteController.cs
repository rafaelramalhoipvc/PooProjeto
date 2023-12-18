/*
 
*
@file ClienteController.cs
@author Nelson (a20743@alunos.ipca.pt)
@author Rafael (a16452@alunos.ipca.pt)
@brief
@date Dezembro
*
@copyright Copyright (c) 2023
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;
using Models;

namespace Controllers
{
    /// <summary>
    /// Controlador responsável por interligar as interações do cliente entre o modelo e a visualização.
    /// </summary>
    public class ClienteController
    {
        #region Propriedades

        /// <summary>
        /// Obtém ou define o modelo de cliente.
        /// </summary>
        public Cliente clienteModel;

        /// <summary>
        /// Obtém ou define a visualização de cliente.
        /// </summary>
        public ClienteView clienteView;

        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa uma nova instância da classe ClienteController.
        /// </summary>
        /// <param name="clienteModel">O modelo de cliente.</param>
        /// <param name="clienteView">A visualização de cliente.</param>
        public ClienteController(Cliente clienteModel, ClienteView clienteView)
        {
            this.clienteModel = clienteModel;
            this.clienteView = clienteView;
        }
        #endregion
    }
}
