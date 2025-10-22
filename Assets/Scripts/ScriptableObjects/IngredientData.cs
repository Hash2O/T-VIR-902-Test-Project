using UnityEngine;

public enum IngredientType
{
    Vegetal,
    Mineral,
    Animal,
    Autre
}

public enum TasteProfile
{
    Amer,
    Sucre,
    Sale,
    Acide,
    Umami,
    Neutre
}

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Alchemy/Ingredient")]
public class IngredientData : ScriptableObject
{
    [Header("Informations générales")]
    public string ingredientName;
    [TextArea] public string description;
    public IngredientType type;

    [Header("Apparence et références")]
    public Sprite icon; // Pour l’interface
    public GameObject prefab; // Pour instancier dans la scène VR

    [Header("Caractéristiques gustatives")]
    public TasteProfile[] tastes; // Permet d’avoir plusieurs goûts simultanés

    [Header("Effets spéciaux (facultatif)")]
    public string[] specialEffects; // Ex: "Inflammable", "Gelant", "Curatif"

    [Header("Valeurs de gameplay (facultatif)")]
    public float potency = 1f; // Force de l’effet
    public Color colorHint = Color.white; // Peut influencer la couleur du mélange
}

