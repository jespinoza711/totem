﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicaNegociosTotem.Modulo2 {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RecursosLogicaModulo2 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RecursosLogicaModulo2() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LogicaNegociosTotem.Modulo2.RecursosLogicaModulo2", typeof(RecursosLogicaModulo2).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a T_02_001.
        /// </summary>
        internal static string CodigoClienteInexistente {
            get {
                return ResourceManager.GetString("CodigoClienteInexistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a T_02_005.
        /// </summary>
        internal static string CodigoOperacionInvalida {
            get {
                return ResourceManager.GetString("CodigoOperacionInvalida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a No se ha podido encontrar al Cliente.
        /// </summary>
        internal static string MensajeClienteInexistente {
            get {
                return ResourceManager.GetString("MensajeClienteInexistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Operación inválida.
        /// </summary>
        internal static string MensajeOperacionInvalida {
            get {
                return ResourceManager.GetString("MensajeOperacionInvalida", resourceCulture);
            }
        }
    }
}