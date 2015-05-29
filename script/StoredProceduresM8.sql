------------------ Procedimientos del M�dulo 8 ------------------------
------------------ Procedimientos para Agregar -----------------------

-------------------Procedimiento para Agregar una Minuta ----------------------
CREATE PROCEDURE Procedure_AgregarMinuta
		 
		@min_fecha   [datetime],
		@min_motivo  [varchar] (200),
		@min_observaciones 	[varchar] (500)
AS 
BEGIN
		INSERT INTO MINUTA(min_fecha, min_motivo, min_observaciones)
	    VALUES(@min_fecha ,@min_motivo ,@min_observaciones)
END;
GO

-------------------Procedimiento para Agregar un Punto ----------------------

CREATE PROCEDURE Procedure_AgregarPunto
		 
		@pun_titulo   [varchar] (100),
		@pun_desarrollo  [varchar] (400),
		@MINUTA_min_id 	[int]
AS 
BEGIN
		INSERT INTO PUNTO(pun_titulo, pun_desarrollo, MINUTA_min_id)
	    VALUES(@pun_titulo ,@pun_desarrollo ,@MINUTA_min_id)
END;
GO

-------------------Procedimiento para Agregar un Acuerdo ----------------------

CREATE PROCEDURE Procedure_AgregarAcuerdo
		 
		 
		@acu_fecha   [date],
		@acu_desarrollo  [varchar] (300),
		@MINUTA_min_id 	[int]
AS 
BEGIN

		INSERT INTO ACUERDO(acu_fecha, acu_desarrollo, MINUTA_min_id)
	    VALUES(@acu_fecha, @acu_desarrollo, @MINUTA_min_id);

		SELECT MAX(A.acu_id) as acu_id
		FROM ACUERDO A

END;
GO

CREATE PROCEDURE Procedure_AgregarResponsablesUsuarioDeAcuerdos
		 
		@acu_id   [int],
		@usu_id   [int],
		@pro_id   [int]
AS 
BEGIN

		INSERT INTO ACU_INV(ACUERDO_acu_id,INVOLUCRADOS_USUARIOS_USUARIO_usu_id,INVOLUCRADOS_USUARIOS_PROYECTO_pro_id)
	    VALUES(@acu_id, @usu_id, @pro_id );
END;
GO

CREATE PROCEDURE Procedure_AgregarResponsablesContactoDeAcuerdos
		
		@acu_id   [int],
		@con_id   [int],
		@pro_id   [int]
AS 
BEGIN

		INSERT INTO ACU_INV(ACUERDO_acu_id,INVOLUCRADOS_CLIENTES_CONTACTO_con_id,INVOLUCRADOS_CLIENTES_PROYECTO_pro_id)
	    VALUES(@acu_id, @con_id, @pro_id );
END;
GO
-------------------Procedimiento para Agregar un Involucrado Cliente ----------------------

CREATE PROCEDURE Procedure_AgregarInvolucradoCliente
		 
		@Minuta_min_id   [int],
		@con_id          [int],
		@con_pro_id      [int]
		
AS 
BEGIN
		INSERT INTO MIN_INV(MINUTA_min_id, INVOLUCRADOS_CLIENTES_CONTACTO_con_id, 
				    INVOLUCRADOS_CLIENTES_PROYECTO_pro_id)
	    VALUES(@Minuta_min_id, @con_id, @con_pro_id)
END;
GO

-------------------Procedimiento para Agregar un Involucrado Usuario ----------------------

CREATE PROCEDURE Procedure_AgregarInvolucradoUsuario
		 
		@Minuta_min_id   [int],
		@usu_id          [int],
		@usu_pro_id      [int]
		
AS 
BEGIN
		INSERT INTO MIN_INV(MINUTA_min_id, INVOLUCRADOS_USUARIOS_USUARIO_usu_id, 
		            INVOLUCRADOS_USUARIOS_PROYECTO_pro_id)
	    VALUES(@Minuta_min_id, @usu_id, @usu_pro_id)
END;
GO
------------------ Procedimientos para consultar------------------------------

