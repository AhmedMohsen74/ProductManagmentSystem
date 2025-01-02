CREATE TABLE Categories (
    Id INT IDENTITY(1,1) PRIMARY KEY,   
    Name NVARCHAR(255) NOT NULL         
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,   
    Name NVARCHAR(255) NOT NULL,        
    Price FLOAT NOT NULL,                
    Description NVARCHAR(1000),         
    CreatedDate DATETIME,               
    CategoryId INT NOT NULL,             
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)  
);

