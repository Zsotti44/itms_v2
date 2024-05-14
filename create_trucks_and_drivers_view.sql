CREATE OR REPLACE VIEW trucks_and_drivers(truck,driver)
AS SELECT sz.vontato as truck, s.nev as driver from 
szerelveny sz inner join soforok s on sz.sofor = s.id;
