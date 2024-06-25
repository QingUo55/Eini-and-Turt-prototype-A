using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    //enemySprites List


    //playerSprites List
    public FakeAnimation IdleAnimation;
    public FakeAnimation WalkAnimation;
    public FakeAnimation JumpedAnimation;
    public FakeAnimation FallAnimation;

    //vfx list
    public VFXAnimator VFX_Jump;

    //GameObjects List
    public Sprite DoorOpen;
    public Sprite DoorClose;

    private static GameAssets instance;

    public static GameAssets Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddEventsToAnimation()
    {
        IdleAnimation.AddEvent(new AnimationEvent(() => Debug.Log("Test"), 5));
    }
}
