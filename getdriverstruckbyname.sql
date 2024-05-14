--------------------------------------------------------
--  File created - vas�rnap-m�jus-12-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Function GETDRIVERSTRUCKBYNAME
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE FUNCTION "TESZT"."GETDRIVERSTRUCKBYNAME" (
    sofornev soforok.nev%TYPE
) RETURN VARCHAR2
IS
    soforID NUMBER;
    driver_found NUMBER;
    truck_found NUMBER;
    rendszam1 VARCHAR2(25);
    rendszam2 VARCHAR2(25);
    truck_NF EXCEPTION;
    driver_NF EXCEPTION;
    too_much_driver EXCEPTION;
    too_much_truck EXCEPTION;

BEGIN
--Megn�zz�k l�tezik-e a sof�r
SELECT COUNT(*) INTO driver_found FROM soforok WHERE nev = sofornev;

-- Megvizsg�ljuk, a tal�latok sz�m�t
IF driver_found = 0 THEN RAISE driver_NF; return null;
ELSIF driver_found > 1 THEN RAISE too_much_driver; return null;
END IF;

--Lek�rj�k a sof�r ID-j�t
SELECT ID INTO soforID FROM soforok WHERE nev = sofornev;

--Megvizsg�ljuk van-e hozz�rendelve szerelv�ny
SELECT COUNT(*) INTO truck_found FROM szerelveny WHERE sofor = soforID;

-- Megvizsg�ljuk, a tal�latok sz�m�t
IF truck_found = 0 THEN RAISE truck_NF; return null;
ELSIF truck_found > 1 THEN RAISE too_much_truck; return null;
END IF;

SELECT vontato,potkocsi INTO rendszam1,rendszam2 FROM szerelveny WHERE sofor = soforID;

--Visszat�r�nk az aut�val
return rendszam1 || '/' || rendszam2;

EXCEPTION
    WHEN driver_NF THEN DBMS_OUTPUT.PUT_LINE('Sof�r nem tal�lhat�');
        return null;
    WHEN too_much_driver THEN DBMS_OUTPUT.PUT_LINE('T�l sok tal�lat! V�lassz m�sik keres� megold�st!');
        return null;
    WHEN truck_NF THEN DBMS_OUTPUT.PUT_LINE('A sof�rh�z nincs aut� rendelve!');
        return null;
    WHEN too_much_truck THEN DBMS_OUTPUT.PUT_LINE('A sof�rh�z t�bb aut� van rendelve!');
        return null;
    WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE(SQLERRM); 
            return null;
END;

/
