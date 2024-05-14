-- Timestamp beállítása
ALTER SESSION set nls_timestamp_format  = 'YYYY-MM-DD HH24:MI:SS';

-- Insert 
Insert into MUNKAK (NEV,LEIRAS,KILOMETER,DIJ,ADR) values ('VÁCRÁTÓT - Samsung SDI (Göd)','ADR alapanyag szállítás vácrátóról - Gödre. ','25','25000','1');
-- Update
update munkak set leiras='KÜLÖNÖSEN!!!!! VESZÉLYES ADR alapanyag szállítás vácról - Gödre. '  where id=6;
-Delete
delete from munkak where id = 4;

-- Log
SELECT * FROM naplo;
