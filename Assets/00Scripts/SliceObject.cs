using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.InputSystem; 

public class SliceObject : MonoBehaviour
{
    [SerializeField] GameObject particle;

    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator; 
    public LayerMask slicebleLayer;
    public AudioSource clip;

    public Material crossSectionMaterial;
    public float cutForce = 2000f;


    private void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, slicebleLayer);

        if (hasHit)
        {
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }
    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize(); 
        
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        clip.Play();
        GameObject explosion = Instantiate(particle, transform.position, transform.rotation);

        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            SetupSlicedComponent(upperHull);

            GameObject loverHull = hull.CreateLowerHull(target, crossSectionMaterial);
            SetupSlicedComponent(loverHull);

            Destroy(target);
        }

    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
        Destroy(slicedObject, 5f);
    }
}
