using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowable : MonoBehaviour
{
    [SerializeField] GameObject throwable;
    [SerializeField] private Transform spawnPoint;
    
    [SerializeField] private float spawnValue;




    void Start()
    {
        
    }


    private void Update()
    {
        if (throwable.transform.position.y <= spawnValue)
        {
            ReSpawnPoint();
        }
    }

    private void ReSpawnPoint()
    {
        transform.position = spawnPoint.position; 
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy (other.gameObject);
            

        }
    }
    
}
