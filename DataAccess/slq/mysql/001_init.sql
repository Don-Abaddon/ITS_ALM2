create table Masterlist (
	Num_Propiedad INT primary key, 
    Make_ID INT NOT NULL, 
    Model_ID INT NOT NULL,
    Service_Tag VARCHAR(10) NOT NULL,
    PC_Status_ID INT NOT NULL,
    
    FOREIGN KEY (Make_ID) REFERENCES MakeList(Make_ID),
    FOREIGN KEY (Model_ID) REFERENCES ModelsList(Model_ID),
    FOREIGN KEY (PC_Status_ID) REFERENCES StatusList(PC_Status_ID)
); 
------------------------------------------------------------------------------------------

Create table MakeList (
	Make_ID INT auto_increment primary key,
    Make_Name VARCHAR(50) NOT NULL Unique
); 
------------------------------------------------------------------------------------------

create table ModelsList (
	Model_ID INT auto_increment primary key,
    Model_Name VARCHAR(50) NOT NULL Unique    
); 
------------------------------------------------------------------------------------------

create table StatusList (
	PC_Status_ID INT auto_increment primary key,
    PC_Status_Name VARCHAR(50) NOT NULL Unique
);