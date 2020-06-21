CREATE TABLE "User" (
  Id SERIAL,
  Name VARCHAR(100), 
  Email VARCHAR(100), 
  Password VARCHAR(100),
  Role INT,
  Document VARCHAR(200)
);

CREATE TABLE "Simulation" (
  Id SERIAL,
  Description VARCHAR(200),
  Plots INT,
  Amount DECIMAL,
	UserId INT,
  CreatedAt TIMESTAMP,
  ApprovedAt TIMESTAMP
);

CREATE TABLE "Contact" (
  Id SERIAL,
  Name VARCHAR(100),
  Email VARCHAR(200),
  Message VARCHAR(200)
);

INSERT INTO "User" (Name, Email, Password, Role) VALUES ('approver', 'approver@fakebank.lab', '123', 1);