INSERT INTO Users (Id, Name, Email, CreatedAt, UpdatedAt)
VALUES (NEWID(), 'Test User', 'test@gmail.com', '2026-03-25', '2026-03-25');

SELECT * FROM Users;

INSERT INTO Projects (Id, Name)
VALUES (NEWID(), 'Test Project');

Select * from Projects;

Select * from Tasks;