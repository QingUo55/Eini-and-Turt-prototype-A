using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Animation", fileName = "Animation")]
public class FakeAnimation : ScriptableObject
{
    public List<Sprite> Sprites;
    public float FrameRate;
    public List<AnimationEvent> Events;

    public bool Loop;

    public FakeAnimation(List<Sprite> _sprites, float _frameRate, List<AnimationEvent> _events)
    {
        Sprites = _sprites;
        FrameRate = _frameRate;
        Events = _events;
    }

    public void AddEvent(AnimationEvent animEvent)
    {
        if(Events == null)
        {
            Events = new List<AnimationEvent>();
        }
        Events.Add(animEvent);
    }
}
