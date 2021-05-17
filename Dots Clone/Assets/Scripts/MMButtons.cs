using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MMButtons : MonoBehaviour
{
    public Button timeButton;
    public Button matchButton;
    public Button infiniteButton;

    public Button playButton;
    public Button creditsButton;

    public SoundManager soundManager;

    public Color originalSelectedColor;

    public int modeTracker;


    // Start is called before the first frame update
    void Start()
    {
        modeTracker = 0;

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

        Button playBtn = playButton.GetComponent<Button>();
        //playBtn.onClick.AddListener(play);

        Button infiniteBtn = infiniteButton.GetComponent<Button>();
        //infiniteBtn.onClick.AddListener(setInfinite);

        Button timeBtn = timeButton.GetComponent<Button>();
        //timeBtn.onClick.AddListener(setTime);

        Button matchBtn = matchButton.GetComponent<Button>();
        //matchBtn.onClick.AddListener(setMatch);

        Button creditsBtn = creditsButton.GetComponent<Button>();
        //creditsBtn.onClick.AddListener(credits);

        //starts the game with infinite selected
        //constructor for color block class. setting new color block to the button color
        ColorBlock colors = infiniteBtn.colors;
        originalSelectedColor = colors.normalColor;
        colors.normalColor = colors.selectedColor;
        //setting the color block on this gameobject is now the one we made in code
        infiniteBtn.colors = colors;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        soundManager.PlaySound(soundManager.btnClick);

        Debug.Log("should play");
        if(modeTracker == 0)
        {
            //SceneManager.LoadScene();
        }

        if(modeTracker == 1)
        {
            SceneManager.LoadScene("Match Blitz");
        }

        if(modeTracker == 2)
        {
            SceneManager.LoadScene("Time Blitz");
        }
    }

    public void setInfinite()
    {
        soundManager.PlaySound(soundManager.btnClick);

        modeTracker = 0;
        Debug.Log("infinite " + modeTracker);

        //start infinite selected, but once other buttons are clicked, set it to normal
        ColorBlock colors = infiniteButton.GetComponent<Button>().colors;
        colors.normalColor = originalSelectedColor;
        infiniteButton.GetComponent<Button>().colors = colors;

    }

    public void setMatch()
    {
        soundManager.PlaySound(soundManager.btnClick);

        //modeTracker = 1;
       
        
        modeTracker = 1;

        Debug.Log("match " + modeTracker);

        ColorBlock colors = infiniteButton.GetComponent<Button>().colors;
        colors.normalColor = originalSelectedColor;
        infiniteButton.GetComponent<Button>().colors = colors;

    }

    public void setTime()
    {
        soundManager.PlaySound(soundManager.btnClick);

        
        modeTracker = 2;
                   
        Debug.Log("time " + modeTracker);

        ColorBlock colors = infiniteButton.GetComponent<Button>().colors;
        colors.normalColor = originalSelectedColor;
        infiniteButton.GetComponent<Button>().colors = colors;

    }

    public void credits()
    {
        soundManager.PlaySound(soundManager.btnClick);

        SceneManager.LoadScene("Credits");
    }
    
}
