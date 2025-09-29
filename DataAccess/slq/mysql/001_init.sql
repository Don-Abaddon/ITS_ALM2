-- Tablas base (referenciadas)
CREATE TABLE IF NOT EXISTS MakeList (
    Make_ID     INT AUTO_INCREMENT PRIMARY KEY,
    Make_Name   VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS ModelsList (
    Model_ID    INT AUTO_INCREMENT PRIMARY KEY,
    Model_Name  VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS StatusList (
    PC_Status_ID    INT AUTO_INCREMENT PRIMARY KEY,
    PC_Status_Name  VARCHAR(50) NOT NULL UNIQUE
) ENGINE=InnoDB;

-- Tabla principal
CREATE TABLE IF NOT EXISTS Masterlist (
    Num_Propiedad   INT PRIMARY KEY,
    Make_ID         INT NOT NULL,
    Model_ID        INT NOT NULL,
    Service_Tag     VARCHAR(10) NOT NULL,
    PC_Status_ID    INT NOT NULL,

    CONSTRAINT FK_Masterlist_Make
        FOREIGN KEY (Make_ID)      REFERENCES MakeList(Make_ID),
    CONSTRAINT FK_Masterlist_Model
        FOREIGN KEY (Model_ID)     REFERENCES ModelsList(Model_ID),
    CONSTRAINT FK_Masterlist_Status
        FOREIGN KEY (PC_Status_ID) REFERENCES StatusList(PC_Status_ID)
) ENGINE=InnoDB;

-- (Opcional) Índices para acelerar joins/búsquedas por FK
CREATE INDEX IX_Masterlist_Make   ON Masterlist (Make_ID);
CREATE INDEX IX_Masterlist_Model  ON Masterlist (Model_ID);
CREATE INDEX IX_Masterlist_Status ON Masterlist (PC_Status_ID);
