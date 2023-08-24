using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    
    public void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Spawn();
            Debug.Log("Collision detected");
        }
    }
}
