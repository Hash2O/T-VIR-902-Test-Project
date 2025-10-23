using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostCycleManager : MonoBehaviour
{
    [Header("Points de déplacement")]
    public Transform ghostSpawnPoint;
    public Transform ghostWaitPoint;
    public Transform ghostExitPoint;

    [Header("Gestion des fantômes")]
    public List<GameObject> ghostPrefabs; // différents types de fantômes
    private GhostClient activeGhost;

    [Header("Récompenses")]
    public GameObject coinPrefab;
    public Transform coinDeliveryPoint; // où tombent les pièces
    public float timeBetweenCoins = 0.3f;

    [Header("Paramètres")]
    public float spawnDelay = 2f;
    public float exitDelay = 3f;
    public float timeBeforeVanish = 5f;

    private bool isSpawning = false;

    private void Start()
    {
        StartCoroutine(GhostCycleLoop());
    }

    private IEnumerator GhostCycleLoop()
    {
        while (true)
        {
            if (!isSpawning && activeGhost == null)
            {
                yield return StartCoroutine(SpawnGhost());
            }
            yield return null;
        }
    }

    private IEnumerator SpawnGhost()
    {
        isSpawning = true;

        yield return new WaitForSeconds(spawnDelay);

        // Choisit un type de fantôme aléatoire
        GameObject prefab = ghostPrefabs[Random.Range(0, ghostPrefabs.Count)];
        GameObject ghostObj = Instantiate(prefab, ghostSpawnPoint.position, Quaternion.identity);
        activeGhost = ghostObj.GetComponent<GhostClient>();

        // Déplace le fantôme vers le comptoir
        NavMeshAgent agent = ghostObj.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(ghostWaitPoint.position);
        }

        // Attend que le fantôme soit satisfait
        yield return new WaitUntil(() => activeGhost.isSatisfied);

        // Lance la séquence de récompense
        yield return StartCoroutine(GiveReward());

        // Délai avant le départ
        yield return new WaitForSeconds(exitDelay);

        // Déplacement vers la sortie
        if (agent != null)
            agent.SetDestination(ghostExitPoint.position);

        // Attend que le fantôme soit assez loin pour le désactiver
        yield return new WaitForSeconds(timeBeforeVanish);
        Destroy(ghostObj);  // Implémenter un système de pool pour désactiver chaque fantôme au lieu de le détruire
        activeGhost = null;

        isSpawning = false;
    }

    private IEnumerator GiveReward()
    {
        if (coinPrefab == null || coinDeliveryPoint == null)
            yield break;

        int coinCount = Random.Range(1, 4);

        for (int i = 0; i < coinCount; i++)
        {
            Instantiate(coinPrefab, coinDeliveryPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenCoins);
        }

        Debug.Log($"{coinCount} pièce(s) récompensent la sorcière !");
    }
}

