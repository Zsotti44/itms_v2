--------------------------------------------------------
--  File created - vas�rnap-m�jus-12-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure TRUCKLOGBYPLATENR
--------------------------------------------------------
set define off;

  CREATE OR REPLACE EDITIONABLE PROCEDURE "TESZT"."TRUCKLOGBYPLATENR" (truckNumber VARCHAR2)
AS
    countofSzerelveny NUMBER;
    countofNaplo NUMBER;
    truckID NUMBER;
    sumKM NUMBER;
    TRUCK_NF EXCEPTION;
    LOG_NF EXCEPTION;
BEGIN
-- Ellen�rizz�k l�tezik-e adott rendsz�m.
SELECT COUNT(*) INTO countofSzerelveny FROM szerelveny WHERE vontato = truckNumber;
IF countofszerelveny = 0 THEN RAISE TRUCK_NF; END IF;

--Lek�rj�k a szerelv�ny kulcs�t
SELECT ID INTO truckID FROM szerelveny where vontato = truckNumber;

--Megn�zz�k van-e hozz� kapcsol�d� rekord
SELECT COUNT(*) INTO countofNaplo FROM fuvarnaplo WHERE szerelvenyid = truckID;
IF countofNaplo = 0 THEN RAISE LOG_NF; END IF;
    DBMS_OUTPUT.PUT_LINE(RPAD('ID ',4) || '|' || RPAD(' Kamion',12) || '|' || RPAD(' Munka',40) || '|' || RPAD(' KM',7));
    DBMS_OUTPUT.PUT_LINE(RPAD('_',50,'_'));
    sumKM := 0;
FOR n IN (SELECT fn.id,sz.vontato,m.nev,m.kilometer FROM fuvarnaplo fn 
            INNER JOIN szerelveny sz ON szerelvenyid = sz.ID
            INNER JOIN munkak m ON munkaid = m.ID
            WHERE szerelvenyid = truckID order by fn.id
            )
    LOOP
    sumKM:= sumKM + n.kilometer;
    DBMS_OUTPUT.PUT_LINE(RPAD(n.ID,4) || '|' || RPAD(n.vontato,12) || '|' || RPAD(n.nev,40) || '|' || RPAD(n.kilometer,7));
END LOOP;
    DBMS_OUTPUT.PUT_LINE('A ' || truckNumber || ' forgalmi rendsz�m� kamion kil�m�ter fut�sa: ' || sumKM || 'km');

EXCEPTION
    WHEN TRUCK_NF
        THEN  DBMS_OUTPUT.PUT_LINE('Nincs ilyen kamion!!');
    WHEN LOG_NF 
        THEN  DBMS_OUTPUT.PUT_LINE('A kamionhoz nem kapcsol�dik teljes�tett munka!');
END;

/
