CREATE TABLE CartItems (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
