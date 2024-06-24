
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FakeAnimator : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] List<Sprite> animationFrames;
    [SerializeField] List<Sprite> nextAnimation;
    [SerializeField] int currentFrame;
    [SerializeField] bool playAnimation;
    [SerializeField] float frameRate;
    [SerializeField] float timer;
    [SerializeField] bool loop;

    //cache
    private PlayerMovement player;
    private FakeAnimation currentAnimation;
    [SerializeField] private List<AnimationEvent> events;

    private void Start()
    {
        if(events == null)
        {
            events = new List<AnimationEvent>();
        }
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (animationFrames.Count > 0)
        {
            sr.sprite = animationFrames[currentFrame];
        }
        if (loop == true)
        {
            if (playAnimation)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer += frameRate;
                    TriggerEvent();
                    if (currentFrame < animationFrames.Count - 1)
                    {
                        currentFrame++;
                    }
                    else
                    {
                        currentFrame = 0;
                    }                
                }
                TimerEvent();
            }
        }
        else
        {
            if (playAnimation)
            {
               
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    timer += frameRate;
                    TriggerEvent();
                    if (currentFrame < animationFrames.Count - 1)
                    {
                        currentFrame++;
                    }
                    else
                    {
                        currentFrame = animationFrames.Count - 1;
                    }  
                }
                TimerEvent();
            }
        }
    }

    public void Initialize(PlayerMovement _player)
    {
        player = _player;
    }

    public void PlayAnimation(FakeAnimation animationToPlay)
    {
        if (currentAnimation != animationToPlay)
        {
            currentAnimation = animationToPlay;
           
            loop = animationToPlay.Loop;
            animationFrames = animationToPlay.Sprites;
            frameRate = animationToPlay.FrameRate;
            if (animationToPlay.Events != null)
            {
                events = animationToPlay.Events;
            }

            timer = frameRate;
            currentFrame = 0;
        }
    }

    public void ChangeToNextAnimation()
    {
        animationFrames = nextAnimation;
        timer = frameRate;
        currentFrame = 0;
    }

    private void TriggerEvent()
    {
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].eventType == 0)
            {
                if (currentFrame == events[i].triggerFrame)
                {
                    events[i].act();
                    events.Remove(events[i]);
                }
            }
        }
    }

    private void TimerEvent()
    {
        for (int i = 0;i < events.Count; i++)
        {
            if(events[i].eventType == 1)
            {
                events[i].timer -= Time.deltaTime;

                if (events[i].timer <= 0)
                {
                    events[i].act();
                    events.Remove(events[i]); 
                }
            }
        }
    }

}

