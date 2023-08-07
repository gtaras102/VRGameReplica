using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
