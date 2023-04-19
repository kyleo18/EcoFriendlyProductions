using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            return instance;
        }
    }
    private AudioSource music;
    public AudioClip[] songs;
    public float volume;
    [SerializeField] private float trackTimer;
    [SerializeField] private float songsPlayed;
    [SerializeField] private bool[] beenPlayed;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        music = GetComponent<AudioSource>();
        beenPlayed = new bool[songs.Length];
        if (!music.isPlaying)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
    }

    
    void Update()
    {
        music.volume = volume;
        if (music.isPlaying)
        {
            trackTimer += 1 * Time.deltaTime;
        }
        if (!music.isPlaying || trackTimer >= music.clip.length)
        {
            ChangeSong(Random.Range(0, songs.Length));
        }
        
    }
    public void ChangeSong(int songPicked)
    {
        if(!beenPlayed[songPicked])
        {
            trackTimer = 0;
            songsPlayed++;
            beenPlayed[songPicked] = true;
            music.clip = songs[songPicked];
            music.Play();
        }
        else
        {
            music.Stop();
        }
        resetShuffle();
    }
    private void resetShuffle()
    {
        if (songsPlayed == songs.Length)
        {
            songsPlayed = 0;
            for (int i = 0; i < songs.Length; i++)
            {
                if (i == songs.Length)
                {
                    break;
                }
                else
                {
                    beenPlayed[i] = false;
                }
            }
        }
    }
}