------------------ Procedimiento para consultar las Minutas de un Proyecto----------------------

CREATE PROCEDURE Procedure_ConsultarMinutasProyecto
	
	@min_inv_proy [int]	
	   
AS
 BEGIN
	
	SELECT Distinct(M.min_id) as min_id, M.min_fecha, M.min_motivo
	FROM MINUTA M, MIN_INV MI
	WHERE (MI.INVOLUCRADOS_USUARIOS_PROYECTO_pro_id=1 or Mi.INVOLUCRADOS_CLIENTES_PROYECTO_pro_id = 1)
 END
GO

------------------ Procedimiento para consultar una Minuta en especifico----------------------

CREATE PROCEDURE Procedure_ConsultarMinuta
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT M.min_id, M.min_fecha, M.min_motivo, M.min_observaciones
	FROM MINUTA M
	WHERE M.min_id = @min_id
 END
GO

------------------ Procedimiento para consultar los puntos de una minuta----------------------
CREATE PROCEDURE Procedure_ConsultarPuntos
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT P.pun_id, P.pun_titulo, P.pun_desarrollo
	FROM PUNTO P
	WHERE P.MINUTA_min_id = @min_id
 END
GO

------------------ Procedimiento para consultar los Acuerdos de una minuta----------------------
CREATE PROCEDURE Procedure_ConsultarAcuerdos
	
	@min_id [int]	
	   
AS
 BEGIN
	
	SELECT A.acu_id, A.acu_fecha, A.acu_desarrollo
	FROM  ACUERDO A
	WHERE A.MINUTA_min_id = @min_id
 END
GO

------------------- Procedimiento para consultar los responsables tipo contacto de los Acuerdos de la una Minuta
CREATE PROCEDURE Procedure_ConsultarAcuerdoResponsablesContactoMinuta

	@acu_id [int]
	
AS
 BEGIN 

     SELECT AC.INVOLUCRADOS_CLIENTES_CONTACTO_con_id as idContacto
	 FROM ACU_INV AC
	 WHERE AC.ACUERDO_acu_id = @acu_id and AC.INVOLUCRADOS_CLIENTES_CONTACTO_con_id != null
END
GO

------------------- Procedimiento para consultar los responsables tipo usuario de los Acuerdos de la una Minuta
CREATE PROCEDURE Procedure_ConsultarAcuerdoResponsablesUsuarioMinuta

	@acu_id [int]
	
AS
 BEGIN 

     SELECT AC.INVOLUCRADOS_USUARIOS_USUARIO_usu_id as idUsuario
	 FROM ACU_INV AC
	 WHERE AC.ACUERDO_acu_id = @acu_id and AC.INVOLUCRADOS_USUARIOS_USUARIO_usu_id != null
END
GO
----------------- Procedimiento para consultar algunos datos de Contacto --------------------------------------
CREATE PROCEDURE Procedure_ConsultarContactoMinuta

       @acu_id [int],
	   @pro_id [int]
AS
 BEGIN
	
	SELECT C.con_id, C.con_nombre, C.con_apellido
	FROM  CONTACTO C, ACU_INV A
	WHERE A.ACUERDO_acu_id = @acu_id and A.INVOLUCRADOS_CLIENTES_PROYECTO_pro_id= @pro_id 
	      and A.INVOLUCRADOS_CLIENTES_CONTACTO_con_id = C.con_id
 END
GO

----------------- Procedimiento para consultar algunos datos de Usuario --------------------------------------
CREATE PROCEDURE Procedure_ConsultarUsuarioMinuta

       @acu_id [int],
	   @pro_id [int]
AS
 BEGIN
	
	SELECT U.usu_id, U.usu_nombre, U.usu_apellido
	FROM  USUARIO U , ACU_INV A
	WHERE A.ACUERDO_acu_id = @acu_id and A.INVOLUCRADOS_USUARIOS_PROYECTO_pro_id= @pro_id 
	      and A.INVOLUCRADOS_USUARIOS_USUARIO_usu_id = U.usu_id
 END
GO

