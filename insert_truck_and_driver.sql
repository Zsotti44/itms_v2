CREATE OR REPLACE TRIGGER insert_truck_and_driver 
INSTEAD OF INSERT ON trucks_and_drivers
FOR EACH ROW 
DECLARE
    driver_found NUMBER;
    driver_attached NUMBER;
    driver_id szerelveny.sofor%TYPE;    
    driver_NF EXCEPTION;
    driver_DUPLICATION EXCEPTION;
    too_much_driver EXCEPTION;
BEGIN
SELECT COUNT(*) INTO driver_found FROM soforok WHERE nev = :new.driver;
IF driver_found = 0 THEN RAISE driver_NF;
ELSIF driver_found > 1 THEN RAISE too_much_driver;
END IF;

SELECT ID INTO driver_id FROM soforok WHERE nev = :new.driver;

SELECT COUNT(*) INTO driver_attached FROM szerelveny WHERE sofor = driver_id;
IF driver_attached != 0 THEN RAISE driver_DUPLICATION; END IF;

INSERT INTO szerelveny (Vontato,Potkocsi,Sofor) 
VALUES (:new.truck,'ABC123',driver_id);

EXCEPTION
        WHEN driver_NF THEN DBMS_OUTPUT.PUT_LINE('Ilyen nevű sofőr nem található!');
        WHEN driver_DUPLICATION THEN DBMS_OUTPUT.PUT_LINE('Ez a sofőr már hozzá van rendelve egy autóhoz!');
        WHEN too_much_driver THEN DBMS_OUTPUT.PUT_LINE('Túl sok ilyen nevű sofőr van, nem lehet beazanosítani!');

END;
/