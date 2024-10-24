CREATE DATABASE SchoolDB;
GO
USE SchoolDB;
GO

CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Age INT,
    Major NVARCHAR(50)
);
GO
INSERT INTO Students (FullName, Age, Major) VALUES 
(N'Nguyễn Văn A', 20, N'Công Nghệ Thông Tin'),
(N'Trần Thị B', 22, N'Kinh Tế'),
(N'Lê Văn C', 21, N'Quản Trị Kinh Doanh'),
(N'Phạm Thị D', 19, N'Tài Chính Ngân Hàng')

