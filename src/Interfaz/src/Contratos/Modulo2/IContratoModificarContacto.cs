﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contratos.Modulo2
{
    public interface IContratoModificarContacto
    {
        string nombreContacto{ get; set; }
        
        string apellidoContacto{ get; set; }
        
        string cedulaContacto{ get; set; }

        string comboCargo { get; set; }
        
        string codTelefono{ get; set; }
        
        string telefonoContacto{ get; set; }
   } 
}
