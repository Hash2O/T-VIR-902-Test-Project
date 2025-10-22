using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;

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
            GameObject prefab = Instantiate(smashPrefab, collision.transform.position, Quaternion.identity);
            smashParticle = prefab.GetComponentInChildren<ParticleSystem>();
            smashParticle.Play();
            smashAudio.Play();
            if (collision.gameObject != null) Destroy(collision.gameObject);
        }
    }

}
