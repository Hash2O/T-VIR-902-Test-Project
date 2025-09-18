using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class FillPotionWithCookingPot : MonoBehaviour
{
    private bool isReadyToBeFilled = false;

    [SerializeField] private GameObject content;
    [SerializeField] private ParticleSystem bubbles;

    //private OnTilt onTilt;
    //private OnVelocity onVelocity;

    private void Start()
    {
        //onTilt = GetComponent<OnTilt>();
        //onVelocity = GetComponent<OnVelocity>();

        bubbles.gameObject.SetActive(false);
        content.gameObject.SetActive(false);
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
