using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxEffector : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveX;
    public FixedJoint2D joint;

    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<FixedJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedToPlayer(PlayerMovement player)
    {
        Debug.Log("Touched");
        joint.connectedBody = player.GetComponent<Rigidbody2D>();
    }

    public void DetachFromPlayer()
    {
        Debug.Log("Untouched");
        joint.connectedBody = null;
    }
}
