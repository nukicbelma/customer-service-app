-- Create database 
CREATE DATABASE CustomerServiceAppDB
GO

USE CustomerServiceAppDB
GO

-- Create Role Table
CREATE TABLE Role (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) UNIQUE NOT NULL,
    Description NVARCHAR(255)
);

-- Create User Table
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    Valid BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
);

-- Indexes for User Table
CREATE INDEX IX_User_Username ON [User](Username);
CREATE INDEX IX_User_RoleId ON [User](RoleId);

-- Create Employee Table
CREATE TABLE Employee (
    EmployeeId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT UNIQUE NOT NULL,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

-- Indexes for Employee Table
CREATE INDEX IX_Employee_Email ON Employee(Email);
CREATE INDEX IX_Employee_UserId ON Employee(UserId);

-- Create Campaign Table
CREATE TABLE Campaign (
    CampaignId INT PRIMARY KEY IDENTITY(1,1),
    CampaignName NVARCHAR(255) NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    DailyLimit INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    Valid BIT NOT NULL DEFAULT 1
);

-- Indexes for Campaign Table
CREATE INDEX IX_Campaign_StartDate ON Campaign(StartDate);
CREATE INDEX IX_Campaign_EndDate ON Campaign(EndDate);

-- Create Customer Table
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PhoneNumber NVARCHAR(15),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL, 
    Valid BIT NOT NULL DEFAULT 1
);

-- Indexes for Customer Table
CREATE INDEX IX_Customer_Email ON Customer(Email);

-- Create Reward Table
CREATE TABLE Reward (
    RewardId INT PRIMARY KEY IDENTITY(1,1),
    CampaignId INT NOT NULL,
    CustomerId INT NOT NULL,
    RewardAmount DECIMAL(18,2) NOT NULL,
    RewardDate DATETIME NOT NULL,
    Valid BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (CampaignId) REFERENCES Campaign(CampaignId),
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

-- Indexes for Reward Table
CREATE INDEX IX_Reward_CampaignId ON Reward(CampaignId);
CREATE INDEX IX_Reward_CustomerId ON Reward(CustomerId);
CREATE INDEX IX_Reward_RewardDate ON Reward(RewardDate);

-- Create Purchase Table
CREATE TABLE Purchase (
    PurchaseId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    PurchaseDate DATETIME NOT NULL,
    PurchaseAmount DECIMAL(18,2) NOT NULL,
    CampaignId INT NULL,
    Valid BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
    FOREIGN KEY (CampaignId) REFERENCES Campaign(CampaignId)
);

-- Indexes for Purchase Table
CREATE INDEX IX_Purchase_CustomerId ON Purchase(CustomerId);
CREATE INDEX IX_Purchase_PurchaseDate ON Purchase(PurchaseDate);
CREATE INDEX IX_Purchase_CampaignId ON Purchase(CampaignId);

-- Create Log Table
CREATE TABLE Log (
    LogId INT PRIMARY KEY IDENTITY(1,1),
    Action NVARCHAR(255) NOT NULL,
    Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,
    Valid BIT NOT NULL DEFAULT 1,
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

-- Indexes for Log Table
CREATE INDEX IX_Log_UserId ON Log(UserId);
CREATE INDEX IX_Log_Timestamp ON Log(Timestamp);
