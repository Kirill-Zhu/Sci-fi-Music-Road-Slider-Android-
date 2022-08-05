
using UnityEngine;
using System;

public class GlobalEventSystem: MonoBehaviour
{
    public static GlobalEventSystem instance;
    public static event Action OnShowScore;
    public static event Action OnPlayPauseGame;
    public static event Action OnNextSong;
    public static event Action OnPreviousSong;
    public static event Action OnSpeedUp;
    public static event Action OnSlowDown;
   

    private void Start()
    {
        #region SingleTon
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }
    public static void SendOnShowScore()
    {
         OnShowScore.Invoke();
    }

    public static void SendOnPlayPauseGame()
    {
        OnPlayPauseGame.Invoke();
    }

    public static void SendOnNextSong()      
    {
        OnNextSong.Invoke();
    }
    public static void SendOnPreviousSong()
    {
        OnPreviousSong.Invoke();
    }
    public static void SendOnSpeedUp()
    {
        OnSpeedUp.Invoke();
    }
    public static void SendOnSlowDown()
    {
        OnSlowDown.Invoke();
    }
}
