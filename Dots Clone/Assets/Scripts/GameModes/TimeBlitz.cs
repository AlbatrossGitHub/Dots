using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBlitz : MonoBehaviour
{
    public GameManager myManager;
    public GridManager gridManager;
    public SoundManager soundManager;

    public Text movesText;

    public int winCond;
    public int winCount;
    public int movesLeft;
    int endCounter;

    public RectTransform panel;
    public RectTransform placer;

    public Transform topBar;
    public Transform botBar;

    public Transform topPlacer;
    public Transform botPlacer;


    public float lerpSpeed;

    public float timer = 10;
    public bool timerStart = false;


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
        //moveBox.position = new Vector3(movePlacer.position.x, 500, 0);

        gridManager.movesLeft = movesLeft;

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime is the amount of time (in seconds) since the last frame
        //makes sure timescale doesnt slow down if the framrate is poop
        if (timerStart)
        {
            timer -= Time.deltaTime;
        }
        else if(myManager.selectedDot != null)
        {
            timerStart = true;
        }

        gridManager.timer = timer;
        
        if (timer <= 0 && gridManager.lastMatch)
        {

            //gridManager.GetComponent<GridManager>().enabled = false;
            //Debug.Log("level over");

            panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, placer.anchoredPosition, .04f);

            topBar.position = Vector3.Lerp(topBar.position, topPlacer.position, .01f);
            botBar.position = Vector3.Lerp(botBar.position, botPlacer.position, .01f);
            
            endCounter++;
        }


        //floor takes off the decimal points. finds closest whole number but always rounds down
        //(int) is a cast to make a float into an int for that instance
        if(timer > 0)
        {
            movesText.text = "" + (int)Mathf.Floor(timer + .5f);
        }
        else
        {
            movesText.text = "0";
        }

        if (endCounter == 1)
        {
            levelEnd();
        }

    }

    void levelEnd()
    {
        soundManager.PlaySound(soundManager.levelEnd);
    }

}
