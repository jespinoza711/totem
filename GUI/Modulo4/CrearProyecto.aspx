﻿<%@ Page Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master"  AutoEventWireup="true" CodeFile="CrearProyecto.aspx.cs" Inherits="GUI_Modulo4_CrearProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="bootstrap-switch-master/docs/css/highlight.css" rel="stylesheet">
    <link href="bootstrap-switch-master/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet">
    <link href="bootstrap-switch-master/docs/css/main.css" rel="stylesheet">
    <style>
        textarea {
            resize: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestion de Proyectos</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server"> Crear</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <!--AQUI SE DEFINE EL TAMANO DEL FORM Y SU UBICACION-->
    
   
    <div class="col-sm-10 col-md-10 col-lg-10 col-md-offset-1">
        <form id="register_form" class="form-horizontal" action="#">
            <div class="form-group">
                <div id="div_nombre" class="col-sm-8 col-md-8 col-lg-8">
				    <input type="text" id="Nombre" placeholder="Nombre" onblur="fillCodigoTextField()" class="form-control" name="nombre"/>
                   
			    </div>
		        
                &nbsp;
			    <div id="div_codigo" class="col-sm-2 col-md-2 col-lg-2">
				    <input type="text" id="Codigo" placeholder="Codigo" class="form-control" name="codigo" disabled="disabled"  maxlength="3"
                minlength="1"/>
			    </div>
		    </div>
            <div class="form-group">
	            <div id="div_descripcion" class="col-sm-10 col-md-10 col-lg-10">
		            <textarea placeholder="Descripcion" class="form-control" name="descripcion" rows="3"></textarea>
		        </div>
	        </div>

            <!--<div class="form-group">
                <div class="col-sm-10 col-md-10 col-lg-10">
                    <div class="dropdown">
                      <button id="id-moneda" class="btn btn-default dropdown-toggle" type="button" id="dropdownMoneda" data-toggle="dropdown" aria-expanded="true">
                        Moneda
                        <span class="caret"></span>
                      </button>
                      <ul id="dpmoneda" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                        <li role="presentation"><a role="menuitem" tabindex="-1" >Bs</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" >$</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" >€</a></li>
                      </ul>
                    </div>
                </div>
            </div>-->

            <div class="form-group">
                <div id="div_precio" class="col-sm-3 col-md-3 col-lg-3">
                       <input type="text" id="Precio" placeholder="Precio" class="form-control" name="precio"/>
                </div>
                <div id="div_activo" class="col-sm-3 col-md-3 col-lg-3 col-md-offset-4">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="switch-disabled" type="checkbox" checked data-on-text="Activo" data-on-color="success" data-off-text="Inactivo" disabled>
                </div>
	        </div>

            <div class="form-group">
		        <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-primary" onclick="return checkform()">Crear</button>
			    </div>
                <div class="col-sm-1 col-md-1 col-lg-1">
				    <button class="btn btn-default" onclick="return checkform()">Cancelar</button>
			    </div>
	        </div>
        </form>
    </div>
    <script src="js/Validacion.js"></script>
    <script src="bootstrap-switch-master/docs/js/bootstrap.min.js"></script>
    <script src="bootstrap-switch-master/docs/js/highlight.js"></script>
    <script src="bootstrap-switch-master/dist/js/bootstrap-switch.js"></script>
    <script src="bootstrap-switch-master/docs/js/main.js"></script>
    <script language="javascript">
         function fillCodigoTextField() {
             var codigoTextField = document.getElementById("Codigo");
             var nombreTextField = document.getElementById("Nombre");
             if (nombreTextField.value.length>=2) { //antes de llenar el codigo revisa si almenos tiene dos caracteres
                 codigoTextField.value = "";
                 var words = nombreTextField.value.split(" ");//crea una array de palabras del nombre del proyecto 
                 for (i in words) {
                     if (i < 3) {
                         temp = words[i];
                         codigoTextField.value = codigoTextField.value + temp.charAt(0).toUpperCase(); // va concatenando cada una de las primeras letras de las palabras en mayuscula.
                     }
                 }

                 codigoTextField.disabled = false; //al terminar se habilita el textfield para su posible edicion.
             }
         }
    </script>
    <script>
        $("#dpmoneda li a").click(function () {

            $("#id-moneda").html($(this).text() + ' <span class="caret"></span>');

        });
    </script>

</asp:Content>

