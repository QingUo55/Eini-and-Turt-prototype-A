using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent
{
    public int eventType;
    /*
     * 0 = trigger type
     * 1 = time based events
     */
    public Action act;
    public int triggerFrame;
    public float timer;

    public AnimationEvent(Action _act, int _triggerFrame)
    {
        eventType = 0;
        act = _act;
        triggerFrame = _triggerFrame;
    }

    public AnimationEvent(Action _act, float _timer)
    {
        eventType = 0;
        act = _act;
        timer = _timer;
    }
}
