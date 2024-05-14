--------------------------------------------------------
--  File created - hétfõ-május-13-2024   
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
        changes := USER || ' új munkát regisztált a rendszerbe a következõ adatokkal: ID: ' 
        || :new.id || ', Név: '|| :new.nev || ', Leírás: '|| :new.leiras ||', KM: '|| :new.kilometer 
        ||', Díj: '|| :new.dij ||', ADR: '|| :new.ADR ||'';
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    ELSIF UPDATING THEN 
            changes := USER || ' módosította a(z) '|| :old.id || ' ID-vel rendelkezõ munkát. Változások:';
            IF :old.nev != :new.nev THEN changes := changes || ' | Név: ' || :old.nev || ' --> ' || :new.nev ||''; END IF;
            IF :old.leiras != :new.leiras THEN changes := changes || ' | Leírás: ' || :old.leiras || ' --> ' || :new.leiras ||''; END IF;
            IF :old.kilometer != :new.kilometer THEN changes := changes || ' | KM: ' || :old.kilometer || ' --> ' || :new.kilometer ||''; END IF;
            IF :old.dij != :new.dij THEN changes := changes || ' | Díj: ' || :old.dij || ' --> ' || :new.dij ||''; END IF;
            IF :old.adr != :new.adr THEN changes := changes || ' | ADR: ' || :old.adr || ' --> ' || :new.adr ||''; END IF;
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    ELSE 
        changes := USER || ' törölt egy munkát a rendszerbõl.(ID: '|| :old.id || ', Név: '|| :old.nev || ', Leírás: '|| :old.leiras ||', KM: '|| :old.kilometer ||', Díj: '|| :old.dij ||', ADR: '|| :old.ADR ||')';
        INSERT INTO NAPLO (sysUser, log_date, changes)
        values (USER, SYSDATE, changes);
    END IF;
	COMMIT;
END;

/
ALTER TRIGGER "TESZT"."MUNKA_NAPLO" ENABLE;