----------------- Procedimiento para consutar los datos de un Usuario --------------------------
CREATE PROCEDURE Procedure_ConsultarUsuario

       @usu_id [int]
AS
 BEGIN

    SELECT U.usu_id, U.usu_nombre, U.usu_apellido
	FROM  USUARIO U
	WHERE U.usu_id = @usu_id
 END
GO

----------------- Procedimiento para consutar los datos de un Contacto --------------------------
CREATE PROCEDURE Procedure_ConsultarContacto

       @con_id [int]
AS
 BEGIN

    SELECT C.con_id, C.con_nombre, C.con_apellido
	FROM  CONTACTO C
	WHERE C.con_id = @con_id
 END
GO

-----------------Procedimientos para Modificar---------------------------------------------------
----------------- Procedimiento para modificar datos principales de una Minuta-------------------

CREATE PROCEDURE Procedure_ModificarMinuta
    
	@min_id [int],
	@min_fecha [datetime],
	@min_motivo [varchar](200),
	@min_observaciones [varchar](500)

AS
   UPDATE MINUTA
   SET 
       min_fecha = @min_fecha,
       min_motivo = @min_motivo,
	   min_observaciones = @min_observaciones
   WHERE
       min_id = @min_id;
GO

----------------- Procedimiento para modificar puntos

CREATE PROCEDURE Procedure_ModificarPunto

     @min_id [int],
	 @pun_id [int],
	 @pun_titulo [varchar](100),
	 @pun_desarrollo [varchar](400)
AS
BEGIN
   UPDATE PUNTO
   SET 
       pun_titulo = @pun_titulo,
	   pun_desarrollo = @pun_desarrollo
   WHERE
       MINUTA_min_id = @min_id and pun_id= @pun_id;
END
GO

---------------- Procedimiento para modificar un Acuerdo
CREATE PROCEDURE Procedure_ModificarAcuerdo

     @acu_id [int],
	 @acu_fecha [date],
	 @acu_desarrollo [varchar] (300),
	 @MINUTA_min_id [int]
AS
BEGIN
   UPDATE ACUERDO
   SET
       acu_fecha = @acu_fecha, 
	   acu_desarrollo = @acu_desarrollo ,
	   MINUTA_min_id = @MINUTA_min_id
   WHERE
       acu_id = @acu_id
END
GO

----------------- Procedimientos para Eliminar-----------------------
----------------- Procedimiento para Eliminar un Punto---------------

CREATE PROCEDURE Procedure_EliminarPunto

       @min_id [int],
	   @pun_id [int]

AS 
BEGIN
   DELETE FROM PUNTO
	   	WHERE MINUTA_min_id = @min_id and pun_id= @min_id
 
END
GO

-------------------- Procedimiento Eliminar Acuerdo
CREATE PROCEDURE Procedure_EliminarAcuerdo

       @acu_id [int]
AS
BEGIN
   DELETE FROM ACUERDO
          WHERE acu_id = @acu_id
END
GO

---------------- Procedimiento para Eliminar un Responsable Usuario de una Minuta
CREATE PROCEDURE Procedure_EliminarUsuarioAcuerdo

     @acu_id [int],
	 @usu_id [int],
	 @pro_id [int]

AS
BEGIN
   DELETE FROM ACU_INV 
   WHERE ACUERDO_acu_id = @acu_id and INVOLUCRADOS_USUARIOS_USUARIO_usu_id = @usu_id
   and INVOLUCRADOS_USUARIOS_PROYECTO_pro_id = @pro_id
END
GO

---------------- Procedimiento para Eliminar un Responsable Contacto de una Minuta
CREATE PROCEDURE Procedure_EliminarContactoAcuerdo

     @acu_id [int],
	 @con_id [int],
	 @pro_id [int]

AS
BEGIN
   DELETE FROM ACU_INV 
   WHERE ACUERDO_acu_id = @acu_id and INVOLUCRADOS_CLIENTES_CONTACTO_con_id = @con_id
   and INVOLUCRADOS_CLIENTES_PROYECTO_pro_id = @pro_id
END
GO
