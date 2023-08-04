# Primary/foreign keys and indices

## Create normalized tables for the library domain

### 1. Create datatbase
```sql  
CREATE DATABASE Library
```

### 2. Create table 'Authors'
```sql
CREATE TABLE Library.dbo.Authors (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  FirstName NVARCHAR(255) NOT NULL,
  LastName NVARCHAR(255)
)
```

### 3. Create table 'Customers'
```sql
CREATE TABLE Library.dbo.Customers (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  FirstName NVARCHAR(255) NOT NULL,
  LastName NVARCHAR(255)
)
```

### 4. Create table 'Books'

```sql
CREATE TABLE Library.dbo.Books (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Name NVARCHAR(255) NOT NULL,
  Author_Id UNIQUEIDENTIFIER,
  PageCount SMALLINT NOT NULL,
  PublicationDate DATE NOT NULL
)

ALTER TABLE Library.dbo.Books
ADD CONSTRAINT FK_Books_Authors FOREIGN KEY (Author_Id) REFERENCES Library.dbo.Authors(Id)
```

### 5. Create table 'History'
```sql
CREATE TABLE Library.dbo.History (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Book_Id UNIQUEIDENTIFIER NOT NULL,
  Customer_Id UNIQUEIDENTIFIER NOT NULL,
  CheckoutDate DATE NOT NULL,
  ReturnDate DATE NOT NULL
)

ALTER TABLE Library.dbo.History
ADD CONSTRAINT FK_History_Books_583732 FOREIGN KEY (Book_Id) REFERENCES Library.dbo.Books(Id)

ALTER TABLE Library.dbo.History
ADD CONSTRAINT FK_History_Customers_595922 FOREIGN KEY (Customer_Id) REFERENCES Library.dbo.Customers(Id)
```

### 6. Create table 'CountBook'
```sql
CREATE TABLE Library.dbo.CountBook (
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Book_Id UNIQUEIDENTIFIER NOT NULL,
  AvailableCount SMALLINT NOT NULL,
  TotalCount SMALLINT NOT NULL
)

ALTER TABLE Library.dbo.CountBook
ADD CONSTRAINT FK_CountBook_Books_058293 FOREIGN KEY (Book_Id) REFERENCES Library.dbo.Books(Id)
```
---
