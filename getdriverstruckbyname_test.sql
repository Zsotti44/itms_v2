DECLARE
    teszt VARCHAR2(25);
BEGIN

--Nem létező sofőr
teszt := getDriversTruckByName('Kiss Béla');
--Több autó van hozzárendelve
teszt := getDriversTruckByName('Orlik Attila');
--Nincs autó hozzárendelve
teszt := getDriversTruckByName('Kiss János');
--Minden OK!
teszt := getDriversTruckByName('Dénes György');
DBMS_OUTPUT.PUT_LINE(teszt);
END;
/