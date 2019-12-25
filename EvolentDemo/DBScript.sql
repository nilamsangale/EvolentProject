create database EvolentHealthDemo

use EvolentHealthDemo

create table Contacts
(
ContactId int primary key identity(1,1),
FirstName nvarchar(20),
LastName nvarchar(20),
Email nvarchar(50),
PhoneNumber nvarchar(20),
Status bit not null default 0
)
