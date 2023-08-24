using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawnThrowable : MonoBehaviour
{
    [SerializeField] GameObject throwable;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] AudioSource clip;
    [SerializeField] GameObject particle;

    private void ReSpawn()
    {
        throwable.transform.position = spawnPoint.transform.position; 
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            clip.Play();
            Destroy (other.gameObject);
            GameObject explosion = Instantiate(particle, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Respawn")
        {
            StartCoroutine(RespawnDelay());
            
        }
    }     
    
    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(5f);

        ReSpawn();
    }
}
