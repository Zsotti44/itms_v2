/*
Paraméterek
SzerelvényID
MunkaID
Munka_kezdő_dátum
Munka_befejező_dátum
*/
-- Dátum formátum beállítása
ALTER SESSION set nls_date_format = 'YYYY-MM-DD';

-- Nem létező szerelvény (53)
execute add_fuvarnaplo(53,1,'2024-05-04','2024-05-04');

-- Nem létező munka
execute add_fuvarnaplo(3,19,'2024-05-04','2024-05-04');

-- Nem ADR sofőr ADR Munkára
execute add_fuvarnaplo(3,6,'2024-05-04','2024-05-04');

