﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contratos.Modulo2;
using Dominio;
using Dominio.Fabrica;
using Dominio.Entidades.Modulo2;
using Comandos;
using Comandos.Fabrica;
using System.Web;
using System.Web.UI;

namespace Presentadores.Modulo2
{
    /// <summary>
    /// Presentador de la ventana Detallar Empresa
    /// </summary>
    public class PresentadorDetallarEmpresa
    {
        private IContratoDetallarEmpresa vista;
        /// <summary>
        /// Constructor del presentador
        /// </summary>
        /// <param name="laVista">instancia de la ventana</param>
        public PresentadorDetallarEmpresa(IContratoDetallarEmpresa laVista)
        {
            vista = laVista;
        }
        /// <summary>
        /// Metodo para consultar las variables del URL
        /// </summary>
        public void ObtenerVariablesURL()
        {
            String detalleEmpresa = HttpContext.Current.Request.QueryString["id"];
            String success = HttpContext.Current.Request.QueryString["success"];
            if (detalleEmpresa != null && !(HttpContext.Current.Handler as Page).IsPostBack)
            {
                cargarDatos(detalleEmpresa);
                if (success != null && success.Equals("modificar"))
                {
                    vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Exito;
                    vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                    vista.alerta = RecursoInterfazM2.Alerta_Html +
                        RecursoInterfazM2.Alerta_Mensaje_Contacto_Modificado +
                        RecursoInterfazM2.Alerta_Html_Final;
                }
                else
                    if (success != null && success.Equals("agregar"))
                    {
                        vista.alertaClase = RecursoInterfazM2.Alerta_Clase_Exito;
                        vista.alertaRol = RecursoInterfazM2.Alerta_Rol;
                        vista.alerta = RecursoInterfazM2.Alerta_Html +
                            RecursoInterfazM2.Alerta_Mensaje_Contacto_Agregado +
                            RecursoInterfazM2.Alerta_Html_Final;
                    }
            }
        }
        /// <summary>
        /// Metodo para cargar los datos de la empresa
        /// </summary>
        /// <param name="idEmpresa">id de la empresa</param>
        public void cargarDatos(String idEmpresa)
        {
            FabricaEntidades laFabrica = new FabricaEntidades();

            Comando<Entidad, Entidad> elComando = FabricaComandos.CrearComandoConsultarClienteJurXID();
            try
            {
                Entidad entidad = laFabrica.ObtenerClienteJuridico(int.Parse(idEmpresa));
                ClienteJuridico elCliente = (ClienteJuridico)elComando.Ejecutar(entidad);

                vista.rifEmpresa = elCliente.Jur_Rif;
                vista.paisEmpresa = elCliente.Jur_Direccion.ElPais;
                vista.nombreEmpresa = elCliente.Jur_Nombre;
                vista.estadoEmpresa = elCliente.Jur_Direccion.ElEstado;
                vista.direccionEmpresa = elCliente.Jur_Direccion.LaDireccion;
                vista.codigoPostal = elCliente.Jur_Direccion.CodigoPostal;
                vista.ciudadEmpresa = elCliente.Jur_Direccion.LaCiudad;
                elCliente.Jur_Contactos = new List<Contacto>();
                Comando<Entidad,List<Entidad>> elComando2 = FabricaComandos.CrearComandoConsultarListaContactos();
                List<Entidad> contactos = elComando2.Ejecutar(elCliente);
                foreach (Entidad e in contactos)
                {
                    elCliente.Jur_Contactos.Add((Contacto)e);
                }
                foreach (Contacto elContacto in elCliente.Jur_Contactos)
                {
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_tr;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elContacto.Con_Nombre + " "
                        + elContacto.Con_Apellido + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elContacto.ConCargo
                        + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td + elContacto.Con_Telefono.Codigo
                        + "-" + elContacto.Con_Telefono.Numero + RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonDetalleContacto + elContacto.Id +
                        RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.AbrirBotonModificarContacto + elContacto.Id +
                        RecursoInterfazM2.RedireccionPag + HttpContext.Current.Request.Url.LocalPath +
                        RecursoInterfazM2.RedireccionID + elCliente.Id + RecursoInterfazM2.CerrarBoton;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_td;
                    vista.laTabla += RecursoInterfazM2.CerrarEtiqueta_tr;
                }
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
        /// <summary>
        /// metodo para la redireccion del boton para agregar un nuevo contacto
        /// </summary>
        public void redirAgregarContacto()
        {
            String detalleEmpresa = HttpContext.Current.Request.QueryString["id"];
            if (detalleEmpresa != null)
                HttpContext.Current.Response.Redirect(RecursoInterfazM2.AgregarContacto + detalleEmpresa
                    + RecursoInterfazM2.RedireccionPag + HttpContext.Current.Request.Url.LocalPath + 
                    RecursoInterfazM2.RedireccionID + detalleEmpresa);
        }
    }
}
