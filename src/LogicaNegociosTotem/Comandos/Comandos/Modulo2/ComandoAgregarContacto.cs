﻿using Dominio;
using DAO;
using DAO.IntefazDAO.Modulo2;
using DAO.Fabrica;
using DAO.DAO.Modulo2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcepcionesTotem;
using ExcepcionesTotem.Modulo2;
using System.Data.SqlClient;

namespace Comandos.Comandos.Modulo2
{
    class ComandoAgregarContacto: Comando<Entidad, bool>
    {
        public override bool Ejecutar(Entidad parametro)
        {
            try
            {
                FabricaDAOSqlServer laFabrica = new FabricaDAOSqlServer();
                IDaoContacto daoContacto = laFabrica.ObtenerDaoContacto();

                return daoContacto.Agregar(parametro);
            } 
            #region Catches
            catch (CIContactoExistenteException ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (ExcepcionesTotem.ExceptionTotemConexionBD ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(Convert.ToString(this.GetType()),
                    ex);

                throw ex;
            }
            #endregion
        }
    }
}