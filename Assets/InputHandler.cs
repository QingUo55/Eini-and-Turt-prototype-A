using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputHandler;

public class InputHandler : MonoBehaviour 
{
    public delegate void MovementPressed(float direction);
    public delegate void MovementReleased(float direction);
    public delegate void JumpPressed();
    public delegate void JumpReleased();
    public delegate void SprintPressed(bool sprinting);
    public delegate void SprintReleased(bool sprinting);
    public delegate void CharacterSwitched(bool switched);
    public delegate void PushButtonDown();
    public delegate void PushButtonUp();

    public event MovementPressed OnMovementPressed;
    public event MovementReleased OnMovementReleased;
    public event JumpPressed OnJumpPressed;
    public event JumpReleased OnJumpReleased;
    public event SprintPressed OnSprintPressed;
    public event SprintReleased OnSprintReleased;
    public event CharacterSwitched OnCharacterSwitched;
    public event PushButtonDown OnPushButtonDown;
    public event PushButtonUp OnPushButtonUp;


    private static InputHandler instance;
    public static InputHandler Instance => instance;

    // Start is called before the first frame update
    public void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        //movement
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            OnMovementPressed?.Invoke(Input.GetAxisRaw("Horizontal"));
        }
        else
        {
            OnMovementReleased?.Invoke(Input.GetAxisRaw("Horizontal"));
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            OnJumpPressed?.Invoke();
        }
        else
        {
            OnJumpReleased?.Invoke();
        }

        //sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            OnSprintPressed?.Invoke(Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            OnSprintReleased?.Invoke(Input.GetKey(KeyCode.LeftShift));
        }

        //switch character
        if(Input.GetKeyDown(KeyCode.Q))
        {
            OnCharacterSwitched?.Invoke(Input.GetKeyDown(KeyCode.Q));
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            OnPushButtonDown?.Invoke();
        }
        
        if (Input.GetKeyUp(KeyCode.C))
        {
            OnPushButtonUp?.Invoke();
        }
    }
}
