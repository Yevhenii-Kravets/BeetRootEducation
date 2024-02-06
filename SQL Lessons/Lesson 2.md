# SQL Lesson 2
# SQL DDL

## Phone book

```sql
IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'Phonebook'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.Phonebook 
	(
	  Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	  FirstName VARCHAR(30) NOT NULL,
	  LastName VARCHAR(30),
	  Number VARCHAR (20) CHECK (Number LIKE '%[0-9]%') NOT NULL,
	  Descr VARCHAR(20) 
	)
END
```

```sql
INSERT INTO PersonsDB.dbo.Phonebook (FirstName, LastName, Number, Descr)
VALUES ('Yevhenii', 'Kravets', '380939299000', 'Home'),
       ('John', 'Doe', '0673262719', 'Work')
```

Result:
|¹ | Id                                  | FirstName    | LastName | Number       | Descr  |
|--|-------------------------------------|--------------|----------|--------------|--------|
|1 | 3989D808-718D-4682-980B-074034ED4D73 | Yevhenii    | Kravets  | 380939299000 | Home   |
|2 | 03AAEB54-7D06-4C1C-9D5F-D7D213C662A3 | John        | Doe      | 0673262719   | Work   |

---

## Store school schedule

```sql
IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'SchoolSchedule'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.SchoolSchedule 
	(
	  Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	  LessonName VARCHAR(30) NOT NULL,
	  TeacherFirstName VARCHAR(30) NOT NULL,
	  TeacherLastName VARCHAR(30),
	  StartTime DATETIME NOT NULL,
	  Duration TIME DEFAULT '00:45:00' NOT NULL
	)
END
```

```sql
INSERT INTO PersonsDB.dbo.SchoolSchedule (LessonName, TeacherFirstName, TeacherLastName, StartTime)
VALUES ('Mathematics', 'Alexander', 'Sergeevich', '2023-07-16T13:00:00'),
       ('Literature', 'Nadezhda', 'Nikolayevna', '2023-07-16T14:00:00')
```

Result: 
| ¹ | Id | LessonName   | TeacherFirstName | TeacherLastName | StartTime               | Duration        |
|---|----|--------------|------------------|-----------------|-------------------------|-----------------|
| 1 | 13 | Mathematics  | Alexander        | Sergeevich      | 2023-07-16 13:00:00.000 | 00:45:00.0000000|
| 2 | 14 | Literature   | Nadezhda         | Nikolayevna     | 2023-07-16 14:00:00.000 | 00:45:00.0000000|

---

## Store user’s login history

```sql
IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'UsersLoginHistory'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.UsersLoginHistory 
	(
	  Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	  UserLogin VARCHAR(50) NOT NULL,
	  LoginTime DATETIME NOT NULL,
	  PlatformType VARCHAR(10) NOT NULL,
	  Country VARCHAR(20) NOT NULL
	)
END
```

```sql
INSERT INTO PersonsDB.dbo.UsersLoginHistory (UserLogin, LoginTime, PlatformType, Country)
VALUES ('email@gmail.com', GETDATE(), 'Website', 'France'),
       ('corp_user@company.ua', GETDATE(), 'PC', 'Ukraine'),
	   ('userGood@mail.com', GETDATE(), 'Android', 'Germany'),
	   ('LuckyAmerican@gmail.com', GETDATE(), 'IPhone', 'USA')
```

Result: 
| ¹ | Id                                  | UserLogin                | LoginTime                  | PlatformType | Country |
|---|-------------------------------------|-------------------------|----------------------------|--------------|---------|
| 1 | 11EDBB37-4FE5-4B72-9526-1ED3D2AE13F9 | LuckyAmerican@gmail.com | 2023-07-16 17:22:48.097  | IPhone       | USA     |
| 2 | BE8F3B87-9C4C-40BF-B568-3A6942F2FEE6 | userGood@mail.com       | 2023-07-16 17:22:48.097  | Android      | Germany |
| 3 | CC2E0238-B9E5-4332-96BD-DF6CD30E999D | email@gmail.com         | 2023-07-16 17:22:48.097  | Website      | France  |
| 4 | 5811E11E-1537-4778-A1E0-DFB04D9699B7 | corp_user@company.ua    | 2023-07-16 17:22:48.097  | PC           | Ukraine |

---

## Store bank accounts + Users account + AccountCards

