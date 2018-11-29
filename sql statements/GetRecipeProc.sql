CREATE PROC GetRecipe(
	@Name NVarChar(Max)
)
AS
SELECT Name, Directions FROM RECIPE WHERE Name = @Name;