using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EiniAnimationHandler : MonoBehaviour
{
    [SerializeField] FakeAnimator EiniAnimator;

    private static EiniAnimationHandler instance;
    public static EiniAnimationHandler Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       GameAssets.Instance.AddEventsToAnimation();
        
    }

    public void PlayIdleAnimation()
    {
        EiniAnimator.PlayAnimation(GameAssets.Instance.IdleAnimation);
    }

    public void PlayWalkAnimation(int _moveX)
    {
        if(_moveX > 0 )
        {
            EiniAnimator.sr.flipX = false;
        }
        else if (_moveX < 0)
        {
            EiniAnimator.sr.flipX=true;
        }
        EiniAnimator.PlayAnimation(GameAssets.Instance.WalkAnimation);
    }
    public void PlayJumpAnimation()
    {
        EiniAnimator.PlayAnimation(GameAssets.Instance.JumpedAnimation);
    }

    public void PlayFallAnimation()
    {
        EiniAnimator.PlayAnimation(GameAssets.Instance.FallAnimation);
    }
}
