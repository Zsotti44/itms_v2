CREATE OR REPLACE VIEW trucks_and_drivers(truck,driver)
AS SELECT sz.vontato as truck, s.nev as driver from 
szerelveny inner join soforok s on sz.sofor = s.id;


CREATE OR REPLACE TRIGGER insert_truck_and_driver 
INSTEAD OF INSERT ON trucks_and_drivers
FOR EACH ROW 
DECLARE
    driver_found NUMBER;
    driver_attached NUMBER;
    driver_id szerelveny.sofor%TYPE;    
    driver_NF EXCEPTION;
    driver_DUPLICATION EXCEPTION;
BEGIN
SELECT COUNT(*) INTO driver_found FROM soforok WHERE id = :new.sofor;
IF driver_found = 0 THEN RAISE driver_NF;

SELECT COUNT(*) INTO driver_attached FROM szerelveny WHERE sofor = :new.sofor;
IF driver_found != 0 THEN RAISE driver_DUPLICATION;

INSERT INTO szerelveny (Vontato,Potkocsi,Sofor) 
VALUES (:new.truck,'',(SELECT ID FROM soforok WHERE nev = :new.driver));

EXCEPTION
        WHEN driver_NF THEN DBMS_OUTPUT.PUT_LINE('');
        WHEN driver_DUPLICATION THEN DBMS_OUTPUT.PUT_LINE('');

END;
/

CREATE OR REPLACE TRIGGER update_truck_and_driver
INSTEAD OF UPDATE ON szerelveny
FOR EACH ROW
DECLARE
 driver_NF EXCEPTION;
 truck_NF EXCEPTION;
BEGIN


EXCEPTION
    WHEN truck_NF THEN DBMS_OUTPUT.PUT_LINE('');
    WHEN driver_NF THEN DBMS_OUTPUT.PUT_LINE('');
    WHEN driver_DUPLICATION THEN DBMS_OUTPUT.PUT_LINE('');

END;
/
