using System.Collections;

using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] musicArray;
    public int songIndex;
    private bool songIsPlaying=false;
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        songIndex = Random.Range(0, musicArray.Length);
        audioSource.PlayOneShot(musicArray[songIndex]);
        songIsPlaying = true;

        #region Events
        GlobalEventSystem.OnPlayPauseGame += PlayPauseSong;
        GlobalEventSystem.OnNextSong += PlayNextSong;
        GlobalEventSystem.OnPreviousSong += PlayPreviousSong;
        #endregion
    }
    private void OnDestroy()
    {
        GlobalEventSystem.OnPlayPauseGame -= PlayPauseSong;
        GlobalEventSystem.OnNextSong = PlayNextSong;
        GlobalEventSystem.OnPreviousSong = PlayPreviousSong;
    }

    void Update()
    {
        if(!audioSource.isPlaying&&songIsPlaying)
        {
            PlayNextSong();
        }
    }
     
    public  void PlayNextSong()
    {
        if (songIndex >= musicArray.Length-1)
            songIndex = 0;
        else
            songIndex++;
        audioSource.Stop();
        audioSource.PlayOneShot(musicArray[songIndex]);     
    }

    public void PlayPreviousSong()
    {
        if (songIndex <= 0)
            songIndex = musicArray.Length-1;
        else
            songIndex--;

        audioSource.Stop();
        audioSource.PlayOneShot(musicArray[songIndex]);
    }
  public void PlayPauseSong()
    {
        songIsPlaying = !songIsPlaying;
        if(songIsPlaying)
            audioSource.UnPause();
        if(!songIsPlaying)
            audioSource.Pause();
    }
}
