﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Linq;
using System.Text;
using Datos;

namespace Datos.DAO
{
    public abstract class DAOGeneral
    {
        private SqlConnection conexion;
        private string strConexion;
        private SqlCommand comando;
        private string query;

        #region Conectar con la Base de Datos
        /// <summary>
        /// Metodo para realizar la conexion a la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public SqlConnection Conectar()
        {

            try
            {

                    strConexion = ConfigurationManager.
                    ConnectionStrings[RecursoGeneralDAO.Nombre_Base_Datos].ConnectionString;
                    conexion = new SqlConnection(strConexion);
                

            }

            catch (Exception ex)
            {

                throw ex;
            }

            return conexion;

        }
        #endregion

        #region Desconectar de la Base de Datos
        /// <summary>
        /// Metodo para cerrar la sesion con la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public void Desconectar()
        {

            try
            {
                this.conexion.Close();
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Desconectar(SqlConnection conec)
        {

            try
            {
                conec.Close();
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Ejecutar Stored Procedure
        /// <summary>
        /// Metodo para ejecutar un stored procedure de la base de datos usando parametros
        /// </summary>
        /// <param name="query">El stored procedure a ejecutar</param>
        /// <param name="parametros">lista de los parametros a usar</param>
        /// <returns>List<Resultado>con la informacion obtenida</returns>
        public List<Resultado> EjecutarStoredProcedure(string query, List<Parametro> parametros)
        {
            try
            {
                Conectar();
                List<Resultado> resultados = new List<Resultado>();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;


                    AsignarParametros(parametros);


                    conexion.Open();
                    comando.ExecuteNonQuery();
                    if (comando.Parameters != null)
                    {
                        foreach (SqlParameter parameter in comando.Parameters)
                        {
                            if (parameter.Direction.Equals(ParameterDirection.Output))
                            {
                                Resultado resultado = new Resultado(parameter.ParameterName,
                                    parameter.Value.ToString());
                                resultados.Add(resultado);
                            }
                        }
                        if (resultados != null)
                        {
                            return resultados;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    return null;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
        }
        /// <summary>
        /// Metodo para asignar los parametros a un comando
        /// </summary>
        /// <param name="parametros">Lista de parametros que se le va a asociar</param>
        public void AsignarParametros(List<Parametro> parametros)
        {
            foreach (Parametro parametro in parametros)
            {
                if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                    parametro.esOutput != null)
                {
                    if (parametro.esOutput)
                    {
                        comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato, 32000);
                        comando.Parameters[parametro.etiqueta].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        if (parametro.valor != null)
                        {
                            comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 32000));
                            comando.Parameters[parametro.etiqueta].Value = parametro.valor;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                else
                {
                    throw new Exception(); 
                }

            }
        }
        #endregion

        #region Ejecutar Stored Procedure Multiples Tuplas
        public DataTable EjecutarStoredProcedureTuplas(string query, List<Parametro> parametros)
        {
            try
            {
                Conectar();
                DataTable dataTable = new DataTable();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;


                    AsignarParametros(parametros);


                    conexion.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
        }
        #endregion

        #region Ejecutar Stored Procedure Altera Filas
        /// <summary>
        /// Metodo para ejecutar un stored procedure de la base de datos usando parametros y verificar si hubo cambios
        /// </summary>
        /// <param name="query">El stored procedure a ejecutar</param>
        /// <param name="parametros">lista de los parametros a usar</param>
        /// <returns>Las filas alteradas de la consulta hecha</returns>
        public int EjecutarStoredProcedureAlteraFilas(string query, List<Parametro> parametros)
        {
            //Variable que nos indicara si se alteraron filas en la BD
            int filasAfectadas;
            try
            {
                //nos conectamos con la Base de Datos
                Conectar();
                using (conexion)
                {
                    //Indicamos que es un stored procedure, cual utilizar y ademas la conexion que necesita
                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;

                    //Asignamos los parametros que tendra la consulta
                    AsignarParametros(parametros);

                    //Abrimos la conexion
                    conexion.Open();

                    //Ejecutamos la consulta y nos traemos las filas afectadas
                    filasAfectadas = comando.ExecuteNonQuery();

                    //retornamos la respuesta
                    return filasAfectadas;
                }


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Desconectamos si hubo algun error
                Desconectar();
            }
        }
        #endregion
    
    }
}