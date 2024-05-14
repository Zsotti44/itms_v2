--------------------------------------------------------
--  File created - h�tf�-m�jus-13-2024   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Trigger MUNKA_NAPLO
--------------------------------------------------------

  CREATE OR REPLACE EDITIONABLE TRIGGER "TESZT"."MUNKA_NAPLO" 
AFTER INSERT OR UPDATE OR DELETE ON MUNKAK
FOR EACH ROW
DECLARE
    changes VARCHAR2(1024);
BEGIN
    IF INSERTING THEN
        changes := USER || ' �j munk�t regiszt�lt a rendszerbe a k�vetkez� adatokkal: ID: ' 
        || :new.id || ', N�v: '|| :new.nev || ', Le�r�s: '|| :new.leiras ||', KM: '|| :new.kilometer 
        ||', D�j: '|| :new.dij ||', ADR: '|| :new.ADR ||'';
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    ELSIF UPDATING THEN 
            changes := USER || ' m�dos�totta a(z) '|| :old.id || ' ID-vel rendelkez� munk�t. V�ltoz�sok:';
            IF :old.nev != :new.nev THEN changes := changes || ' | N�v: ' || :old.nev || ' --> ' || :new.nev ||''; END IF;
            IF :old.leiras != :new.leiras THEN changes := changes || ' | Le�r�s: ' || :old.leiras || ' --> ' || :new.leiras ||''; END IF;
            IF :old.kilometer != :new.kilometer THEN changes := changes || ' | KM: ' || :old.kilometer || ' --> ' || :new.kilometer ||''; END IF;
            IF :old.dij != :new.dij THEN changes := changes || ' | D�j: ' || :old.dij || ' --> ' || :new.dij ||''; END IF;
            IF :old.adr != :new.adr THEN changes := changes || ' | ADR: ' || :old.adr || ' --> ' || :new.adr ||''; END IF;
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    ELSE 
        changes := USER || ' t�r�lt egy munk�t a rendszerb�l.(ID: '|| :old.id || ', N�v: '|| :old.nev || ', Le�r�s: '|| :old.leiras ||', KM: '|| :old.kilometer ||', D�j: '|| :old.dij ||', ADR: '|| :old.ADR ||')';
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    END IF;
	COMMIT;
END;

/
ALTER TRIGGER "TESZT"."MUNKA_NAPLO" ENABLE;
