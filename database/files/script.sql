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

INSERT INTO "User" (Name, Email, Password, Role, Document)
  VALUES
('approver', 'approver@fakebank.lab', '123', 1, null),
('Naruto Uzumaki', 'narutouzumaki@internet.lab', '6a8047cda9f32487f243a3c3569bb84b', 0, 'a3a8c02dcnh-naruto.jpeg'),
('Sasuke Uchiha', 'sasukeuchiha@internet.lab', '6a8047cda9f32487f243a3c3569bb84b', 0, '674ea1e3069cnh-sasuke.jpeg'),
('Shikamaru Nara', 'shikamarunara@internet.lab', '6a8047cda9f32487f243a3c3569bb84b', 0, '13096995cnh-shikamaru.jpeg');

INSERT INTO "Simulation" (Description, Plots, Amount, UserId, CreatedAt, ApprovedAt)
  VALUES
('Chevrolet Celta LS 1.0 (Flex) 2p 2012', 48,  15786, 2, to_timestamp('2020-01-03 09:30:20','YYYY-MM-DD HH24:MI:SS'), to_timestamp('2020-01-28 15:00:20','YYYY-MM-DD HH24:MI:SS')),
('Chevrolet Celta LT 1.0 (Flex) 2012', 36,  20640 , 2, to_timestamp('2020-02-22 15:45:33','YYYY-MM-DD HH24:MI:SS'), to_timestamp('2020-02-27 17:50:10','YYYY-MM-DD HH24:MI:SS')),
('Fiat Palio Fire 1.0 8V (Flex) 4p', 48, 25990 , 3, to_timestamp('2020-06-20 12:20:30','YYYY-MM-DD HH24:MI:SS'), null),
('Fiat Palio Attractive 1.4 Evo (Flex)', 36,  27992 , 3, to_timestamp('2020-05-14 10:15:30','YYYY-MM-DD HH24:MI:SS'), to_timestamp('2020-06-22 17:50:10','YYYY-MM-DD HH24:MI:SS'));