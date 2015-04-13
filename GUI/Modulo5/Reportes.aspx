﻿<%@ Page Title="" Language="C#" MasterPageFile="~/GUI/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Reportes.aspx.cs" Inherits="GUI_Modulo5_RFuncionalesID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="titulo" Runat="Server">Gestión de Requerimientos<br /></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="subtitulo" Runat="Server">Reporte de Requerimientos</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenidoCentral" Runat="Server">
    <div class="col-lg-offset-11"\>
        <button class="btn btn-default">Imprimir</button>
    </div>
    <br />
    <div class="col-lg-12">
    <h4>Seleccione el tipo de requerimiento con el cual desea filtrar el reporte</h4>
    <div class="dropdown">
        <button class="btn btn-default dropdown-toggle" type="button" id="tipoid" data-toggle="dropdown" aria-expanded="true">
        Tipo de Requerimiento:
        <span class="caret"></span>
        </button>
        <ul id="tipo-dd" class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
            <li id="funcionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos Funcionales</a></li>
            <li id="nofuncionales" role="presentation"><a role="menuitem" tabindex="-1" href="#" >Requerimientos No Funcionales</a></li>
        </ul>
    </div>
    <br />
    <br />
    <div class="table-responsive">
	    		<table id="table-example" class="table table-striped table-hover">
			<thead>
				<tr>
					<th>ID</th>
					<th>Requerimiento</th>
					<th>Tipo</th>
					<th>Prioridad</th>
					<th>Acciones</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td class="id">TOT_RF_1</td>
					<td style="width: 530px">El sistema deberá permitir agregar, modificar y eliminar requerimientos, solo cuando valide que el proyecto se encuentra activo.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RF_2</td>
					<td style="width: 530px">El sistema deberá permitir la modificación de los campos de descripción y prioridad de los requerimientos funcionales y no funcionales previamente asociados a un proyecto dado.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
				</tr><tr>
                    <td>TOT_RF_3</td>
					<td style="width: 530px">El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RF_4</td>
					<td style="width: 530px">El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td>TOT_RF_5</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RF_6</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td class="Type">Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr><tr>
                    <td>TOT_RNF_1</td>
					<td style="width: 530px">El sistema deberá permitir eliminar los requerimientos funcionales y no funcionales de un proyecto.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                    <td>TOT_RNF_2</td>
					<td style="width: 530px">El sistema deberá permitir buscar requerimientos funcionales y no funcionales, por ID y por descripción, que se encuentran asociados a un proyecto en específico.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                     </td>
                </tr>
                <tr>
                <td>TOT_RNF_3</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por ID.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
                <tr>
                <td>TOT_RNF_4</td>
					<td style="width: 530px">El sistema deberá permitir consultar la lista de requerimientos funcionales, asociados a un proyecto en específico, organizada por su prioridad.</td>
					<td class="Type">No Funcional</td>
					<td  style="width: 50px">Alta</td>
                    <td>
                        <a class="btn btn-default glyphicon glyphicon-pencil" data-toggle="modal" data-target="#modal-update" href="#"></a>
                        <a class="btn btn-danger glyphicon glyphicon-remove-sign" data-toggle="modal" data-target="#modal-delete" href="#"></a>
                    </td>
                </tr>
			</tbody>
		</table>
        <div id="modal-delete" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Eliminaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <div class="row">
                    <p>Seguro que desea eliminar el requerimiento:</p>
                    <p id="req"></p>
                </div>
              </div>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
              <button id="btn-eliminar" type="button" class="btn btn-primary" onclick="EliminarRequerimiento()">Eliminar</button>
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
      <div id="modal-update" class="modal fade" role="dialog" aria-labelledby="gridSystemModalLabel" aria-hidden="true">
        <div class="modal-dialog">
          <div class="modal-content">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
              <h4 class="modal-title" >Modificaci&oacute;n de Requerimiento</h4>
            </div>
            <div class="modal-body">
              <div class="container-fluid">
                <form id="modificar_requerimientos" class="form-horizontal" method="post">
                    <div class="form-group">
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;<b>Tipo de Requerimiento:</b></p>
                        &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio1" checked="checked"/>Funcional</label>
                        <label class="radio-inline">
                        <input type="radio" name="optradio1"/>No Funcional</label>
                    </div>
                    <br/>
                    <div class="row">
                        <div class="col-lg-9">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon">El sistema deberá </span>
                                    <textarea class="form-control" rows="3" placeholder="Funcionalidad del requerimiento" style="text-align: justify;resize:vertical;" name="requerimiento">agregar usuarios</textarea>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                        <div class="form-group">
                            <p>&nbsp;&nbsp;&nbsp;&nbsp;<b>Prioridad:</b></p>
                            &nbsp;&nbsp;&nbsp;&nbsp;<label class="radio-inline"><input type="radio" name="optradio"/>Baja</label>
                            <label class="radio-inline">
                            <input type="radio" name="optradio" checked="checked"/>Media</label>
                            <label class="radio-inline">
                            <input type="radio" name="optradio"/>Alta</label>
                        </div>
                    <br />
                </form>
              </div>
            </div>
            <div class="modal-footer">
              <a class="btn btn-primary" href="ListarRequerimientos.aspx?success=2">Modificar</a>
              <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
    </div>
    <!-- Data tables init -->
	<script type="text/javascript">
	    jQuery(function ($) {
	        $('#table-example').DataTable();
	    });
	    $('#modal-delete').on('show.bs.modal', function (event) {
	        var modal = $(this)
	        modal.find('.modal-title').text('Eliminar requerimiento:  ' + req)
	        modal.find('#req').text(req)
	    })
	    $('#btn-eliminar').on('click', function () {
	        table.row(tr).remove().draw();//se elimina la fila de la tabla
	        $('#modal-delete').modal('hide');//se esconde el modal
	    });
	    $('#modal-update').on('show.bs.modal', function (event) {
	        var modal = $(this)
	        modal.find('.modal-title').text('Modificar requerimiento')
	    });
	</script>
    <script type="text/javascript">
        $('#funcionales').click(function () {
            var busqueda = 'Funcional';

            $('tr').hide();

            $('tr td.Type').each(function () {

                if ($(this).text() == busqueda) {

                    $(this).parent().show();
                }
            });

        });
        $("#tipo-dd li a").click(function () {

            $("#tipoid").html($(this).text() + ' <span class="caret"></span>');

        });
        $('#nofuncionales').click(function () {
            var busqueda = 'No Funcional';

            $('tr').hide();

            $('tr td.Type').each(function () {

                if ($(this).text() == busqueda) {

                    $(this).parent().show();
                }
            });

        });
	</script>
    </div>
</asp:Content>
