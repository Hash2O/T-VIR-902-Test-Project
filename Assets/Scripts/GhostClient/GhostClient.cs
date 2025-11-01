using UnityEngine;
using System.Collections;
public class GhostClient : MonoBehaviour
{
    public RecipeData requestedRecipe;
    public bool isSatisfied { get; private set; }

    [Header("Apparence")]
    public Renderer ghostRenderer; // Assigné dans l’inspector
    public float colorChangeSpeed = 4f; // transition douce

    private void OnTriggerEnter(Collider other)
    {
        PotionBottle bottle = other.GetComponent<PotionBottle>();
        if (bottle != null)
        {
            ReceivePotion(bottle);
            Destroy(bottle.gameObject, 4f); // la bouteille se vide / disparaît
        }
    }

    public void ReceivePotion(PotionBottle bottle)
    {
        if (bottle == null || bottle.GetContainedRecipe() == null)
        {
            Debug.Log("Le client reçoit une fiole vide !");
            return;
        }

        RecipeData received = bottle.GetContainedRecipe();

        if (received == requestedRecipe)
        {
            Debug.Log($"Le client est ravi ! Potion correcte : {received.recipeName}");
            isSatisfied = true;
            StartCoroutine(ChangeGhostColor(received.potionColor));
        }
        else
        {
            Debug.Log($"Mauvaise potion : {received.recipeName} au lieu de {requestedRecipe.recipeName}");
            isSatisfied = false;
            StartCoroutine(ChangeGhostColor(Color.grey)); // couleur d’échec, par exemple
            AudioManager.audioInstance.PlayTheGoodSound(2); // Plays "NOPE" !
        }
    }

    private IEnumerator ChangeGhostColor(Color targetColor)
    {
        if (ghostRenderer == null)
            yield break;

        Material mat = ghostRenderer.material;
        Color startColor = mat.color;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * colorChangeSpeed;
            mat.color = Color.Lerp(startColor, targetColor, t);
            yield return null;
        }
    }
}

