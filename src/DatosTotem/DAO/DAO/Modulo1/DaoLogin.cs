﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dominio;
using Dominio.Entidades.Modulo7;
using Dominio.Fabrica;
using ExcepcionesTotem.Modulo1;
using DAO.IntefazDAO.Modulo1;


namespace DAO.DAO.Modulo1
{
    public class DaoLogin : DAO,IDaoLogin
    {
        private FabricaEntidades fabricaEntidades = new FabricaEntidades();
        private Entidad _usuario;

        #region Metodos IDAOLogin
        public Entidad ValidarUsuarioLogin(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            if (usuario.Username != null && usuario.Clave != null && usuario.Username != "" && usuario.Clave != "")
            {
                try
                {
                    
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_ValidarLogin, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Username, usuario.Username));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave, usuario.Clave));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    if (leer != null)
                    {
                        while (leer.Read())
                        {
                            usuario.Nombre = leer[RecursosDaoModulo1.Parametro_Output_Usu_nombre].ToString();
                            usuario.Apellido = leer[RecursosDaoModulo1.Parametro_Output_Usu_apellido].ToString();
                            usuario.Rol = leer[RecursosDaoModulo1.Parametro_Output_Usu_rol].ToString();
                            usuario.Correo = leer[RecursosDaoModulo1.Parametro_Output_Usu_correo].ToString();
                            usuario.Cargo = leer[RecursosDaoModulo1.Parametro_Output_Usu_cargo].ToString();

                            return usuario;
                        }

                        return null;
                    }
                    else
                    {
                        ExcepcionesTotem.Modulo1.LoginErradoException excep = new ExcepcionesTotem.Modulo1.LoginErradoException(
                            RecursosDaoModulo1.Codigo_Login_Errado,
                            RecursosDaoModulo1.Mensaje_Login_Errado, new Exception());
                        ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                        throw excep;
                    }
                }
                 catch (ExcepcionesTotem.Modulo1.LoginErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.LoginErradoException excep= new ExcepcionesTotem.Modulo1.LoginErradoException(
                        ex.Codigo,
                        ex.Mensaje, ex);

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(
                        RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                finally
                {
                    Desconectar(conect);
                }
            }
            else
            {
                UsuarioVacioException excep=  new UsuarioVacioException(
                    RecursosDaoModulo1.Codigo_Usuario_Vacio, 
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio, new Exception());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
        }

        public Entidad ObtenerPreguntaSeguridad(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            if (usuario != null && usuario.Correo != null && usuario.Correo != "")
            {
                try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Obtener_Pregunta_Seguridad, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, usuario.Correo));

                    SqlDataReader leer;
                    conect.Open();
                    leer = sqlcom.ExecuteReader();
                    while (leer.Read())
                    {
                            usuario.PreguntaSeguridad = leer[RecursosDaoModulo1.Parametro_Output_PreguntaSeguridad].ToString();
                        
                    }
                    return usuario;
                }
                catch (SqlException ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                        RecursoGeneralDAO.Codigo_Error_BaseDatos,
                        RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
                {
                    ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
                {
                    ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                        ex.Codigo, ex.Mensaje, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                catch (ParametroInvalidoException ex)
                {
                    ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                        RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
                finally
                {
                    Desconectar(conect);
                }
            }
            else
            {
                UsuarioVacioException excep= new UsuarioVacioException(RecursosDaoModulo1.Codigo_Usuario_Vacio,
                    RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                    new UsuarioVacioException());
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            
        }

        public bool ValidarRespuestaSeguridad(Entidad parametro)
        {
            SqlConnection conect = Conectar();
            try
            {
                SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Validar_Pregunta_Seguridad, conect);
                sqlcom.CommandType = CommandType.StoredProcedure;
                sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, ((Usuario)parametro).Correo));

                SqlDataReader leer;
                conect.Open();

                leer = sqlcom.ExecuteReader();
                if (leer != null)
                {
                    while (leer.Read())
                    {
                        /*if (leer[RecursosDaoModulo1.Parametro_Output_RespuestaSeguridad].ToString() == null ||
                            leer[RecursosDaoModulo1.Parametro_Output_RespuestaSeguridad].ToString() == "")
                        {
                            EmailErradoException excep = new EmailErradoException(RecursosDaoModulo1.Codigo_Email_Errado,
                                        RecursosDaoModulo1.Mensaje_Email_errado,
                                        new EmailErradoException());
                            ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                            throw excep;
                        }*/

                        if (leer[RecursosDaoModulo1.Parametro_Output_RespuestaSeguridad].ToString() ==
                            ((Usuario)parametro).RespuestaSeguridad)
                        {
                            return true;
                        }
                        else
                        {
                            RespuestaErradoException excep = new RespuestaErradoException(RecursosDaoModulo1.Codigo_Respuesta_Errada,
                                RecursosDaoModulo1.Mensaje_Respuesta_Errada,
                                new RespuestaErradoException());
                            ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                            throw excep;
                        }
                    }
                    return false;
                }
                else
                {
                    EmailErradoException excep = new EmailErradoException(RecursosDaoModulo1.Codigo_Email_Errado,
                        RecursosDaoModulo1.Mensaje_Email_errado,
                        new EmailErradoException());
                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (EmailErradoException ex)
            {
                EmailErradoException excep = new EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;

            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep = new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        public bool ValidarCorreoExistente(string correo)
        {
            SqlConnection conect = Conectar();
            try
                {
                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_ValidarCorreo, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo, correo));

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    while (leer.Read())
                    {
                        if (leer != null)
                        {
                            if (leer[RecursosDaoModulo1.Parametro_Output_Usu_correo1].ToString()==correo)
                            {
                                return true;
                            }
                            else
                            {
                                EmailErradoException excep = new EmailErradoException(
                                      RecursosDaoModulo1.Codigo_Email_Errado,
                                      RecursosDaoModulo1.Mensaje_Email_errado,
                                      new EmailErradoException());
                                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                                throw excep;
                            }
                        }
                        else
                        {
                            EmailErradoException excep = new EmailErradoException(
                                RecursosDaoModulo1.Codigo_Email_Errado,
                                RecursosDaoModulo1.Mensaje_Email_errado,
                                new EmailErradoException());
                            ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                            throw excep;
                        }
                    }
                    return false;
                }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep = new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (EmailErradoException ex)
            {
                EmailErradoException excep = new EmailErradoException(ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep = new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }
        #endregion

        #region Metodos IDao

        public bool Modificar(Entidad parametro)
        {
            Usuario usuario = (Usuario)parametro;
            SqlConnection conect = Conectar();
            try
            {
                if (usuario != null && usuario.Clave != null && usuario.Correo
                    != "" && usuario.Clave != "" && usuario.Correo != "")
                {

                    SqlCommand sqlcom = new SqlCommand(RecursosDaoModulo1.Query_Cambiar_Clave, conect);
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Correo,
                        SqlDbType.VarChar));
                    sqlcom.Parameters.Add(new SqlParameter(RecursosDaoModulo1.Parametro_Input_Clave,
                        SqlDbType.VarChar));

                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Correo].Value = usuario.Correo;
                    sqlcom.Parameters[RecursosDaoModulo1.Parametro_Input_Clave].Value = usuario.Clave;

                    SqlDataReader leer;
                    conect.Open();

                    leer = sqlcom.ExecuteReader();
                    return true;
                }
             else
                {
                    ExcepcionesTotem.Modulo1.UsuarioVacioException excep= new ExcepcionesTotem.Modulo1.UsuarioVacioException(
                        RecursosDaoModulo1.Codigo_Usuario_Vacio,
                        RecursosDaoModulo1.Mensaje_Usuario_Vacio,
                        new ExcepcionesTotem.Modulo1.UsuarioVacioException());

                    ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                    throw excep;
                }
            }
            catch (SqlException ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    RecursoGeneralDAO.Codigo_Error_BaseDatos,
                    RecursoGeneralDAO.Mensaje_Error_BaseDatos, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                ExcepcionesTotem.ExceptionTotemConexionBD excep= new ExcepcionesTotem.ExceptionTotemConexionBD(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ExcepcionesTotem.Modulo1.EmailErradoException ex)
            {
                ExcepcionesTotem.Modulo1.EmailErradoException excep= new ExcepcionesTotem.Modulo1.EmailErradoException(
                    ex.Codigo, ex.Mensaje, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            catch (ParametroInvalidoException ex)
            {
                ParametroInvalidoException excep= new ParametroInvalidoException(RecursoGeneralDAO.Codigo_Parametro_Errado,
                    RecursoGeneralDAO.Mensaje_Parametro_Errado, ex);
                ExcepcionesTotem.Logger.EscribirError(Convert.ToString(this.GetType()), excep);
                throw excep;
            }
            finally
            {
                Desconectar(conect);
            }
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}

