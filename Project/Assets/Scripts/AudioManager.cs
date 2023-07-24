
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //array which contain the music play in game : 
    public AudioClip[] playlist;

    //the player : 
    public AudioSource audioSource;

    private int musicIndex;


    //as the inventory will be regularly used we create a static instance of it to access to it anywhere (singleton method)
    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of AudioManager in the scene");
            return;
        }

        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        musicIndex = 0;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if the music is stop : 
        if (!audioSource.isPlaying)
        {
            //play the next music : 
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }


    public AudioSource playClipAt(AudioClip clip, Vector3 pos)
    {
        //create a new game object to store the data :
        GameObject tempGO = new GameObject("TempAudio");
        //set to the correct location : 
        tempGO.transform.position = pos;
        //add to the temp game object a audio source :
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        //load the sound to play : 
        audioSource.clip = clip;

        //we play the sound 
        audioSource.Play();

        //finally we Destroy the object at the end of the sound : 
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
