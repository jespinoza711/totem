﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallarCliente.aspx.cs" Inherits="Vista.Modulo2.DetallarCliente" %>
<%@ MasterType  virtualPath="~/Master/MasterPage.master"%> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <!-- Custom CSS for input[type="file"] -->
    <link href="<%= Page.ResolveUrl("~/src/GUI/Modulo2/css/agregar-cliente.css") %>" rel="stylesheet" />

    <!-- Custom JS for dropdown items -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/dropdown-ac.js") %>"></script>

    <!-- Custom JS for Bootstrap Validation -->
    <script type="text/javascript" src="<%= Page.ResolveUrl("~/src/GUI/Modulo2/js/validation.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">
    Gestión de Clientes 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">
    Detallar Cliente Natural 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
     <div id="alert" runat ="server"> </div>
    <div class="col-sm-8 col-md-8 col-lg-8 col-md-offset-2">
        <form id="agregar_cliente" class="form-horizontal" action="#" method="post" Runat="Server">

            <div class="row col-sm-12 col-md-12 col-lg-12">
                
                <h2>Datos Básicos</h2>
                
                <div class="form-group">
                    <div id="div_nombre" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="nombreCliente"  runat="server" name="nombre" class="form-control"/>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_apellido" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="apellidoCliente" runat="server" name="apellido" type="text" class="form-control" />
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_rif" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="cedulaCliente" runat="server" name="rif" type="text" class="form-control"/>
                    </div>
                </div>

                 <h2>Datos De Localización</h2>

                <div class="form-group">
                            <div id="div_pais" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboPais">
                                <asp:Label id="pais" runat="server" name="pais" type="text" class="form-control"/>
                                </div>
                            </div>

                            <div id="div_estado" class="col-sm-6 col-md-6 col-lg-6">
                                <div class="dropdown" runat="server" id="contenedorComboEstado">
                               <asp:Label id="estado" runat="server" name="estado" type="text" class="form-control"/>
                                </div>
                            </div>
                     </div>
                     <div class="form-group">
                            <div id="div_ciudad" class="col-sm-12 col-md-12 col-lg-12">
                                <div class="dropdown" runat="server" id="Div1">
                                <asp:Label id="ciudad" runat="server" name="ciudad" type="text" class="form-control"/>
                                </div>
                            </div>
                     </div>
                    
              
                <div class="form-group">
                    <div id="div_direccion" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="direccion" runat="server" name="direccion" type="text" class="form-control"/>
                    </div>
                </div>
                <div class="form-group">
                    <div id="div_cpostal" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="codpostal" runat="server" name="codpostal" type="text" class="form-control"/>
                    </div>
                </div>
               
                    <div class="form-group">
                        <div id="div_correo" class="col-sm-12 col-md-12 col-lg-12">
                            <asp:Label id="correocliente" runat="server" name="correocliente" type="text" class="form-control"/>
                        </div>
                    </div>

                    <div class="form-group">
    
                    <div id="div_telefono" class="col-sm-12 col-md-12 col-lg-12">
                        <asp:Label id="telefono" runat="server" name="telefono" type="text" class="form-control"/>
                    </div>
                </div>
     
                <div class="form-group">
                    <div id="div_botones" class="col-sm-12 col-md-12 col-lg-12">
                        <a class="btn btn-default" href="ListarClientes.aspx">Volver</a>
                    </div>
                </div>
            </div>
            </form>
</div>
</asp:Content>

