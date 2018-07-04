CREATE PROCEDURE [dbo].[GetAllSalesItems]

AS
	SELECT Id, Number, Country
	FROM Sales