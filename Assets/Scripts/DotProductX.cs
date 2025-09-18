using UnityEngine;

public class DotProductX : MonoBehaviour
{
    Vector3 firstVector = new Vector3(-1, 0, 1);
    Vector3 secondVector = new Vector3(0, 1, 0);
    private void Start()
    {
        float dotProduct = Vector3.Dot(firstVector, secondVector);
        Debug.Log(dotProduct);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
