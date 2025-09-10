using UnityEngine;

public class FillPotionWithCookingPot : MonoBehaviour
{
    private bool isReadyToBeFilled = false;

    [SerializeField] private GameObject content;
    [SerializeField] private ParticleSystem bubbles;

    private OnTilt OnTilt;
    private OnVelocity OnVelocity;

    private void Start()
    {
        OnTilt = GetComponent<OnTilt>();
        OnVelocity = GetComponent<OnVelocity>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CookingPot") && !isReadyToBeFilled)
        {
            Debug.Log("Inside cooking pot !");
            isReadyToBeFilled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CookingPot") && isReadyToBeFilled)
        {
            Debug.Log("Outside cooking pot !");
            bubbles.gameObject.SetActive(true);
            content.gameObject.SetActive(true);
        }
    }
}
