--------------------------------------------------------
--  File created - vasárnap-május-12-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Procedure ADD_FUVARNAPLO
--------------------------------------------------------
set define off;

  CREATE OR REPLACE EDITIONABLE PROCEDURE "TESZT"."ADD_FUVARNAPLO" (szerelveny_id fuvarnaplo.szerelvenyID%TYPE,
                                           munka_id fuvarnaplo.munkaID%TYPE,
                                           kezdes_datum DATE,
                                           befejezes_datum DATE) AS 
    munka_adr munkak.ADR%TYPE;
    sofor_id soforok.ID%TYPE;
    sofor_adr soforok.ADR%TYPE;
    munka_talalat NUMBER(3);
    szerelveny_talalat NUMBER(3);
    szerelveny_sum NUMBER(10);
    munka_sum NUMBER(10);
    szerelveny_NF EXCEPTION;
    MUNKA_NF EXCEPTION;
    SOFOR_NOT_ADR EXCEPTION;
BEGIN
    /* Szerelvény létezik-e?*/
    SELECT count(*) into szerelveny_talalat from szerelveny WHERE id = szerelveny_id;
    IF szerelveny_talalat < 1 THEN RAISE szerelveny_NF; END IF;

    /* Munka létezik-e?*/
    SELECT count(*) into munka_talalat from MUNKAK WHERE id = munka_id;
    IF munka_talalat < 1 THEN RAISE MUNKA_NF; END IF;

    /* Sofor megfelel-e?*/
    SELECT sofor into sofor_id from szerelveny WHERE id = szerelveny_id;
    SELECT ADR into munka_adr from munkak WHERE id = munka_id;
    SELECT ADR into sofor_adr from SOFOROK WHERE id = sofor_id;
    IF (munka_adr = 1 and sofor_adr = 0) THEN RAISE SOFOR_NOT_ADR; END IF;

    /* Besúrás */
   INSERT INTO FUVARNAPLO (munkaid,szerelvenyid,kezdes_datum,befejezes_datum) VALUES (munka_id,szerelveny_id,kezdes_datum,befejezes_datum);


    /*Visszajelzés */
    SELECT COUNT(*) into szerelveny_sum from fuvarnaplo WHERE fuvarnaplo.szerelvenyid = szerelveny_id;
    SELECT COUNT(*) into munka_sum from fuvarnaplo WHERE  fuvarnaplo.munkaid = munka_id;

     dbms_output.put_line('Szerelvény munkáinak száma: ' || szerelveny_sum || ' db' );
     dbms_output.put_line('Munka eddigi teljesítései: ' || munka_sum || ' db' );
 COMMIT;

EXCEPTION
    WHEN szerelveny_NF
        THEN dbms_output.put_line('Nincs ilyen szerelvény!!');
    WHEN munka_NF
        THEN dbms_output.put_line('Nincs ilyen munka!!');
    WHEN SOFOR_NOT_ADR
        THEN dbms_output.put_line('A megadott munkához ADR képes sofõr szükséges!!');
END;

/
