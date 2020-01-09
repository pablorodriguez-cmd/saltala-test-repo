/*CREACIÓN DE USUARIO Y PERMISOS*/
CREATE USER SALTALA IDENTIFIED BY saltala;
GRANT CONNECT, DBA, RESOURCE TO SALTALA


/*CREACIÓN DE TABLA*/
CREATE SEQUENCE seq_form_data START WITH 1 NOCACHE ORDER;

CREATE TABLE form_data (
    id                  INTEGER NOT NULL,
    name                VARCHAR2(250) NOT NULL,
    last_name           VARCHAR2(250) NOT NULL,
    register_reason     VARCHAR2(250),
    apply               CHAR(1) NOT NULL
);

ALTER TABLE form_data ADD CONSTRAINT form_data_pk PRIMARY KEY ( id );