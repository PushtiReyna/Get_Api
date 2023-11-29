
CREATE DATABASE ApiGetDataDB

CREATE TABLE ApiGetDataMst(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    high float,
	low float,
	adj_high float,
	adj_low float
)