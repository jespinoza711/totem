﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTotem;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System.Data;
using System.Data.SqlClient;


namespace DatosTotem.Modulo2
{

    /// <summary>
    /// Clase encargada de acceder a la base de Datos relacionadas con la información sobre la gestión
    /// de Clientes y Empresas.
    /// </summary>
    public class BDCliente
    {

        //Conexion de la BD e instruccion a realizar
        SqlConnection conexion;
        SqlCommand comando;
        /// <summary>
        /// Constructor de la Clase BDCliente
        /// </summary>
        public BDCliente() 
        {
            try
            {
                //Obtenemos la ruta de la Base de Datos
                String[] aux = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { "src" }, StringSplitOptions.None);
                String configuracion = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + aux[0] + @"src\DatosTotem\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True";

                //La colocamos en la configuracion
                this.conexion = new SqlConnection(configuracion);
            }
            catch (Exception e)
            {
                throw new Exception("Error en la Configuracion de la BD", e);
            }
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteJuridico">Información del Cliente Jurídico</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteJuridico(ClienteJuridico clienteJuridico, int fkLugar,string nombreDireccion,string contactoNombre,string apellidoNombre,int idCargo,int codigo,int numero,string 
            cedulaContacto) 
        {
           bool respuesta = false;
            
            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureAgregarClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroRif, clienteJuridico.Jur_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroNombre, clienteJuridico.Jur_Nombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLogo, string.Empty);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLugar, fkLugar);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreDireccion, nombreDireccion);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCedula, cedulaContacto);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreContacto,contactoNombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroApellido, apellidoNombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.IdCargo,idCargo);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Codigo, codigo);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Numero, numero);
                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true; 

            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,e); 
            }
            catch (NullReferenceException e)
            {
                throw e; 
            }
            catch (Exception e)
            {
                throw e;  
            }
            finally 
            {
                this.conexion.Close(); 
            }

            return respuesta; 
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Agregar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool AgregarClienteNatural(ClienteNatural clienteNatural , int fkLugar, int codigo, int numero) 
        {

             bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureAgregarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Parametroidentificador, clienteNatural.Nat_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroNombren, clienteNatural.Nat_Nombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroApellidon, clienteNatural.Nat_Apellido);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCorreon, clienteNatural.Nat_Correo);

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreDireccion, clienteNatural.Nat_Direccion);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroLugarn, fkLugar);

              
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Codigo, codigo);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Numero, numero);
                
                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;


            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;       
           
        
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Eliminar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool EliminarClienteNatural(string cedula)
        {
            bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureEliminarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCedula, cedula);
               
                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;
                
            }

            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;  

           
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Natural
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
       
        public bool ModificarClienteNatural(ClienteNatural clienteNatural, string ciudad, int codigo, int numero)
        {

            bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureModificarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Parametroidentificador, clienteNatural.Nat_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroNombre, clienteNatural.Nat_Nombre);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroApellidon, clienteNatural.Nat_Apellido);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombrePais, clienteNatural.Nat_Pais);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreEstado, clienteNatural.Nat_Estado);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreCiudad, ciudad);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreDireccion, clienteNatural.Nat_Direccion);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroCorreon, clienteNatural.Nat_Correo);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Codigo, codigo );
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.Numero, numero);

                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;


            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;


        }

        
        /// <summary>
        /// Método que accede a la Base de Datos para Modificar un Cliente Jurídico
        /// </summary>
        /// <param name="clienteNatural">Información del Cliente Natural</param>
        /// <returns>Retorna true si lo realizó, false en caso contrario</returns>
        public bool ModificarClienteJuridico(ClienteJuridico clienteJuridico)
        {
            bool respuesta = false;

            try
            {
                int nroDeFilasAfectadas = 0;

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureModificarClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroRif, clienteJuridico.Jur_Id);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreClienteJuridico, clienteJuridico.Jur_Nombre);

                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.ParametroIdCiudad, clienteJuridico.Jur_Ciudad.IdLugar);
                this.comando.Parameters.AddWithValue(RecursosBaseDeDatosModulo2.NombreDireccion, clienteJuridico.Jur_Direccion.NombreLugar);


                this.conexion.Open();

                nroDeFilasAfectadas = this.comando.ExecuteNonQuery();

                if (nroDeFilasAfectadas > 0)
                    respuesta = true;


            }

            catch (SqlException e)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, e);
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.conexion.Close();
            }

            return respuesta;       
           
        }

        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Jurídico en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteJuridico ConsultarClienteJuridico(string idCliente) 
        {
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureConsultarDatosClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroRif,
                                            idCliente));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    clienteJuridico = ObtenerClienteJuridicoBD(lectura);
                }


            }

            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
			
			catch (InvalidOperationException ex)
            {
                throw new OperacionInvalidaException
                    (RecursosBaseDeDatosModulo2.CodigoOperacionInvalida,
                    RecursosBaseDeDatosModulo2.MensajeOperacionInvalida,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conexion.Close();
            }


            return clienteJuridico;            
        }


        /// <summary>
        /// Método que accede a la Base de Datos para Consultar un Cliente Natural en específico
        /// </summary>
        /// <returns>Retorna el objeto de tipo Cliente Juridico, null si el objeto no existe</returns>
        public ClienteNatural ConsultarClienteNatural(int idCliente)
        {
            ClienteNatural clienteNatural = new ClienteNatural();
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureDetallarCliente, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroIdClienteNatural,
                                            idCliente));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    clienteNatural = ObtenerClienteNaturalBD(lectura);
                }


            }
            catch (SqlException ex)
            {
                throw new ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
			  catch (InvalidOperationException ex)
            {
                throw new OperacionInvalidaException
                    (RecursosBaseDeDatosModulo2.CodigoOperacionInvalida,
                    RecursosBaseDeDatosModulo2.MensajeOperacionInvalida,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                this.conexion.Close();
            }


            return clienteNatural;
        }

        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Jurídicos
        /// </summary>
        /// <returns>Retorna una lista de Clientes Juridicos, null si el objeto no existe</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicos()
        {
            //Lista donde devolveremos los Clientes Jurudicos
            List<ClienteJuridico> listaClientesJuridicos = new List<ClienteJuridico>();
            try
            {
                //Respuesta de la consulta a la Base de Datos
                SqlDataReader respuesta;

                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureListarClientesJuridicos, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron obtenidas
                respuesta = comando.ExecuteReader();

                //Si se encontraron Clientes Juridicos comienza a agregar en la variable lista, sino, se devolvera vacia
                if (respuesta.HasRows)
                    //Recorremos cada fila devuelta de la consulta
                    while (respuesta.Read())
                    {
                        //Creamos el Cliente Juridicos y lo anexamos a la lista
                        ClienteJuridico aux = new ClienteJuridico(respuesta.GetString(0), respuesta.GetString(1));
                        listaClientesJuridicos.Add(aux);
                    }

                //Cerramos conexion
                this.conexion.Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());

            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al Listar", error);
            }
            //Retornamos la respuesta
            return listaClientesJuridicos;
        }


        /// <summary>
        /// Método que accede a la Base de Datos para consultar una lista de Clientes Naturales
        /// </summary>
        /// <returns>Retorna una lista de Clientes Naturales, null si el objeto no existe</returns>
        public List<ClienteNatural> ConsultarClientesNaturales()
        {
            //Lista donde devolveremos los Clientes Naturales
            List<ClienteNatural> listaClientesNaturales = new List<ClienteNatural>();
            try
            {
                //Respuesta de la consulta a la Base de Datos
                SqlDataReader respuesta;

                //Indicamos que es un Stored Procedure, cual utilizar y ademas la conexion que necesita
                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureListarClientesNaturales, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                //Se abre conexion contra la Base de Datos
                this.conexion.Open();

                //Ejecutamos la consulta y traemos las filas que fueron obtenidas
                respuesta = comando.ExecuteReader();

                //Si se encontraron Clientes Naturales comienza a agregar en la variable lista, sino, se devolvera vacia
                if (respuesta.HasRows)
                    //Recorremos cada fila devuelta de la consulta
                    while (respuesta.Read())
                    {
                        //Creamos el Cliente Natural y lo anexamos a la lista
                        ClienteNatural aux = new ClienteNatural(respuesta.GetString(0), respuesta.GetString(1), respuesta.GetString(2), respuesta.GetString(3));
                        listaClientesNaturales.Add(aux);
                    }

                //Cerramos conexion
                this.conexion.Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());

            }
            catch (Exception error)
            {
                throw new Exception("Ha ocurrido un error inesperado al Listar", error);
            }
            //Retornamos la respuesta
            return listaClientesNaturales;
        }


       /// <summary>
       /// Método que retorna una lista de Clientes Jurídicos dado un parámetro de búsqueda
       /// </summary>
       /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
       /// <returns>Retorna una lista de clientes jurídicos que cumplan con el 
       /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteJuridico> ConsultarClientesJuridicosParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que retorna una lista de Clientes Naturales dado un parámetro de búsqueda
        /// </summary>
        /// <param name="parametroBusqueda">Parámetro de Búsqueda</param>
        /// <returns>Retorna una lista de clientes naturales que cumplan con el 
        /// parámetro de búsqueda, null si ninguno cumple con el parámetro</returns>
        public List<ClienteNatural> ConsultarClientesNaturalesParametrizados(string parametroBusqueda)
        {
            throw new NotImplementedException();
        }

       /// <summary>
        /// Método que accede a la Base de Datos para 
        /// verificar la existencia de un cliente natural
        /// </summary>
        /// <param name="identificador">RIF a verificar</param>
        /// <returns>0 si no existe, 1 o más si existe</returns>
        public int VerificarExistenciaClienteJuridico(string identificador) 
        {
            int cantidad = 0; 
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureVerificarClienteJuridico, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.ParametroRif,
                                            identificador));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    cantidad = lectura.GetInt32(0);
                }


            }

            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }

            catch (InvalidOperationException ex)
            {
                throw new OperacionInvalidaException
                    (RecursosBaseDeDatosModulo2.CodigoOperacionInvalida,
                    RecursosBaseDeDatosModulo2.MensajeOperacionInvalida,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conexion.Close();
            }


            return cantidad;


            
        }

        /// <summary>
        /// Método que accede a la Base de Datos para 
        /// verificar la existencia de un cliente natural
        /// </summary>
        /// <param name="cedula">Cédula a verificar</param>
        /// <returns>0 si no existe, 1 o más si existe</returns>
        public int VerificarExistenciaClienteNatural(string cedula) 
        {

            int cantidad = 0;
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureVerificarClienteNatural, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.Parametroidentificador,
                                            cedula));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    cantidad = lectura.GetInt32(0);
                }


            }

            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new OperacionInvalidaException
                    (RecursosBaseDeDatosModulo2.CodigoOperacionInvalida,
                    RecursosBaseDeDatosModulo2.MensajeOperacionInvalida,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conexion.Close();
            }


            return cantidad;
        }

        /// <summary>
        /// Método que accede a la Base de Datos para
        /// obtener un listado de cargos 
        /// </summary>
        /// <returns>Nombre de los cargos existentes</returns>
        public List<string> LlenarCargoCombo() 
        {
            List<string> cargos = new List<string>();
            string cargo = ""; 
            try 
            {
                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.ProcedureLlenarComboCargo, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();
                while (lectura.Read())
                {
                    cargo = lectura.GetString(0);
                    cargos.Add(cargo); 
                }
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conexion.Close();
            }
            return cargos; 
        }

        

        /// <summary>
        /// Método que obtiene directamente de la Base de Datos
        /// un registro de tipo Cliente Natural
        /// </summary>
        /// <param name="lector">Cliente Natural seleccionado</param>
        public ClienteNatural ObtenerClienteNaturalBD(SqlDataReader lector) 
        {
            ClienteNatural clienteNatural = new ClienteNatural();
            Lugar lugar = new Lugar();
            List<string> telefonos = new List<string>(); 
           try
           {
               clienteNatural.Nat_Id = lector.GetString(0);
               clienteNatural.Nat_Nombre = lector.GetString(1);
               clienteNatural.Nat_Apellido = lector.GetString(2);
               clienteNatural.Nat_Correo = lector.GetString(4);
               int codigo = lector.GetInt32(5);
               int numero = lector.GetInt32(6);
               string numeroCompleto = codigo.ToString() + numero.ToString();
               telefonos.Add(numeroCompleto); 
               clienteNatural.Nat_Telefonos=telefonos;
               clienteNatural.Nat_Pais = lector.GetString(7);
               clienteNatural.Nat_Estado = lector.GetString(8);
               lugar.NombreLugar = lector.GetString(9);
               clienteNatural.Nat_Direccion = lector.GetString(10);

               lugar.CodigoPostal = lector.GetInt32(11).ToString();
               clienteNatural.Nat_Ciudad = lugar; 
           }
           catch (SqlException ex)
           {
               throw ex; 
           }
           catch (NullReferenceException ex)
           {
               throw  ex;
           }
           catch (Exception ex) 
           {
               throw ex; 
           }

           return clienteNatural; 
         }


        /// <summary>
        /// Método que obtiene directamente de Base de Datos
        /// la información relacionada a un cliente Jurídico
        /// </summary>
        /// <param name="lector">Cliente Jurídico Seleccionado</param>
        /// <returns></returns>
        public ClienteJuridico ObtenerClienteJuridicoBD(SqlDataReader lector) 
        {
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            Lugar lugar = new Lugar();
            List<string> telefonos = new List<string>();
            List<Contacto> contactos = new List<Contacto>(); 
           try
           {
               clienteJuridico.Jur_Id = lector.GetString(0);
               clienteJuridico.Jur_Nombre = lector.GetString(1);
               lugar.IdLugar = lector.GetInt32(2);
               clienteJuridico.Jur_Direccion = lugar; 
              
           }
           catch (SqlException ex)
           {
               throw ex; 
           }
           catch (NullReferenceException ex)
           {
               throw  ex;
           }
           catch (Exception ex) 
           {
               throw ex; 
           }

           return clienteJuridico; 
         }

		 
		  /// <summary>
        /// Método que trae de la Base de Datos
        /// los contactos que tiene una determinada empresa
        /// </summary>
        /// <param name="lector"></param>
        /// <returns></returns>
        public Contacto ObtenerBDContacto(SqlDataReader lector) 
        {
            Contacto contacto = new Contacto();
            List<string> telefonos = new List<string>();
            string telefono = string.Empty; 
            try
            {
                contacto.Con_Id = Convert.ToInt32(lector.GetString(0));
                contacto.Con_Nombre = lector.GetString(1);
                contacto.Con_Apellido = lector.GetString(2);
                contacto.ConCargo = lector.GetString(3);
                int codigo = lector.GetInt32(4);
                int numero = lector.GetInt32(5);
                telefono = codigo.ToString() + numero.ToString();
                telefonos.Add(telefono);
                contacto.Con_Telefonos = telefonos; 

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return contacto; 
        }
		 
		 #region Consultar Datos del Cliente según nombre proyecto

        /// <summary>
        /// Método que retorna los datos de un cliente
        /// jurídico dado el nombre de un proyecto
        /// </summary>
        /// <param name="nombreProyecto">Nombre del Proyecto</param>
        /// <returns>Datos del Cliente Jurídico</returns>
        public ClienteJuridico DatosClienteProyecto(string  codigo) 
        { 
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            try
            {

                this.comando = new SqlCommand(RecursosBaseDeDatosModulo2.DatosClienteNombreProyecto, this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.Add(new SqlParameter(RecursosBaseDeDatosModulo2.Codigo,
                                            codigo));

                SqlDataReader lectura;
                this.conexion.Open();
                lectura = this.comando.ExecuteReader();

                while (lectura.Read())
                {
                    clienteJuridico = RetornarClienteJuridicoBD(lectura);
                }


            }

            catch (SqlException ex)
            {
                throw new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralBD.Codigo_Error_Desconexion,
                    RecursoGeneralBD.Mensaje_Error_Desconexion,
                    ex);
            }
            catch (NullReferenceException ex)
            {
                throw new ClienteInexistenteException(
                    RecursosBaseDeDatosModulo2.CodigoClienteInexistente,
                    RecursosBaseDeDatosModulo2.MensajeClienteInexistente,
                    ex);
            }
            catch (InvalidOperationException ex) 
            {
                throw new OperacionInvalidaException
                    (RecursosBaseDeDatosModulo2.CodigoOperacionInvalida,
                    RecursosBaseDeDatosModulo2.MensajeOperacionInvalida,
                    ex);
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTotem.ExceptionTotem(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex); 
            }
            finally
            {
                this.conexion.Close();
            }


            return clienteJuridico; 
        }

        /// <summary>
        /// Método que obtiene de la Base de Datos directamente los 
        /// registros de la consulta asociada con el procedimiento
        /// de Retornar datos del cliente según el nombre del proyeco
        /// </summary>
        /// <param name="lector"></param>
        /// <returns>Datos del Cliente Jurídico</returns>
        public ClienteJuridico RetornarClienteJuridicoBD(SqlDataReader lector) 
        {
            ClienteJuridico clienteJuridico = new ClienteJuridico();
            Lugar lugar = new Lugar();
            List<string> telefonos = new List<string>();
            string elTelefono = string.Empty; 
            
            try
            {
                clienteJuridico.Jur_Id = lector.GetString(0);
                clienteJuridico.Jur_Nombre = lector.GetString(1);
                elTelefono = lector.GetInt32(4).ToString() + lector.GetInt32(5).ToString();
                telefonos.Add(elTelefono);
                clienteJuridico.Jur_Telefonos = telefonos;
                lugar.NombreLugar = lector.GetString(6);
                clienteJuridico.Jur_Direccion.NombreLugar = lugar.NombreLugar; 


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return clienteJuridico; 
        }

        #endregion

    }
 }

    

    
}
