CREATE PROC GetIngredients(
	@Name NVarChar(Max)
)
AS
SELECT I.Name, IL.Quantity, IL.Unit FROM INGREDIENT AS I
INNER JOIN INGREDIENTLINE AS IL
ON IL.IngredientID = I.ID
WHERE IL.RecipeID = (SELECT ID FROM RECIPE WHERE Name = @Name);