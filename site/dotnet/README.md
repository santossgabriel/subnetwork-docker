1. Install entity framework core tools (CLI)
dotnet tool install --global dotnet-ef

2. Scripts de banco
```sql
CREATE USER vwat WITH PASSWORD '123';
CREATE DATABASE vwat WITH  OWNER = 'vwat' ENCODING = 'UTF8' TABLESPACE = pg_default CONNECTION LIMIT = -1;
CREATE TABLE "Comment" ("Id" SERIAL, "Description" VARCHAR);
CREATE TABLE "User" ("Id" SERIAL, "Name" VARCHAR, "Email" VARCHAR, "Password" VARCHAR);
INSERT INTO "User" ("Name", "Email", "Password") VALUES ('admin', 'admin@mail.com', 'admin123');
INSERT INTO "User" ("Name", "Email", "Password") VALUES ('contact', 'contact@mail.com', 'contact123');
```