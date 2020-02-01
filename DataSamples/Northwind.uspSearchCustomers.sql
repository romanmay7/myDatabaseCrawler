CREATE PROCEDURE [dbo].[uspSearchCustomers]  
@SearchKey NVARCHAR (40),
@SearchTerm NVARCHAR (40),
@SearchValue NVARCHAR (40)
  
AS  

IF (@SearchTerm = 'BeginWith')
BEGIN
    SELECT ContactName, CompanyName, Phone,TotalOrders FROM dbo.Customers
    WHERE @SearchKey LIKE @SearchValue +'%';
    
END
ELSE IF (@SearchTerm = 'Includes')

BEGIN  
    SELECT ContactName, CompanyName, Phone,TotalOrders FROM dbo.Customers
    WHERE @SearchKey LIKE '%'+ @SearchValue +'%';
      
END
ELSE IF (@SearchTerm = 'EndsWith')
BEGIN  
    SELECT ContactName, CompanyName, Phone,TotalOrders FROM dbo.Customers
    WHERE @SearchKey LIKE '%'+ @SearchValue;
      
END