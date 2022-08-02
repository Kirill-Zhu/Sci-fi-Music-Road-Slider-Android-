
using UnityEngine;
using System;

public class GlobalEventSystem: MonoBehaviour
{
    public static GlobalEventSystem instance;
    public static Action OnShowScore;
    public static Action OnPlayPauseGame;
    public static Action OnNextSong;
    public static Action OnPreviousSong;
   

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
}
