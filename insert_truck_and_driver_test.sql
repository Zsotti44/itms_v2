-- Ilyen sofőr nem található
INSERT INTO trucks_and_drivers(truck,driver) VALUES ('AEMS778','Kiss Lajos Anton');

--Ez a sofőr már hozzá van rendelve egy autóhoz!
INSERT INTO trucks_and_drivers(truck,driver) VALUES ('AEMS778','Orlik Attila');

--Túl sok ilyen nevű sofőr van, nem lehet beazanosítani!
INSERT INTO trucks_and_drivers(truck,driver) VALUES ('AEMS778','Kiss László');

--Minden OK
INSERT INTO trucks_and_drivers(truck,driver) VALUES ('AEMS778','Jakab Imre László');
