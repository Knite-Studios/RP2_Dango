using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();

            }
            return _instance;
        }
    }

    public AudioSource playerSpeaker;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private AudioClip GameOverClip;
    [SerializeField]
    private AudioClip jumpClip;
    [SerializeField]
    private AudioClip collectClip;

    void Awake()
    {
        playerSpeaker = GetComponent<AudioSource>();
        
    }


    public void PlayDeathSound()
    {
        playerSpeaker.clip = deathClip;
        playerSpeaker.Play();
        playerSpeaker.loop = false;
    }
    public void PlayJumpSound()
    {
        playerSpeaker.clip = jumpClip;
        playerSpeaker.Play();
        playerSpeaker.loop = false;
    }
    public void PlayCollectSound()
    {
        playerSpeaker.clip = collectClip;
        playerSpeaker.Play();
        playerSpeaker.loop = false;
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


