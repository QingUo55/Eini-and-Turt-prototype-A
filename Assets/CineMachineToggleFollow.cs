using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CineMachineToggleFollow : MonoBehaviour
{
    public CinemachineVirtualCamera vcCamera;

    public GameObject Eini;
    public GameObject Turt;
    private bool followed;

    private void Start()
    {
        followed = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(followed && GameHandler.Instance.ActiveCharacter == Character.Eini)
        {
            vcCamera.Follow = Eini.transform;
        }
        if (followed && GameHandler.Instance.ActiveCharacter == Character.Turt)
        {
            vcCamera.Follow = Turt.transform;
        }
    }
}
