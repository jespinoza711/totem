﻿CREATE
  TABLE ACTOR
  (
    act_id          INTEGER NOT NULL ,
    act_nombre      VARCHAR (100) NOT NULL ,
    act_descripcion VARCHAR (500) NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT ACTOR_PK PRIMARY KEY CLUSTERED (act_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ACUERDO
  (
    acu_id         INTEGER IDENTITY(1,1) NOT NULL ,
    acu_fecha      DATE NOT NULL ,
    acu_desarrollo VARCHAR (300) NOT NULL ,
	MINUTA_min_id  INTEGER NOT NULL ,
    CONSTRAINT ACUERDO_PK PRIMARY KEY CLUSTERED (acu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE ACU_INV
  (
    acu_inv_id INTEGER IDENTITY(1,1) NOT NULL,
	ACUERDO_acu_id INTEGER NOT NULL,
	INVOLUCRADOS_USUARIOS_USUARIO_usu_id  INTEGER,
    INVOLUCRADOS_USUARIOS_PROYECTO_pro_id INTEGER,
	INVOLUCRADOS_CLIENTES_CONTACTO_con_id INTEGER,
	INVOLUCRADOS_CLIENTES_PROYECTO_pro_id INTEGER,
    CONSTRAINT ACU_INV_PK PRIMARY KEY CLUSTERED (acu_inv_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CARGO
  (
    car_id     INTEGER NOT NULL ,
    car_nombre VARCHAR (60) NOT NULL ,
    CONSTRAINT CARGO_PK PRIMARY KEY CLUSTERED (car_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CASO_USO
  (
    cu_id            INTEGER NOT NULL ,
    cu_identificador VARCHAR (20) NOT NULL ,
    cu_titulo        VARCHAR (50) NOT NULL ,
    cu_condexito     VARCHAR (200) NOT NULL ,
    cu_condfallo     VARCHAR (200) NOT NULL ,
    cu_disparador    VARCHAR (200) NOT NULL ,
    CONSTRAINT CASO_USO_PK PRIMARY KEY CLUSTERED (cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CLIENTE_JURIDICO
  (
    cj_id        INTEGER NOT NULL ,
    cj_rif       VARCHAR (20) NOT NULL ,
    cj_nombre    VARCHAR (60) NOT NULL ,
    cj_logo      VARCHAR (60) ,
    LUGAR_lug_id INTEGER NOT NULL ,
    CONSTRAINT CLIENTE_JURIDICO_PK PRIMARY KEY CLUSTERED (cj_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CLIENTE_NATURAL
  (
    cn_id        INTEGER NOT NULL ,
	cn_cedula    VARCHAR (20) NOT NULL ,
    cn_nombre    VARCHAR (60) NOT NULL ,
    cn_apellido  VARCHAR (60) NOT NULL ,
    cn_correo    VARCHAR (60) NOT NULL ,
    LUGAR_lug_id INTEGER NOT NULL ,
    CONSTRAINT CLIENTE_NATURAL_PK PRIMARY KEY CLUSTERED (cn_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CONTACTO
  (
    con_id                 INTEGER NOT NULL ,
	con_cedula    		   VARCHAR (20) NOT NULL ,
    con_nombre             VARCHAR (100) NOT NULL ,
    con_apellido           VARCHAR (50) NOT NULL ,
    CLIENTE_JURIDICO_cj_id INTEGER,
    CARGO_car_id           INTEGER,
	CLIENTE_NATURAL_cn_id  INTEGER,
    CONSTRAINT CONTACTO_PK PRIMARY KEY CLUSTERED (con_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CU_ACTOR
  (
    CASO_USO_cu_id INTEGER NOT NULL ,
    ACTOR_act_id   INTEGER NOT NULL ,
    CONSTRAINT CU_ACTOR_PK PRIMARY KEY CLUSTERED (CASO_USO_cu_id, ACTOR_act_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE CU_REQUERIMIENTO
  (
    REQUERIMIENTO_req_id INTEGER NOT NULL ,
    CASO_USO_cu_id       INTEGER NOT NULL ,
    CONSTRAINT CU_REQUERIMIENTO_PK PRIMARY KEY CLUSTERED (REQUERIMIENTO_req_id,
    CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE EXTENSION
  (
    ext_id              INTEGER NOT NULL ,
    ext_descripcion     VARCHAR (500) NOT NULL ,
    PASO_pas_id         INTEGER NOT NULL ,
    PASO_CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT EXTENSION_PK PRIMARY KEY CLUSTERED (ext_id, PASO_pas_id,
    PASO_CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INVOLUCRADOS_CLIENTES
  (
    CONTACTO_con_id INTEGER NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT INVOLUCRADOS_CLIENTES_PK PRIMARY KEY CLUSTERED (CONTACTO_con_id,
    PROYECTO_pro_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE INVOLUCRADOS_USUARIOS
  (
    USUARIO_usu_id  INTEGER NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT INVOLUCRADOS_USUARIOS_PK PRIMARY KEY CLUSTERED (USUARIO_usu_id,
    PROYECTO_pro_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE LUGAR
  (
    lug_id           INTEGER NOT NULL ,
    lug_nombre       VARCHAR (100) NOT NULL ,
    lug_tipo         VARCHAR (40) NOT NULL ,
    lug_codigopostal INTEGER ,
    LUGAR_lug_id     INTEGER ,
    CONSTRAINT LUGAR_PK PRIMARY KEY CLUSTERED (lug_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE MINUTA
  (
    min_id            INTEGER IDENTITY(1,1) NOT NULL ,
    min_fecha         DATETIME NOT NULL ,
    min_motivo        VARCHAR (200) NOT NULL ,
    min_observaciones VARCHAR (500) ,
    CONSTRAINT MINUTA_PK PRIMARY KEY CLUSTERED (min_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE MIN_INV
  (
    min_inv_id INTEGER IDENTITY(1,1) NOT NULL,
    MINUTA_min_id                         INTEGER NOT NULL ,
    INVOLUCRADOS_USUARIOS_USUARIO_usu_id  INTEGER,
    INVOLUCRADOS_USUARIOS_PROYECTO_pro_id INTEGER,
	INVOLUCRADOS_CLIENTES_CONTACTO_con_id INTEGER,
	INVOLUCRADOS_CLIENTES_PROYECTO_pro_id INTEGER,
    CONSTRAINT MIN_INV_PK PRIMARY KEY CLUSTERED (min_inv_id, MINUTA_min_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PASO
  (
    pas_id         INTEGER NOT NULL ,
    pas_numpaso    VARCHAR (30) NOT NULL,
    pas_paso       VARCHAR (300) NOT NULL ,
    CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT PASO_PK PRIMARY KEY CLUSTERED (pas_id, CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PASO_EXTENSION
  (
    pe_id                        INTEGER NOT NULL ,
    pe_paso                      VARCHAR (300) NOT NULL ,
    EXTENSION_ext_id              INTEGER NOT NULL ,
    EXTENSION_PASO_pas_id         INTEGER NOT NULL ,
    EXTENSION_PASO_CASO_USO_cu_id INTEGER NOT NULL ,
    CONSTRAINT PASO_EXTENSION_PK PRIMARY KEY CLUSTERED (pe_id,
    EXTENSION_ext_id, EXTENSION_PASO_pas_id, EXTENSION_PASO_CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PRECONDICION
  (
    pre_id          INTEGER NOT NULL ,
    pre_descripcion VARCHAR (500) NOT NULL ,
    CASO_USO_cu_id  INTEGER NOT NULL ,
    CONSTRAINT PRECONDICION_PK PRIMARY KEY CLUSTERED (pre_id, CASO_USO_cu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PROYECTO
  (
    pro_id     INTEGER NOT NULL ,
    pro_codigo VARCHAR (6) NOT NULL ,
    pro_nombre VARCHAR (60) NOT NULL ,
    pro_estado BIT NOT NULL ,
    pro_descripcion VARCHAR (600) NOT NULL ,
    pro_costo       INTEGER NOT NULL ,
    pro_moneda      VARCHAR (3) NOT NULL ,
    CONSTRAINT PROYECTO_PK PRIMARY KEY CLUSTERED (pro_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE PUNTO
  (
    pun_id         INTEGER IDENTITY(1,1) NOT NULL ,
    pun_titulo     VARCHAR (100) NOT NULL ,
    pun_desarrollo VARCHAR (400),
	MINUTA_min_id  INTEGER  NOT NULL ,
    CONSTRAINT PUNTO_PK PRIMARY KEY CLUSTERED (pun_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE REQUERIMIENTO
  (
    req_id          INTEGER NOT NULL ,
    req_descripcion VARCHAR (500) NOT NULL ,
    req_tipo        VARCHAR (25) NOT NULL ,
    req_prioridad   VARCHAR (10) NOT NULL ,
    req_estatus     VARCHAR (50) NOT NULL ,
    PROYECTO_pro_id INTEGER NOT NULL ,
    CONSTRAINT REQUERIMIENTO_PK PRIMARY KEY CLUSTERED (req_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE TELEFONO
  (
    tel_id                INTEGER NOT NULL ,
    tel_codigo            INTEGER NOT NULL ,
    tel_numero            INTEGER NOT NULL ,
    CLIENTE_NATURAL_cn_id INTEGER ,
    CONTACTO_con_id       INTEGER ,
    CONSTRAINT TELEFONO_PK PRIMARY KEY CLUSTERED (tel_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

CREATE
  TABLE USUARIO
  (
    usu_id            INTEGER NOT NULL ,
    usu_username      VARCHAR (60) NOT NULL ,
    usu_clave         VARCHAR (60) NOT NULL ,
    usu_nombre        VARCHAR (60) NOT NULL ,
    usu_apellido      VARCHAR (60) NOT NULL ,
    usu_rol           VARCHAR (60) NOT NULL ,
    usu_correo        VARCHAR (60) NOT NULL ,
    usu_pregseguridad VARCHAR (80) NOT NULL ,
    usu_respseguridad VARCHAR (80) NOT NULL ,
    CARGO_car_id      INTEGER NOT NULL ,
    CONSTRAINT USUARIO_PK PRIMARY KEY CLUSTERED (usu_id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
  )
  ON "default"
GO

ALTER TABLE ACTOR
ADD CONSTRAINT ACTOR_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACUERDO
ADD CONSTRAINT ACUERDO_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_ACUERDO_FK FOREIGN KEY
(
ACUERDO_acu_id
)
REFERENCES ACUERDO
(
acu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_USUARIOS_FK FOREIGN KEY
(
INVOLUCRADOS_USUARIOS_USUARIO_usu_id,
INVOLUCRADOS_USUARIOS_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_USUARIOS
(
USUARIO_usu_id,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE ACU_INV
ADD CONSTRAINT ACU_INV_CLIENTES_FK FOREIGN KEY
(
INVOLUCRADOS_CLIENTES_CONTACTO_con_id,
INVOLUCRADOS_CLIENTES_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_CLIENTES
(
CONTACTO_con_id,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CLIENTE_JURIDICO
ADD CONSTRAINT CLIENTE_JURIDICO_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CLIENTE_NATURAL
ADD CONSTRAINT CLIENTE_NATURAL_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CARGO_FK FOREIGN KEY
(
CARGO_car_id
)
REFERENCES CARGO
(
car_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CLIENTE_JURIDICO_FK FOREIGN KEY
(
CLIENTE_JURIDICO_cj_id
)
REFERENCES CLIENTE_JURIDICO
(
cj_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


ALTER TABLE CONTACTO
ADD CONSTRAINT CONTACTO_CLIENTE_NATURAL_FK FOREIGN KEY
(
CLIENTE_NATURAL_cn_id
)
REFERENCES CLIENTE_NATURAL
(
cn_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_ACTOR
ADD CONSTRAINT CU_ACTOR_ACTOR_FK FOREIGN KEY
(
ACTOR_act_id
)
REFERENCES ACTOR
(
act_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_ACTOR
ADD CONSTRAINT CU_ACTOR_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_REQUERIMIENTO
ADD CONSTRAINT CU_REQUERIMIENTO_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE CU_REQUERIMIENTO
ADD CONSTRAINT CU_REQUERIMIENTO_REQUERIMIENTO_FK FOREIGN KEY
(
REQUERIMIENTO_req_id
)
REFERENCES REQUERIMIENTO
(
req_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE EXTENSION
ADD CONSTRAINT EXTENSION_PASO_FK FOREIGN KEY
(
PASO_pas_id,
PASO_CASO_USO_cu_id
)
REFERENCES PASO
(
pas_id ,
CASO_USO_cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_CLIENTES
ADD CONSTRAINT INVOLUCRADOS_CLIENTES_CONTACTO_FK FOREIGN KEY
(
CONTACTO_con_id
)
REFERENCES CONTACTO
(
con_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_CLIENTES
ADD CONSTRAINT INVOLUCRADOS_CLIENTES_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_USUARIOS
ADD CONSTRAINT INVOLUCRADOS_USUARIOS_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE INVOLUCRADOS_USUARIOS
ADD CONSTRAINT INVOLUCRADOS_USUARIOS_USUARIO_FK FOREIGN KEY
(
USUARIO_usu_id
)
REFERENCES USUARIO
(
usu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE LUGAR
ADD CONSTRAINT LUGAR_LUGAR_FK FOREIGN KEY
(
LUGAR_lug_id
)
REFERENCES LUGAR
(
lug_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_INVOLUCRADOS_USUARIOS_FK FOREIGN KEY
(
INVOLUCRADOS_USUARIOS_USUARIO_usu_id,
INVOLUCRADOS_USUARIOS_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_USUARIOS
(
USUARIO_usu_id ,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE MIN_INV
ADD CONSTRAINT MIN_INV_INVOLUCRADOS_CLIENTES_FK FOREIGN KEY
(
INVOLUCRADOS_CLIENTES_CONTACTO_con_id,
INVOLUCRADOS_CLIENTES_PROYECTO_pro_id
)
REFERENCES INVOLUCRADOS_CLIENTES
(
CONTACTO_con_id ,
PROYECTO_pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PASO
ADD CONSTRAINT PASO_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PASO_EXTENSION
ADD CONSTRAINT PASO_EXTENSION_EXTENSION_FK FOREIGN KEY
(
EXTENSION_ext_id,
EXTENSION_PASO_pas_id,
EXTENSION_PASO_CASO_USO_cu_id
)
REFERENCES EXTENSION
(
ext_id ,
PASO_pas_id ,
PASO_CASO_USO_cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PRECONDICION
ADD CONSTRAINT PRECONDICION_CASO_USO_FK FOREIGN KEY
(
CASO_USO_cu_id
)
REFERENCES CASO_USO
(
cu_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE PUNTO
ADD CONSTRAINT PUNTO_MINUTA_FK FOREIGN KEY
(
MINUTA_min_id
)
REFERENCES MINUTA
(
min_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE REQUERIMIENTO
ADD CONSTRAINT REQUERIMIENTO_PROYECTO_FK FOREIGN KEY
(
PROYECTO_pro_id
)
REFERENCES PROYECTO
(
pro_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TELEFONO
ADD CONSTRAINT TELEFONO_CLIENTE_NATURAL_FK FOREIGN KEY
(
CLIENTE_NATURAL_cn_id
)
REFERENCES CLIENTE_NATURAL
(
cn_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE TELEFONO
ADD CONSTRAINT TELEFONO_CONTACTO_FK FOREIGN KEY
(
CONTACTO_con_id
)
REFERENCES CONTACTO
(
con_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE USUARIO
ADD CONSTRAINT USUARIO_CARGO_FK FOREIGN KEY
(
CARGO_car_id
)
REFERENCES CARGO
(
car_id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO