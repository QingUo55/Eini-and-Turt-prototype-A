using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool doorOpening;
    private BoxCollider2D col;
    

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();     
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!doorOpening)
        {
            sr.sprite = GameAssets.Instance.DoorClose;
            col.enabled = true;
        }
        else
        {
            sr.sprite = GameAssets.Instance.DoorOpen;
            col.enabled = false;
        }
    }
}
