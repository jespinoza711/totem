﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using DominioTotem;
using Presentadores.Modulo3;
using Contratos.Modulo3;

namespace Vista.Modulo3
{
    public partial class AgregarInvolucrados : System.Web.UI.Page, Contratos.Modulo3.IContratoAgregarInvolucrado
    {
        private PresentadorAgregarInvolucrado presentador;
        public AgregarInvolucrados()
        {
            presentador = new PresentadorAgregarInvolucrado(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.Master.idModulo = "3";
                this.Master.presentador.CargarMenuLateral();
                presentador.LlenarComboEmpresa();
            }
        }

        #region contrato
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboTipoEmpresa
        {
            get
            {
                return comboTipoEmpresa;
            }
            set
            {
                comboTipoEmpresa= value;
            }
        }
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboPersonal
        {
            get
            {
                return comboPersonal;
            }
            set
            {
                comboPersonal = value;
            }
        }
        DropDownList Contratos.Modulo3.IContratoAgregarInvolucrado.comboCargo
        {
            get
            {
                    return comboCargo;
            }
            set
            {
                comboCargo = value;
            }
        }
        Literal Contratos.Modulo3.IContratoAgregarInvolucrado.laTabla
        {
            get
            {
                return laTabla;
            }
            set
            {
                laTabla = value;
            }
        }
         

        #endregion contrato


          protected void actualizarComboCargos(object sender, EventArgs e)
          {
              presentador.ListarCargo();
          }
          protected void actualizarComboPersonal(object sender, EventArgs e)
          {
              presentador.ListarUsuarioSegunCargo();
          }
          protected void AgregarInvolucrados_Click(object sender, EventArgs e)
          {
              presentador.SeleccionarUsuario();
          }
          protected void btn_enviar_Click(object sender, EventArgs e)
          {
       
          }
          protected void evento_eliminar(object sender, EventArgs e)
          {
      
          }
       
    }
}