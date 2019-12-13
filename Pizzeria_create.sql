-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-12-12 00:23:22.029

-- tables
-- Table: Administrator
CREATE TABLE Administrator (
    id_Administrator int  NOT NULL,
    login varchar(30)  NOT NULL,
    password varchar(30)  NOT NULL,
    mail varchar(50)  NOT NULL,
    CONSTRAINT Administrator_pk PRIMARY KEY  (id_Administrator)
);

-- Table: Adres
CREATE TABLE Adres (
    id_Adres int  NOT NULL,
    Miasto varchar(50)  NOT NULL,
    Ulica varchar(50)  NOT NULL,
    Nr_domu int  NOT NULL,
    Nr_mieszkania int  NULL,
    CONSTRAINT Adres_pk PRIMARY KEY  (id_Adres)
);

-- Table: Dostawca
CREATE TABLE Dostawca (
    id_Dostawca int  NOT NULL,
    data_zatrudnienia date  NOT NULL,
    id_Persona int  NOT NULL,
    CONSTRAINT Dostawca_pk PRIMARY KEY  (id_Dostawca)
);

-- Table: Klient
CREATE TABLE Klient (
    id_Klient int  NOT NULL,
    numer_telefonu varchar(15)  NOT NULL,
    mail varchar(50)  NOT NULL,
    imie varchar(20)  NOT NULL,
    nazwisko varchar(40)  NOT NULL,
    id_Persona int  NOT NULL,
    CONSTRAINT Klient_pk PRIMARY KEY  (id_Klient)
);

-- Table: Persona
CREATE TABLE Persona (
    id_Persona int  NOT NULL,
    imie varchar(20)  NOT NULL,
    nazwisko varchar(40)  NOT NULL,
    CONSTRAINT Persona_pk PRIMARY KEY  (id_Persona)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id_Pizza int  NOT NULL,
    nazwa varchar(50)  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id_Pizza)
);

-- Table: Rodzaj
CREATE TABLE Rodzaj (
    id_Rodzaj int  NOT NULL,
    ilosc int  NOT NULL,
    id_Skladniki int  NOT NULL,
    id_Pizza int  NOT NULL,
    CONSTRAINT Rodzaj_pk PRIMARY KEY  (id_Rodzaj)
);

-- Table: Skladniki
CREATE TABLE Skladniki (
    id_Skladniki int  NOT NULL,
    nazwa varchar(20)  NOT NULL,
    cena decimal(3,2)  NOT NULL,
    CONSTRAINT Skladniki_pk PRIMARY KEY  (id_Skladniki)
);

-- Table: Szczegoly
CREATE TABLE Szczegoly (
    id_Pizza int  NOT NULL,
    id_Zamowienie int  NOT NULL,
    CONSTRAINT Szczegoly_pk PRIMARY KEY  (id_Pizza,id_Zamowienie)
);

-- Table: Zamowienie
CREATE TABLE Zamowienie (
    id_Zamowienie int  NOT NULL,
    data_zamowienia datetime  NOT NULL,
    platnosc varchar(50)  NOT NULL,
    cena decimal(4,2)  NOT NULL,
    Adres_id_Adres int  NOT NULL,
    Klient_id_Klient int  NOT NULL,
    uwagi varchar(250)  NOT NULL,
    CONSTRAINT Zamowienie_pk PRIMARY KEY  (id_Zamowienie)
);

-- Table: Zamowienie_dostawca
CREATE TABLE Zamowienie_dostawca (
    id_Dostawca int  NOT NULL,
    id_Zamowienie int  NOT NULL,
    CONSTRAINT Zamowienie_dostawca_pk PRIMARY KEY  (id_Dostawca,id_Zamowienie)
);

-- foreign keys
-- Reference: Dostawca_Osoba (table: Dostawca)
ALTER TABLE Dostawca ADD CONSTRAINT Dostawca_Osoba
    FOREIGN KEY (id_Persona)
    REFERENCES Persona (id_Persona);

-- Reference: Klient_Osoba (table: Klient)
ALTER TABLE Klient ADD CONSTRAINT Klient_Osoba
    FOREIGN KEY (id_Persona)
    REFERENCES Persona (id_Persona);

-- Reference: Rodzaj_Pizza (table: Rodzaj)
ALTER TABLE Rodzaj ADD CONSTRAINT Rodzaj_Pizza
    FOREIGN KEY (id_Pizza)
    REFERENCES Pizza (id_Pizza);

-- Reference: Rodzaj_Skladniki (table: Rodzaj)
ALTER TABLE Rodzaj ADD CONSTRAINT Rodzaj_Skladniki
    FOREIGN KEY (id_Skladniki)
    REFERENCES Skladniki (id_Skladniki);

-- Reference: Szczegoly_Pizza (table: Szczegoly)
ALTER TABLE Szczegoly ADD CONSTRAINT Szczegoly_Pizza
    FOREIGN KEY (id_Pizza)
    REFERENCES Pizza (id_Pizza);

-- Reference: Szczegoly_Zamowienie (table: Szczegoly)
ALTER TABLE Szczegoly ADD CONSTRAINT Szczegoly_Zamowienie
    FOREIGN KEY (id_Zamowienie)
    REFERENCES Zamowienie (id_Zamowienie);

-- Reference: Zamowienie_Adres (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Adres
    FOREIGN KEY (Adres_id_Adres)
    REFERENCES Adres (id_Adres);

-- Reference: Zamowienie_Klient (table: Zamowienie)
ALTER TABLE Zamowienie ADD CONSTRAINT Zamowienie_Klient
    FOREIGN KEY (Klient_id_Klient)
    REFERENCES Klient (id_Klient);

-- Reference: Zamowienie_dostawca_Dostawca (table: Zamowienie_dostawca)
ALTER TABLE Zamowienie_dostawca ADD CONSTRAINT Zamowienie_dostawca_Dostawca
    FOREIGN KEY (id_Dostawca)
    REFERENCES Dostawca (id_Dostawca);

-- Reference: Zamowienie_dostawca_Zamowienie (table: Zamowienie_dostawca)
ALTER TABLE Zamowienie_dostawca ADD CONSTRAINT Zamowienie_dostawca_Zamowienie
    FOREIGN KEY (id_Zamowienie)
    REFERENCES Zamowienie (id_Zamowienie);

-- End of file.

