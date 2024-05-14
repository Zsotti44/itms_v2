--------------------------------------------------------
--  File created - vasárnap-május-12-2024   
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
--Megnézzük létezik-e a sofõr
SELECT COUNT(*) INTO driver_found FROM soforok WHERE nev = sofornev;

-- Megvizsgáljuk, a találatok számát
IF driver_found = 0 THEN RAISE driver_NF; return null;
ELSIF driver_found > 1 THEN RAISE too_much_driver; return null;
END IF;

--Lekérjük a sofõr ID-ját
SELECT ID INTO soforID FROM soforok WHERE nev = sofornev;

--Megvizsgáljuk van-e hozzárendelve szerelvény
SELECT COUNT(*) INTO truck_found FROM szerelveny WHERE sofor = soforID;

-- Megvizsgáljuk, a találatok számát
IF truck_found = 0 THEN RAISE truck_NF; return null;
ELSIF truck_found > 1 THEN RAISE too_much_truck; return null;
END IF;

SELECT vontato,potkocsi INTO rendszam1,rendszam2 FROM szerelveny WHERE sofor = soforID;

--Visszatérünk az autóval
return rendszam1 || '/' || rendszam2;

EXCEPTION
    WHEN driver_NF THEN DBMS_OUTPUT.PUT_LINE('Sofõr nem található');
        return null;
    WHEN too_much_driver THEN DBMS_OUTPUT.PUT_LINE('Túl sok találat! Válassz másik keresõ megoldást!');
        return null;
    WHEN truck_NF THEN DBMS_OUTPUT.PUT_LINE('A sofõrhöz nincs autó rendelve!');
        return null;
    WHEN too_much_truck THEN DBMS_OUTPUT.PUT_LINE('A sofõrhöz több autó van rendelve!');
        return null;
    WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE(SQLERRM); 
            return null;
END;

/
