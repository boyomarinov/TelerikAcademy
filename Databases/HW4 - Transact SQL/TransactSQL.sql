----Task 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
----Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored 
----procedure that selects the full names of all persons.
--CREATE TABLE People(
--	Id int IDENTITY,
--	FirstName nvarchar(50) NOT NULL,
--	LastName nvarchar(50) NOT NULL,
--	SSN nvarchar(20) NOT NULL,
--	CONSTRAINT PK_People PRIMARY KEY(Id)
--)

--CREATE TABLE Accounts(
--	Id int IDENTITY,
--	PersonId int NOT NULL,
--	Balance money NOT NULL,
--	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
--	CONSTRAINT FK_Accounts_People FOREIGN KEY(PersonId) REFERENCES People(Id)
--)

--INSERT INTO People(FirstName, LastName, SSN)
--VALUES ('Joro', 'Petrov', '123123123'),
--	   ('Ivan', 'Dimitrov', '456456456'),
--	   ('Pesho', 'Petrov', '789789789')

--INSERT INTO Accounts(PersonId, Balance)
--VALUES (1, 123.23),
--	   (2, 1000000),
--	   (3, 0.01)

--CREATE PROC usp_SelectPersonsFullName
--AS
--	SELECT FirstName + ' ' + LastName AS [Full Name]
--	FROM People
--GO

--EXEC usp_SelectPersonsFullName
		
----Task 2. Create a stored procedure that accepts a number as a parameter and returns all persons 
----who have more money in their accounts than the supplied number.

--CREATE PROC usp_GetPeopleWithBalanceMoreThan(
--	@MinBalance money)
--AS
--	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance
--	FROM People p
--	JOIN Accounts a ON a.PersonId = p.Id
--	WHERE a.Balance > @MinBalance
--GO

--EXEC usp_GetPeopleWithBalanceMoreThan 20

----Task 3. Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
----It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
--CREATE FUNCTION ufn_CalculateInterest(@sum money, @interest float, @months int)
--	RETURNS money
--AS
--BEGIN
--RETURN @sum* POWER(1 + @interest/100, @months / 12.0)
--END

--SELECT dbo.ufn_CalculateInterest(Balance, 20, 11)
--FROM Accounts
--WHERE Id = 2

----Task 4. Create a stored procedure that uses the function from the previous example to give an interest 
----to a person's account for one month. It should take the AccountId and the interest rate as parameters.

--CREATE PROC usp_CalculateMonthInterest(
--	@AccountId int,
--	@InterestRate float	
--)
--AS
--	SELECT p.FirstName + ' ' + p.LastName AS [Full Name], a.Balance as OriginalBalance, dbo.ufn_CalculateInterest(a.Balance, @InterestRate, 1) as [With Interest]
--	FROM People p
--	JOIN Accounts a ON a.PersonId = p.Id
--	WHERE a.Id = @AccountId
--GO

--EXEC usp_CalculateMonthInterest 2, 20

----Task 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney (AccountId, money) 
----that operate in transactions.

--CREATE PROC usp_WithdrawMoney(
--	@AccountID int,
--	@MoneyAmount money)
--AS
--DECLARE @CurrentBalance money;
--BEGIN
--	BEGIN TRAN
--	UPDATE Accounts
--	SET @CurrentBalance = Balance - @MoneyAmount,
--		Balance = Balance - @MoneyAmount
--	WHERE Id = @AccountID

--	IF(@CurrentBalance < 0)
--		ROLLBACK TRAN
--	ELSE
--		COMMIT TRAN
--END

--EXEC usp_WithdrawMoney 1, 200

--CREATE PROC usp_DepositMoney(
--	@AccountID int,
--	@MoneyAmount money)
--AS
--BEGIN
--	BEGIN TRANSACTION
--	UPDATE Accounts
--	SET Balance = Balance + @MoneyAmount
--	WHERE Id = @AccountID

--	IF(@MoneyAmount < 0)
--		ROLLBACK TRANSACTION
--	ELSE
--		COMMIT TRAN
--END

--EXEC usp_DepositMoney 1, 1500

----Task 6. Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table 
----that enters a new entry into the Logs table every time the sum on an account changes.

--CREATE TABLE Logs(
--	LogID int IDENTITY,
--	AccountID int NOT NULL,
--	OldBalance money NOT NULL,
--	NewBalance money NOT NULL,
--	CONSTRAINT PK_Logs PRIMARY KEY(LogID),
--	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(Id)
--)

--CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
--AS
--	DECLARE @UpdatedId int
--	SET @UpdatedId = (SELECT Id FROM Inserted)
--	INSERT INTO Logs(AccountID, OldBalance, NewBalance)
--	Values(@UpdatedId,
--		   (SELECT Balance FROM Deleted),
--		   (SELECT Balance FROM Inserted))
--GO


----Task 7. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle 
----or last name) and all town's names that are comprised of given set of letters. Example 'oistmiahf' will 
----return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

--CREATE FUNCTION dbo.ufn_NameContainingLetters(
--        @Name NVARCHAR(50),
--        @Letters NVARCHAR(50)
--        )
--        RETURNS bit
--AS
--BEGIN
--        DECLARE @Contains bit
--        SET @Contains = 1
--        DECLARE @CurLetter NVARCHAR(1)
--        DECLARE @Counter INT
--        SET @Counter = 1
 
--        WHILE(@counter <= LEN(@Name))
--                BEGIN
--                SET @CurLetter = SUBSTRING(@Name, @Counter, 1)
--                IF (CHARINDEX(@CurLetter, @Letters) = 0)
--                        SET @Contains = 0
--                SET @Counter = @Counter + 1
--                END
--        RETURN @Contains
--END

--CREATE PROC dbo.usp_FindFirstNames(
--        @LettersToSearch NVARCHAR(50)
--        )
--        AS
--                DECLARE @Valid bit
--                SET @Valid = 0
                                       
--                        SELECT e.FirstName AS [First name]
--                        FROM Employees e
--                        WHERE
--                                1 = (SELECT dbo.ufn_NameContainingLetters(
--                                        e.FirstName,
--                                        @LettersToSearch)
--                                        )
--        GO

--CREATE PROC dbo.usp_FindMiddleNames(
--	@LettersToSearch NVARCHAR(50)
--)
--AS
--    DECLARE @Valid bit
--    SET @Valid = 0
		               
--		SELECT e.FirstName AS [Middle name]
--		FROM Employees e
--		WHERE
--		    1 = (SELECT dbo.ufn_NameContainingLetters(
--		            e.FirstName,
--		            @LettersToSearch)
--		            )
--GO

--CREATE PROC dbo.usp_FindLastNames(
--	@LettersToSearch NVARCHAR(50)
--)
--AS
--    DECLARE @Valid bit
--    SET @Valid = 0
		               
--		SELECT e.FirstName AS [Last name]
--		FROM Employees e
--		WHERE
--		    1 = (SELECT dbo.ufn_NameContainingLetters(
--		            e.FirstName,
--		            @LettersToSearch)
--		            )
--GO

--CREATE PROC dbo.usp_FindTowns(
--	@LettersToSearch NVARCHAR(50)
--)
--AS
--    DECLARE @Valid bit
--    SET @Valid = 0
		               
--		SELECT t.Name AS [Town]
--		FROM Towns t
--		WHERE
--		    1 = (SELECT dbo.ufn_NameContainingLetters(
--		            t.Name,
--		            @LettersToSearch)
--		            )
--GO

--EXEC dbo.usp_FindFirstNames 'oistmiahf'
--EXEC dbo.usp_FindMiddleNames 'oistmiahf'
--EXEC dbo.usp_FindLastNames 'oistmiahf'
--EXEC dbo.usp_FindTowns 'oistmiahf'

--Task 8. Using database cursor write a T-SQL script that scans all employees and their addresses and prints 
--all pairs of employees that live in the same town.
CREATE empCursor CURSOR READ_ONLY FOR
        SELECT e1.FirstName, e1.LastName, t.Name,
                e2.FirstName, e2.LastName
        FROM Employees e1
                INNER JOIN Addresses a
                        ON a.AddressID = e1.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees e2
                INNER JOIN Addresses a1
                        ON a1.AddressID = e2.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.TownID               
 
        OPEN empCursor
        DECLARE @e1fname NVARCHAR(50)
        DECLARE @e1lname NVARCHAR(50)
        DECLARE @e2fname NVARCHAR(50)
        DECLARE @e2lname NVARCHAR(50)
        DECLARE @town NVARCHAR(50)

        FETCH NEXT FROM empCursor
                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @town + ': ' + @e1fname + ' ' + @e1lname + ' ' + @e2fname + ' ' + @e2lname
                        FETCH NEXT FROM empCursor
                                INTO @e1fname, @e1lname, @e2fname, @e2lname, @town
                END
 
        CLOSE empCursor
        DEALLOCATE empCursor


--Task 10. Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return 
--a single string that consists of the input strings separated by ','. 
