﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatosTotem {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class RecursoGeneralBD {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RecursoGeneralBD() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DatosTotem.RecursoGeneralBD", typeof(RecursoGeneralBD).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to T_00_001.
        /// </summary>
        public static string Codigo {
            get {
                return ResourceManager.GetString("Codigo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to T_00_003.
        /// </summary>
        public static string Codigo_Error_Desconexion {
            get {
                return ResourceManager.GetString("Codigo_Error_Desconexion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to T_00_02.
        /// </summary>
        public static string Codigo_Parametro_Errado {
            get {
                return ResourceManager.GetString("Codigo_Parametro_Errado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error con la Conexion en la BaseDeDatosTotem, no se pudo abrir la conexion.
        /// </summary>
        public static string Mensaje {
            get {
                return ResourceManager.GetString("Mensaje", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al Desconectarse con la BaseDeDatosTotem.
        /// </summary>
        public static string Mensaje_Error_Desconexion {
            get {
                return ResourceManager.GetString("Mensaje_Error_Desconexion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error en un parametro del stored procedure.
        /// </summary>
        public static string Mensaje_Parametro_Errado {
            get {
                return ResourceManager.GetString("Mensaje_Parametro_Errado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BaseDeDatosTotem.
        /// </summary>
        public static string NombreBD {
            get {
                return ResourceManager.GetString("NombreBD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\BaseDeDatos\BaseDeDatosTotem.mdf;Integrated Security=True.
        /// </summary>
        public static string StringDeConexion {
            get {
                return ResourceManager.GetString("StringDeConexion", resourceCulture);
            }
        }
    }
}
