using System.Collections;
using UnityEngine;

public class VerminBusterManager : MonoBehaviour
{
    [SerializeField] private GameObject smashPrefab;
    
    private ParticleSystem smashParticle;

    private AudioSource smashAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        smashAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Vermin"))
        {
            Transform spawnPoint = collision.transform;
            Destroy(collision.gameObject);
            GameObject prefab = Instantiate(smashPrefab, spawnPoint.position, Quaternion.identity);
            smashParticle = prefab.GetComponentInChildren<ParticleSystem>();
            smashParticle.Play();
            smashAudio.Play();
        }
    }

}