```sql
IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'UsersAccounts'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.UsersAccounts 
	(
	  TIN NUMERIC(10, 0) PRIMARY KEY NOT NULL,
	  FirstName VARCHAR(50) NOT NULL,
	  LastName VARCHAR(50) NOT NULL,
	  Patronumic VARCHAR(50) NOT NULL,
	  Address VARCHAR(20) NOT NULL,
	  Member BIT DEFAULT 0 NOT NULL
	)
END

IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'BankAccounts'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.BankAccounts 
	(
	  IBAN VARCHAR(28) PRIMARY KEY NOT NULL,
	  TIN NUMERIC(10, 0) REFERENCES PersonsDB.dbo.UsersAccounts(TIN) NOT NULL,
	  AccountMoney MONEY DEFAULT 0 NOT NULL
	)
END

IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'AccountCards'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.AccountCards 
	(
	  Number VARCHAR(16) PRIMARY KEY NOT NULL,
	  IBAN VARCHAR(28) REFERENCES PersonsDB.dbo.BankAccounts(IBAN) NOT NULL
	)
END
```

```sql
SELECT
    ua.TIN,
    ua.FirstName,
    ua.LastName,
    ua.Member,
    ba.IBAN,
    ba.AccountMoney,
    ba.Currency,
    ac.Number AS CardNumber
FROM
    UsersAccounts ua
LEFT JOIN
    BankAccounts ba ON ua.TIN = ba.TIN
LEFT JOIN
    AccountCards ac ON ba.IBAN = ac.IBAN;
```

Result:
| ¹ | TIN        | FirstName | LastName  | Member | IBAN                          | AccountMoney | Currency              | CardNumber       |
|---|------------|-----------|-----------|--------|-------------------------------|--------------|-----------------------|------------------|
| 1 | 1234567891 | John      | Doe       | 1      | UA12345678912345678912345670  | 38424,43     | United States dollar | 1234123412343333 |
| 2 | 1234567891 | John      | Doe       | 1      | UA12345678912345678912345671  | 1000,00      | Pound sterling       | 1234123412344444 |
| 3 | 1234567892 | Yevhenii  | Kravets   | 1      | UA12345678912345678912345672  | 678245,52    | Hryvnia               | 1234123412341111 |
| 4 | 1234567892 | Yevhenii  | Kravets   | 1      | UA12345678912345678912345672  | 678245,52    | Hryvnia               | 1234123412342222 |
| 5 | 1234567893 | Elizaveta | Tsar      | 0      | UA12345678912345678912345673  | 1524972,43   | French Franc          | 1234123412345555 |
| 6 | 1234567894 | Zuhra     | Mamedova  | 0      | UA12345678912345678912345674  | 76,11        | Turkish Lira          | 1234123412346666 |

---

## Store bank transactions data

```sql
IF(NOT EXISTS (SELECT * 
               FROM INFORMATION_SCHEMA.TABLES
			   WHERE TABLE_SCHEMA = 'dbo'
			   AND TABLE_NAME = 'BankTransactionsData'))
BEGIN 
    CREATE TABLE PersonsDB.dbo.BankTransactionsData 
	(
	  Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	  TransactionTime DATETIME NOT NULL,
	  OperationTime DATETIME NOT NULL,
	  TransactionMoney MONEY DEFAULT 0 NOT NULL,
	  Sender VARCHAR(28) REFERENCES PersonsDB.dbo.BankAccounts(IBAN) NOT NULL,
	  Recipient VARCHAR(28) REFERENCES PersonsDB.dbo.BankAccounts(IBAN) NOT NULL
	)
END
```

```sql
SELECT 
    ua.TIN,
	ua.FirstName,
	ua.LastName,
	btd.TransactionTime,
	btd.Sender,
	btd.TransactionMoney,
	btd.Recipient
FROM
    BankTransactionsData btd
LEFT JOIN 
	BankAccounts ON btd.Sender = BankAccounts.IBAN
LEFT JOIN 
    UsersAccounts ua ON BankAccounts.TIN = ua.TIN
```

Result:
| ¹ | TIN        | FirstName | LastName | TransactionTime       | Sender                        | TransactionMoney | Recipient                      |
|---|------------|-----------|----------|-----------------------|-------------------------------|------------------|--------------------------------|
| 1 | 1234567892 | Yevhenii  | Kravets  | 2023-07-28 20:47:13.500 | UA12345678912345678912345672  | 50,00            | UA12345678912345678912345673  |
| 2 | 1234567891 | John      | Doe      | 2023-07-28 20:47:13.500 | UA12345678912345678912345671  | 1000,00          | UA12345678912345678912345672  |
| 3 | 1234567892 | Yevhenii  | Kravets  | 2023-07-28 20:47:13.500 | UA12345678912345678912345672  | 1000000,00       | UA12345678912345678912345673  |


