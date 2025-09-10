using UnityEngine;
using EzySlice;
using Valve.VR.InteractionSystem;

public class AdvancedSliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public Material crossSectionMaterials;
    public float moreCutForce = 200;
    public LayerMask sliceableLayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            // Trying to get the material from the object being sliced
            //crossSectionMaterials = target.GetComponent<Material>();
            SliceAndDice(target);
        }
    }

    public void SliceAndDice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();

        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterials);
            SetupSlicedComponents(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, crossSectionMaterials);
            SetupSlicedComponents(lowerHull);
            Destroy(target);
        }
    }

    public void SetupSlicedComponents(GameObject slicedObject)
    {
        slicedObject.layer = 6;
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        //rb.AddExplosionForce(moreCutForce, slicedObject.transform.position, 1);
    }
}

