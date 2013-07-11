--TASK 1 Write a SQL query to find the names and salaries of the employees that take 
--the minimal salary in the company. Use a nested SELECT statement.
SELECT FirstName + ' ' + LastName AS Name, Salary 
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--TASK 2 Write a SQL query to find the names and salaries of the employees that have 
--a salary that is up to 10% higher than the minimal salary for the company.
DECLARE @MinSalary int;
SET @MinSalary = (SELECT MIN(Salary) FROM Employees);
SELECT FirstName + ' ' + LastName AS Name, Salary FROM Employees
WHERE Salary BETWEEN @MinSalary AND @MinSalary * 1.1

--TASK 3 Write a SQL query to find the full name, salary and department of the employees 
--that take the minimal salary in their department. Use a nested SELECT statement.
SELECT em.FirstName + ' ' + em.LastName AS Name, em.Salary, d.Name FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
WHERE Salary = (Select MIN(Salary) FROM Employees em2
				WHERE em2.DepartmentID = em.DepartmentID)
ORDER BY Salary DESC

--TASK 4 Write a SQL query to find the average salary in the department #1.
SELECT AVG(em.Salary) FROM Employees em
WHERE em.DepartmentID = 1

--TASK 5 Write a SQL query to find the average salary  in the "Sales" department.
SELECT AVG(em.Salary) FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
WHERE d.Name = 'Sales'

--TASK 6 Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
WHERE d.Name = 'Sales'

--TASK 7 Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(m.FirstName) FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID

--TASK 8 Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(em.FirstName) - COUNT(m.FirstName) FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID

--TASK 9 Write a SQL query to find all departments and the average salary for each of them
SELECT d.Name, AVG(em.Salary) as [Average Salary] FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
GROUP BY d.Name

--TASK 10 Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name, t.Name, Count(em.FirstName) FROM Employees em
JOIN Departments d ON d.DepartmentID = em.DepartmentID
JOIN Addresses a ON a.AddressID = em.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

--TASK 11 Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName + ' ' + m.LastName AS Name FROM Employees em
JOIN Employees m ON em.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(*) = 5

--TASK 12 Write a SQL query to find all employees along with their managers. For employees 
--that do not have manager display the value "(no manager)".
SELECT em.FirstName + ' ' + em.LastName, COALESCE(m.FirstName + ' ' + m.LastName, '(no manager)') FROM Employees em
LEFT JOIN Employees m ON em.ManagerID = m.EmployeeID

--TASK 13 Write a SQL query to find the names of all employees whose last name is exactly 
--5 characters long. Use the built-in LEN(str) function.
SELECT em.FirstName + ' ' + em.LastName as Name FROM Employees em
WHERE LEN(em.LastName) = 5

--TASK 14 Write a SQL query to display the current date and time in the following format 
--"day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to 
--format dates in SQL Server.
SELECT FORMAT(getdate(), 'dd.mm.yyyy hh:mm:ss:ff')

--TASK 15 Write a SQL statement to create a table Users. Users should have username, password, 
--full name and last login time. Choose appropriate data types for the table fields. Define a 
--primary key column with a primary key constraint. Define the primary key column as identity 
--to facilitate inserting records. Define unique constraint to avoid repeating usernames. Define 
--a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(50) NOT NULL,
  Password nvarchar(30) NOT NULL,
  FullName nvarchar(50) NOT NULL,
  LastLogin smalldatetime NOT NULL,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT unq_Users UNIQUE(Username),
  CONSTRAINT chk_Password Check (LEN(Password) >= 5)
)

--TASK 16 Write a SQL statement to create a view that displays the users from the Users 
--table that have been in the system today. Test if the view works correctly.
CREATE VIEW [Users from today] AS
SELECT * FROM Users
WHERE DAY(LastLogin) = DAY(getdate())

--TASK 17 Write a SQL statement to create a table Groups. Groups should have unique name 
(use unique constraint). Define primary key and identity column.
CREATE TABLE Groups (
Id int IDENTITY,
Name nvarchar(50) NOT NULL,
CONSTRAINT PK_Group PRIMARY KEY(Id),
CONSTRAINT unq_Name UNIQUE(Name)
)

--TASK 18 Write a SQL statement to add a column GroupID to the table Users. Fill some data in this 
--new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint 
--between tables Users and Groups tables.
ALTER TABLE Users
ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Group FOREIGN KEY(GroupID) References Groups(Id)

--TASK 19 Write SQL statements to insert several records in the Users and Groups tables.
--INSERT INTO Users (Username, Password, FullName, LastLogin)
--VALUES(
	'Jorko2', '13452', 'Jorko Jorkov', getdate()),
	('John', '123458', 'John Snow', getdate()
)

INSERT INTO Groups (Name)
VALUES
	('Group2'),
	('Group3')

--TASK 20 Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET FullName = 'Mr. Goshko'
WHERE Username = 'TestUser1'

UPDATE Groups
SET Name = 'Test_' + Name
WHERE Name LIKE 'Group%'

--TASK 21 Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'TestUser3'

DELETE FROM Groups
WHERE Name='Test_Group3'

--TASK 22 Write SQL statements to insert in the Users table the names of all employees from the 
--Employees table. Combine the first and last names as a full name. For username use the first 
--letter of the first name + the last name (in lowercase). Use the same for the password, and NULL 
--for last login time.
INSERT INTO Users(Username, Password, FullName, LastLogin)
SELECT FirstName + ' ' + LastName, 
	   LOWER(SUBSTRING(FirstName, 0, 1) + LastName + 'salt'), 
	   LOWER(SUBSTRING(FirstName, 0, 1) + LastName),
	   getdate()
FROM Employees

--TASK 23 Write a SQL statement that changes the password to NULL for all users that have not 
--been in the system since 10.03.2010.
UPDATE Users
SET Password = 'default'
WHERE LastLogin <= CAST('10.03.2010 00:00:00' AS smalldatetime)

--TASK 24 Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Password != 'default'

--TASK 25 Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name, em.JobTitle, AVG(em.Salary) as [Max Salary] FROM Employees em
JOIN Departments d on d.DepartmentID = em.DepartmentID
GROUP BY d.Name, em.JobTitle

--TASK 26 Write a SQL query to display the minimal employee salary by department and job title 
--along with the name of some of the employees that take it.
SELECT d2.Name, e.JobTitle, e.FirstName + ' ' + e.LastName as Name, e.Salary FROM Employees e
JOIN Departments d2 ON d2.DepartmentID = e.DepartmentID
WHERE e.Salary IN (SELECT MIN(em.Salary) FROM Employees em
				  JOIN Departments d on d.DepartmentID = em.DepartmentID
				  WHERE d2.DepartmentID = d.DepartmentID
				  GROUP BY d.Name)

--TASK 27 Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(*)
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(*) DESC

--TASK 28 Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(emp.ManagerID) AS ManagersCount
FROM Employees e 
JOIN Addresses a ON e.AddressID = a.AddressID
join Towns t ON t.TownID = a.TownID
join Employees emp ON e.ManagerID = emp.EmployeeID
GROUP BY t.Name

--TASK 29 Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). 
--Don't forget to define  identity, primary key and appropriate foreign key. 
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	EmployeeID int IDENTITY,
	Date smalldatetime,
	Task nvarchar(50),
	Hours int,
	CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_WorkHours FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours(Date, Task, Hours)
VALUES
	(getdate(), 'Sample Task1', 2),
	(getdate(), 'Sample Task2', 13)

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'

