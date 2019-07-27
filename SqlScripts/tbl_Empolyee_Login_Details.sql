CREATE TABLE Tbl_Employee_Login_Details(
Emp_ID INT IDENTITY(1,1) PRIMARY KEY,
Emp_FirstName NVARCHAR(255),
Emp_LastName NVARCHAR(255),
Emp_Email NVARCHAR(255),
Emp_Email_Confirm BIT,
Emp_MobileNo INT,
Emp_MobilieNo_Confirm BIT,
Emp_Alt_MobileNo INT,
Emp_Password_Hash NVARCHAR(255),
Emp_Account_Status VARCHAR(100),
Emp_Created_By NVARCHAR(255),
Emp_Created_Date DATETIME,
Emp_Updated_By NVARCHAR(255),
Emp_Updated_Date DATETIME,
)

--select * from Tbl_Employee_Login_Details