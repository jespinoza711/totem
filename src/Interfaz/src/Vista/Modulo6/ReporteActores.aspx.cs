﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Contratos.Modulo6;
using Presentadores.Modulo6;   

namespace Vista.Modulo6
{
    public partial class ReporteActores : System.Web.UI.Page, Contratos.Modulo6.IContratoReporteActores
    {
        private PresentadorReporteActores presentador;

        public ReporteActores() 
        {
            presentador = new PresentadorReporteActores(this);         
        }

        #region Contratos

        Repeater Contratos.Modulo6.IContratoReporteActores.RCasosDeUso 
        {
            get { return RCasosDeUso; }
            set { RCasosDeUso = value; }
        }

        DropDownList Contratos.Modulo6.IContratoReporteActores.comboActores 
        {
            get { return comboActores; }
            set { comboActores = value; }
        }

      
        Label Contratos.Modulo6.IContratoReporteActores.mensajeExito
        {
            get { return labelMensajeExito; }
            set { labelMensajeExito = value; }
        }

        Label Contratos.Modulo6.IContratoReporteActores.mensajeError
        {
            get { return labelMensajeError; }
            set { labelMensajeError = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = this.Master.CodigoProyectoActual(); 
            this.Master.idModulo = "6";
            if (!IsPostBack)
            {
                this.Master.presentador.CargarMenuLateral();
                this.presentador.LimpiarPagina(); 
                this.presentador.CargarActores(codigo); 
            }
        }

        /// <summary>
        /// Evento que se dispara al seleccionar alguna de las 
        /// opciones del combo de actores, y carga los casos de uso
        /// asociados al actor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CargarTablaCasosDeUso(object sender, EventArgs e) 
        {
            string codigo = this.Master.CodigoProyectoActual();
            this.presentador.CargarTablaCasosDeUso(codigo); 
        }
    }
}