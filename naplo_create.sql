--------------------------------------------------------
--  File created - hétfõ-május-13-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table NAPLO
--------------------------------------------------------

  CREATE TABLE "TESZT"."NAPLO" 
   (	"ID" NUMBER, 
	"SYSUSER" VARCHAR2(65 BYTE), 
	"LOG_DATE" TIMESTAMP (6), 
	"CHANGES" VARCHAR2(1024 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
