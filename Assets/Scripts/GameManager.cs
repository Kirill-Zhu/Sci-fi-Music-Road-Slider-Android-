using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{    
    public static GameManager insntance;

    [SerializeField] AudioMixerGroup masterMixer;
    
    [Tooltip("Attach the main menu Game Object")]
    [SerializeField] GameObject mainMenu;
    private bool _mainMenuIsOpened = false;
    private void Start()
    {
        #region SINGLETONE
        if (insntance != null)
        {
            Destroy(this.gameObject);
        }
        else
            insntance = this;
        #endregion
        GlobalEventSystem.OnPlayPauseGame += Open_CloseMainMenu;
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnPlayPauseGame -= Open_CloseMainMenu;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Open_CloseMainMenu();
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
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeMasterVolume(float volume)
    {
        if (masterMixer != null)
            masterMixer.audioMixer.SetFloat("MasterVolume", volume);
    }
    public void Open_CloseMainMenu()
    {if(mainMenu!=null)
        {
            _mainMenuIsOpened = !_mainMenuIsOpened;
            if (_mainMenuIsOpened)
                mainMenu.SetActive(true);
            else
                mainMenu.SetActive(false);
        }

    }
}
