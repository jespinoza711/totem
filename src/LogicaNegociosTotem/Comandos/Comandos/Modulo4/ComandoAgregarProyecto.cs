﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO.Fabrica;
using DAO.DAO.Modulo4;
using DAO.IntefazDAO.Modulo4;

namespace Comandos.Comandos.Modulo4
{
    public class ComandoAgregarProyecto : Comando<Dominio.Entidad, Boolean>
    {
        public override bool Ejecutar(Dominio.Entidad parametro)
        {
            bool resultado = false;

		  FabricaDAOSqlServer fabricaDAO = new FabricaDAOSqlServer();
		  IDaoProyecto daoProyecto = fabricaDAO.ObtenerDAOProyecto();

            try
            {
                resultado = daoProyecto.Agregar(parametro);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return resultado;
        }
    }
}
