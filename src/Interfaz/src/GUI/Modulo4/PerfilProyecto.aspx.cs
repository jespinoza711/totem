﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class GUI_Modulo4_PerfilProyecto : System.Web.UI.Page
{
    private DominioTotem.Proyecto esteProyecto = new DominioTotem.Proyecto();

    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)Page.Master).IdModulo = "4";

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

        String success = Request.QueryString["success"];
        if (success != null)
        {
            String[] successInfo = success.Split(new Char[] { ',' });
            switch (successInfo[1])
            {
                case "0":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Proyecto modificado exitosamente</div>";
                    break;
                case "1":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento modificado exitosamente</div>";
                    break;
                case "2":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Requerimiento eliminado exitosamente</div>";
                    break;
                case "3":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso modificado exitosamente</div>";
                    break;
                case "4":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Caso de uso eliminado exitosamente</div>";
                    break;
                case "5":
                    alerts.Attributes["class"] = "alert alert-success alert-dismissible";
                    alerts.Attributes["role"] = "alert";
                    alerts.InnerHtml = "<div><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>Involucrado eliminado exitosamente</div>";
                    break;
            }

            esteProyecto = LogicaNegociosTotem.Modulo4.LogicaProyecto.ConsultarProyecto(successInfo[0]);

            HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");

            if (projectCookie == null)
            {
                projectCookie = new HttpCookie("selectedProjectCookie");
                projectCookie.Values["projectCode"] = esteProyecto.Codigo;
                projectCookie.Values["projectName"] = esteProyecto.Nombre;
                Response.Cookies.Add(projectCookie);
            }
            else if (projectCookie.Values["projectCode"] != esteProyecto.Codigo)
            {
                Response.Cookies.Remove("selectedProjectCookie");
                projectCookie = new HttpCookie("selectedProjectCookie");
                projectCookie.Values["projectCode"] = esteProyecto.Codigo;
                projectCookie.Values["projectName"] = esteProyecto.Nombre;
                Response.Cookies.Add(projectCookie);
            }

            this.div_proyecto.InnerHtml = "<div class='jumbotron'>";
            this.div_proyecto.InnerHtml += "<h2 class='sameLine bootstrapBlue' id='nombreProyecto' runat='server'>" + esteProyecto.Nombre + "</h2> <h5 class='sameLine'>COD: </h5> <h5 id='codigoProyecto' class='sameLine' runat='server'>" + esteProyecto.Codigo + "</h5>";
            this.div_proyecto.InnerHtml += "<p class='desc'>" + esteProyecto.Descripcion + "</p>";
            if (esteProyecto.Estado == true)
            {
                this.div_proyecto.InnerHtml += "<input type='checkbox' checked disabled> Activo";
            }
            else
            {
                this.div_proyecto.InnerHtml += "<input type='checkbox' unchecked disabled> Inactivo";
            }
            this.div_proyecto.InnerHtml += "<br><br>";
            this.div_proyecto.InnerHtml += "<p class='sameLine'>Cliente: </p><p id='nombreCliente' class='sameLine bootstrapBlue'>" + "</p>";
            this.div_proyecto.InnerHtml += "<br><br>";
            this.div_proyecto.InnerHtml += "<p>Progreso:</p>";
            this.div_proyecto.InnerHtml += "<div class='progress'>";
            int[] progreso = LogicaNegociosTotem.Modulo4.LogicaProyecto.CalcularProgreso(esteProyecto.Codigo);
            this.div_proyecto.InnerHtml += "<div class='progress-bar progress-bar-success' role='progressbar' aria-valuenow='" + progreso[2].ToString() + "' aria-valuemin='0' aria-valuemax='100' style='width: " + progreso[2].ToString() + "%;' data-toggle='tooltip' data-placement='top' title='" + progreso[1].ToString() + " Requerimientos completados de " + progreso[0].ToString() + "'>";
            this.div_proyecto.InnerHtml += progreso[2].ToString() + "%";
            this.div_proyecto.InnerHtml += "</div>";
            this.div_proyecto.InnerHtml += "</div>";
            this.div_proyecto.InnerHtml += "</div>";
            this.requerimientosBadge.InnerText = "0";
            this.casosDeUsoBadge.InnerText = "0";
            this.minutasBadge.InnerText = "0";
            this.involucradosBadge.InnerText = "0";
            

            

            this.modifyButton.Text = "<a class='btn btn-primary' href='ModificarProyecto.aspx?success=" + esteProyecto.Codigo + "'>Modificar</a>";
        }
        else
        {
            this.div_proyecto.InnerHtml = "<div class='jumbotron'>";
            this.div_proyecto.InnerHtml += "<h2 class='sameLine bootstrapBlue' id='nombreProyecto' runat='server'>:(</h2>";
            this.div_proyecto.InnerHtml += "<p class='desc'>No hay ningun proyecto seleccionado...</p>";
            this.div_proyecto.InnerHtml += "</div>";
            this.div_proyecto.InnerHtml += "</div>";
            this.div_proyecto.InnerHtml += "</div>";
        }

    }

    public void Ers(object sender, EventArgs e)
    {
        try
        {
            HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");
            LogicaNegociosTotem.Modulo4.LogicaProyecto.GenerarERS(projectCookie.Values["projectCode"]);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + "ers.pdf");
            Response.TransmitFile(@"C:\Program Files (x86)\IIS Express\ers.pdf");
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    public void Factura(object sender, EventArgs e)
    {
        try
        {
            HttpCookie projectCookie = Request.Cookies.Get("selectedProjectCookie");
            LogicaNegociosTotem.Modulo4.LogicaProyecto.GenerarFactura(projectCookie.Values["projectCode"]);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + "ers.pdf");
            Response.TransmitFile(@"C:\Program Files (x86)\IIS Express\factura.pdf");
            Response.End();
            //Response.WriteFile(strS);
            Response.Flush();
            Response.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}