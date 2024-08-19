-- Use the appropriate database
USE CustomerServiceAppDB;
GO

-- Insert test data into the Role table
INSERT INTO Role (RoleName, Description) VALUES
('Admin', 'Full access to all system features and management functions.'),
('Campaign Manager', 'Can create and manage campaigns, and view campaign data.'),
('Sales Representative', 'Can enter and view customer rewards and campaign data.'),
('Data Analyst', 'Can view and analyze campaign results and customer data.'),
('Support Staff', 'Basic access to view customer and campaign information.'),
('Auditor', 'Read-only access to all data for auditing purposes.');
GO

-- Insert test data into the User table
INSERT INTO [User] (Username, PasswordHash, RoleId, CreatedAt, UpdatedAt, Valid) VALUES
('jdoe', 'hashed_password_1', 1, GETDATE(), NULL, 1),
('asmith', 'hashed_password_2', 2, GETDATE(), NULL, 1),
('bjohnson', 'hashed_password_3', 3, GETDATE(), NULL, 1);
GO

-- Insert test data into the Employee table
INSERT INTO Employee (UserId, FirstName, LastName, Email, PhoneNumber, CreatedAt, UpdatedAt) VALUES
(1, 'John', 'Doe', 'jdoe@example.com', '555-0101', GETDATE(), NULL),
(2, 'Alice', 'Smith', 'asmith@example.com', '555-0102', GETDATE(), NULL),
(3, 'Bob', 'Johnson', 'bjohnson@example.com', '555-0103', GETDATE(), NULL);
GO

-- Insert test data into the Campaign table
INSERT INTO Campaign (CampaignName, StartDate, EndDate, DailyLimit, CreatedAt, UpdatedAt, Valid) VALUES
('Winter Sale', '2024-01-01', '2024-01-31', 5, GETDATE(), NULL, 1),
('Spring Promo', '2024-03-01', '2024-03-31', 10, GETDATE(), NULL, 1),
('Summer Blast', '2024-06-01', '2024-06-30', 8, GETDATE(), NULL, 1);
GO

-- Insert test data into the Customer table
INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber, CreatedAt, UpdatedAt, Valid) VALUES
('Emily', 'Davis', 'edavis@example.com', '555-0201', GETDATE(), NULL, 1),
('Michael', 'Brown', 'mbrown@example.com', '555-0202', GETDATE(), NULL, 1,
('Jessica', 'Taylor', 'jtaylor@example.com', '555-0203', GETDATE(), NULL, 1);
GO

-- Insert test data into the Reward table
INSERT INTO Reward (CampaignId, CustomerId, RewardAmount, RewardDate, Valid) VALUES
(1, 1, 50.00, GETDATE(), 1),
(2, 2, 30.00, GETDATE(), 1),
(3, 3, 40.00, GETDATE(), 1);
GO

-- Insert test data into the Purchase table
INSERT INTO Purchase (CustomerId, PurchaseDate, PurchaseAmount, CampaignId, Valid) VALUES
(1, '2024-01-05', 100.00, 1, 1),
(2, '2024-03-10', 150.00, 2, 1),
(3, '2024-06-15', 200.00, 3, 1);
GO

-- Insert test data into the Log table
INSERT INTO Log (Action, Timestamp, UserId, Valid) VALUES
('Created new campaign', GETDATE(), 1, 1),
('Processed customer reward', GETDATE(), 2, 1),
('Logged in for analysis', GETDATE(), 3, 1);
GO
