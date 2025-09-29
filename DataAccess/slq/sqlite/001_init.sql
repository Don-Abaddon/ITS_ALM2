-- Muy importante en SQLite: habilitar FKs
PRAGMA foreign_keys = ON;

-- Tablas base (referenciadas)
CREATE TABLE IF NOT EXISTS MakeList (
    Make_ID     INTEGER PRIMARY KEY AUTOINCREMENT,
    Make_Name   TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS ModelsList (
    Model_ID    INTEGER PRIMARY KEY AUTOINCREMENT,
    Model_Name  TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS StatusList (
    PC_Status_ID    INTEGER PRIMARY KEY AUTOINCREMENT,
    PC_Status_Name  TEXT NOT NULL UNIQUE
);

-- Tabla principal
CREATE TABLE IF NOT EXISTS Masterlist (
    Num_Propiedad   INTEGER PRIMARY KEY,
    Make_ID         INTEGER NOT NULL,
    Model_ID        INTEGER NOT NULL,
    Service_Tag     TEXT NOT NULL,    -- SQLite ignora longitudes de VARCHAR; TEXT es correcto
    PC_Status_ID    INTEGER NOT NULL,

    FOREIGN KEY (Make_ID)      REFERENCES MakeList(Make_ID),
    FOREIGN KEY (Model_ID)     REFERENCES ModelsList(Model_ID),
    FOREIGN KEY (PC_Status_ID) REFERENCES StatusList(PC_Status_ID)
);

-- (Opcional) Índices para acelerar joins/búsquedas por FK
CREATE INDEX IF NOT EXISTS IX_Masterlist_Make   ON Masterlist (Make_ID);
CREATE INDEX IF NOT EXISTS IX_Masterlist_Model  ON Masterlist (Model_ID);
CREATE INDEX IF NOT EXISTS IX_Masterlist_Status ON Masterlist (PC_Status_ID);
CREATE UNIQUE INDEX IF NOT EXISTS UX_MakeList_Name   ON MakeList (Make_Name);
CREATE UNIQUE INDEX IF NOT EXISTS UX_ModelsList_Name ON ModelsList (Model_Name);
CREATE UNIQUE INDEX IF NOT EXISTS UX_StatusList_Name ON StatusList (PC_Status_Name);
