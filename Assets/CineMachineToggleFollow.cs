using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CineMachineToggleFollow : MonoBehaviour
{
    public CinemachineVirtualCamera vcCamera;

    public GameObject Eini;
    private bool followed;

    private void Start()
    {
        followed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && followed == false)
        {
            vcCamera.Follow = Eini.transform;
            followed = true;
        }
        else if(Input.GetKeyUp(KeyCode.E) && followed == true)
        {
            vcCamera.Follow = null;
            followed= false;
        }
    }
}
