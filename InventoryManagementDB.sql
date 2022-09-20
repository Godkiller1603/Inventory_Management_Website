--CREATE DATABASE InventoryManagementDB
--USE InventoryManagementDB

/*CREATE TABLE Products(
Product_ID int identity primary key,
Product_Name varchar(50) not null,
Product_Qnty varchar(5) not null
)*/

--select * from Products

CREATE TABLE Purchase(
id int identity primary key,
Purchase_Product varchar(50) not null,
Purchase_Qnty varchar(5) not null,
Purchase_Date Date not null
)

CREATE TABLE Sale(
id int identity primary key,
Sale_Product varchar(50) not null,
Sale_Qnty varchar(5) not null,
Sale_Date Date not null
)

select * from Products
select * from Purchase
select * from Sale