--! This Script is Creating and Populating TotalOrders Column in 'Customers' Table(NorthWind DB)
--! Showing Total number of Orders per Customer

ALTER TABLE dbo.Customers ADD TotalOrders VARCHAR(20);

GO

MERGE INTO Customers C
USING
(SELECT
   CustomerID,
   COUNT (*) AS TotalOrders
   FROM
   Orders
   GROUP BY
   CustomerID) S

   ON C.CustomerID=S.CustomerID
   WHEN MATCHED THEN
   UPDATE
   SET TotalOrders=S.TotalOrders;

   GO

--! By Roman Mayerson Jan 2020