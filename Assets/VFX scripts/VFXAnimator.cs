using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAnimator : MonoBehaviour
{
    //cachce
    [SerializeField] List<Sprite> animationFrames;

    //variables
    private List<Sprite> currentAnimationFrames;
    private SpriteRenderer sr;
    private Transform tf;
    [SerializeField] int currentFrame;
    [SerializeField] float frameRate;
    [SerializeField] float timer;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        currentAnimationFrames = animationFrames;
        frameRate = 0.09f;
        timer = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        sr.sprite = currentAnimationFrames[currentFrame];
        if(timer < 0)
        {
            if (currentAnimationFrames.Count > 0)
            {
                currentFrame += 1;
            }
            timer += frameRate;
        }

        if(currentFrame == currentAnimationFrames.Count - 1)
        {
            Destroy(gameObject);
        }
    }
}
