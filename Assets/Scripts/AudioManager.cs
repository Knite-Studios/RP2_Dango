using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Singleton<MonoBehaviour>
{
  
    public AudioSource mainSpeaker;
    public AudioSource playerSpeaker;
    [SerializeField]
    private AudioClip mainMenuClip;
    [SerializeField]
    private AudioClip bGMusicClip;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private AudioClip jumpClip;

    void Awake()
    {
        mainSpeaker = GetComponent<AudioSource>();
        playerSpeaker = GetComponentInChildren<AudioSource>();
    }
    void PlayMusic()
    {
        mainSpeaker.Play();
    }
   /* public void ToggleMute()
    {

        isMuted = !isMuted;
        mainSpeaker.mute = isMuted;
    }*/

    private void Update()
    {
     
    }

}


