﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTotem;
using LogicaNegociosTotem;

public partial class GUI_Modulo5_PrincipalProyecto : System.Web.UI.Page
{
    #region Atributos
    List<Requerimiento> listaRequerimientos;
    #endregion

    #region Page_Load()
    protected void Page_Load(object sender, EventArgs e)
    {

	   //String success = Request.QueryString["success"];

	   //if (success != null)
	   //{
	   //    if (success.Equals("1"))
	   //    {
	   //	   alert.Attributes["class"] = "alert alert-success alert-dismissible";
	   //	   alert.Attributes["role"] = "alert";
	   //	   alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento agregado exitosamente</div>";

	   //    }else
	   //    if (success.Equals("2"))
	   //    {
	   //	   alert.Attributes["class"] = "alert alert-success alert-dismissible";
	   //	   alert.Attributes["role"] = "alert";
	   //	   alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento modificado exitosamente</div>";

	   //    }
	   //    else
	   //    if (success.Equals("3"))
	   //    {
	   //	   alert.Attributes["class"] = "alert alert-success alert-dismissible";
	   //	   alert.Attributes["role"] = "alert";
	   //	   alert.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento eliminado exitosamente</div>";

	   //    }
	   //}



	   ((MasterPage)Page.Master).IdModulo = "5";

	   DominioTotem.Usuario user = HttpContext.Current.Session["Credenciales"] as DominioTotem.Usuario;

	   if (user != null)
	   {
		  if (user.username != "" &&
			  user.clave != "")
		  {
			 ((MasterPage)Page.Master).ShowDiv = true;
		  }
		  else
		  {
			 ((MasterPage)Page.Master).MostrarMenuLateral = false;
			 ((MasterPage)Page.Master).ShowDiv = false;
		  }
	   }
	   else
	   {
		  Response.Redirect("../Modulo1/M1_login.aspx");
	   }

    } 
    #endregion

    #region Consultar requerimientos por proyecto
    protected List<Requerimiento>
  ConsultarRequerimientosPorProyecto(int codigo)
    {
	   return listaRequerimientos =
		  LogicaNegociosTotem.Modulo5.LogicaRequerimiento.
		  ConsultarRequerimientosPorProyecto(codigo);
    } 
    #endregion
}