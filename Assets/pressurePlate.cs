using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlate : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField]private Door door;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        RaycastHit2D upRayHit = Physics2D.Raycast(new Vector3(col.bounds.center.x, col.bounds.center.y + 1f), Vector3.up, 0.5f);
        Debug.DrawRay(transform.position, Vector3.up * 0.5f);
        
        
        if(upRayHit)
        {  
            if(upRayHit.collider.GetComponent<boxEffector>() != false)
            {
                Debug.Log("stepped");
                door.doorOpening = true;
            }
        }
        else
        {
            door.doorOpening = false;
        }
    }
}
