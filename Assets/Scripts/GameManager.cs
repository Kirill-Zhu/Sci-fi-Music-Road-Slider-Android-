
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            GlobalEventSystem.SendOnPlayPauseGame();
        }           
    }

    public void ExitGame()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
        Application.Quit();
     #endif
    }

   
}
