using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float movementSpeed = 4f;
    [SerializeField] float rotationalDamp = .5f;
    [SerializeField] float raycastoffset = 2.5f;
    [SerializeField] float detectionDistance = 20f;
        

    
    void Update()
    {
        Pathfinding();
        Turn();
        Move();
        
    }

    private void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp *  Time.deltaTime);
    }

    private void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    private void Pathfinding()
    {
        RaycastHit hit;
        Vector3 raycasroffset = Vector3.zero;


        Vector3 left = transform.position - transform.right * raycastoffset;
        Vector3 right = transform.position + transform.right * raycastoffset;
        Vector3 up = transform.position + transform.up * raycastoffset;
        Vector3 down = transform.position - transform.up * raycastoffset;

        Debug.DrawLine(left, transform.forward * detectionDistance, Color.red);
        Debug.DrawLine(right, transform.forward * detectionDistance, Color.red);
        Debug.DrawLine(up, transform.forward * detectionDistance, Color.red);
        Debug.DrawLine(down, transform.forward * detectionDistance, Color.red);

        if (Physics.Raycast(left, transform.forward, out hit, detectionDistance)) 
        {
            raycasroffset += Vector3.right;
        } 
        else if (Physics.Raycast(right, transform.forward, out hit, detectionDistance)) 
        {
            raycasroffset -= Vector3.right;
        }
        
        if (Physics.Raycast(up, transform.forward, out hit, detectionDistance)) 
        {
            raycasroffset -= Vector3.up;
        } 
        else if (Physics.Raycast(down, transform.forward, out hit, detectionDistance)) 
        {
            raycasroffset += Vector3.up;
        }

        if (raycasroffset != Vector3.zero) 
        { 
            transform.Rotate(raycasroffset * 5f * Time.deltaTime);
        }
        else
        {
            Turn();
        }


    }

}
