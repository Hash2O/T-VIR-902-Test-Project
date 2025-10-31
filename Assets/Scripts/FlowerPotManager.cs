using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class FlowerPotManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("Water dropped.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Debug.Log("Water dropped.");
        }
    }
}
