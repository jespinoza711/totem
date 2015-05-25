﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ExcepcionesTotem.Modulo2
{
    class ExcepcionLogicaClientes : ExceptionTotem
    {
         public ExcepcionLogicaClientes() : base()
        { }
   
        
        /// <summary>
        /// Instancia una excepcion referente a BD
        /// </summary>
        /// <param name="mensajeExcepcion">String con la excepcion capturada </param>

             public ExcepcionLogicaClientes(string message)
            : base(message)
        {
        }

        
              public ExcepcionLogicaClientes(string message, Exception inner)
            : base(message, inner)
        {
        }

              public ExcepcionLogicaClientes(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }


        
           

          
   
    }
}
