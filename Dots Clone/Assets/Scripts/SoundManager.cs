using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    AudioSource effectSource, musicSource;

    [SerializeField]
    AudioClip connect1, connect2, connect3, connect4, connect5, connect6, connect7;
    
    public AudioClip btnClick, btnBack;
    
    public AudioClip squareConnect, delete, levelEnd;

    //static variables are saved across the instances of this script
    public static SoundManager main;

    //keeping the sound manager around even after scene reload
    //void awake is called before start
    private void Awake()
    {
        if (!main)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(musicSource.isPlaying == false)
        {
            //musicSource.Play();
            //musicSource.loop = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip a)
    {
        effectSource.clip = a;
        effectSource.Play();
    }

    public void PlayConnect(int c)
    {
        switch (c)
        {
            case 1:
                effectSource.clip = connect1;                
                break;

            case 2:
                effectSource.clip = connect2;
                break;

            case 3:
                effectSource.clip = connect3;
                break;

            case 4:
                effectSource.clip = connect4;
                break;

            case 5:
                effectSource.clip = connect5;
                break;

            case 6:
                effectSource.clip = connect6;
                break;

            default:
                effectSource.clip = connect7;
                break;

        }
        //play the sound
        effectSource.Play();

    }

}
