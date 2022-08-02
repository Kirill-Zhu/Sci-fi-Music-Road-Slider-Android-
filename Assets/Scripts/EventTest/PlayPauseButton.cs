using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayPauseButton : MonoBehaviour
{
    
    private Image currentImage;
    public Sprite pauseButton;
    public Sprite playButton;
    private void Start()
    {
        
        currentImage = GetComponent<Image>();
        currentImage.sprite = pauseButton;
        
        GlobalEventSystem.OnPlayPauseGame += ChangeIcon;
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnPlayPauseGame -= ChangeIcon;
    }
    public void ChangeIcon()
    {
        if (currentImage.sprite == pauseButton)
        {
          currentImage.sprite = playButton;
          
        
        }

        else
        {
            currentImage.sprite = pauseButton;

        }
    }
}
