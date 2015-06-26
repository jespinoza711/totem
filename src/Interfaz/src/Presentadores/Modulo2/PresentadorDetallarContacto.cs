﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using System.Web;
using Dominio.Fabrica;
using Comandos;
using Dominio;
using Dominio.Entidades.Modulo2;
using Comandos.Fabrica;

namespace Presentadores.Modulo2
{
    public class PresentadorDetallarContacto
    {
        private IContratoDetallarContacto vista;

        public PresentadorDetallarContacto(IContratoDetallarContacto laVista)
        {
            vista = laVista;
        }
        public void ObtenerVariablesURL()
        {
            String detalleContacto = HttpContext.Current.Request.QueryString["detalle"];
            if (detalleContacto != null)
                cargarDatos(detalleContacto);
        }
        public void cargarDatos(String idContacto)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();

            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarDatosContactoID();
            try
            {
                Entidad entidad = laFabrica.ObtenerContacto();
                entidad.Id = int.Parse(idContacto);
                Contacto elContacto = (Contacto)elComando.Ejecutar(entidad);

                vista.cedulaContacto = elContacto.ConCedula;
                vista.contactoNombre = elContacto.Con_Nombre;
                vista.cargoContacto = elContacto.ConCargo;
                vista.apellidoContacto = elContacto.Con_Apellido;
                vista.telefono = elContacto.Con_Telefono.Codigo + "-" + elContacto.Con_Telefono.Numero;

            }
            catch (NullReferenceException ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    RecursoInterfazM2.Alerta_Error_NullPointer +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
            catch (Exception ex)
            {
                vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Error;
                vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                vista.alerta = RecursoInterfazM2.Alerta_Html +
                    ex.Message +
                    RecursoInterfazM2.Alerta_Html_Final;
            }
        }
    }
}
