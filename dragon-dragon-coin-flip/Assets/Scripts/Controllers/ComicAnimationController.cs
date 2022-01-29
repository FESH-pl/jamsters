using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicAnimationController : MonoBehaviour
{
    private float previousFrameTime;
    private int currentFrameIndex = 0;
    public int maxFrameIndex;
    public List<CanvasGroup> frames;
    
    void Start()
    {
        previousFrameTime = Time.time;
    }

    
    void Update()
    {
        var timeSinceLastFrame = Time.time - previousFrameTime;
        
        if(timeSinceLastFrame > 1)
        {
            if (currentFrameIndex < maxFrameIndex)
                ShowNextFrame(currentFrameIndex + 1);
            else
                SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }

    }

    private void ShowNextFrame(int nextFrameIndex)
    {
        var currentFrame = frames[currentFrameIndex];
        var nextFrame = frames[nextFrameIndex];

        currentFrame.alpha = 0;
        nextFrame.alpha = 1;

        currentFrameIndex = nextFrameIndex;

        previousFrameTime = Time.time;
    }
}
