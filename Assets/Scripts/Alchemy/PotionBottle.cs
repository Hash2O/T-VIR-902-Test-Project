using UnityEngine;

public class PotionBottle : MonoBehaviour
{
    //[Header("Données de la potion")]

    public RecipeData containedRecipe;
    
    public Renderer liquidRenderer;

    //[Header("Aspect visuel")]


    public void FillWithRecipe(RecipeData recipe)
    {
        containedRecipe = recipe;

        if (liquidRenderer != null)
        {
            liquidRenderer.material.color = recipe.potionColor;
        }

        Debug.Log($" La bouteille contient maintenant la potion : {recipe.recipeName}");
    }

    public RecipeData GetContainedRecipe()
    {
        return containedRecipe;
    }
}

