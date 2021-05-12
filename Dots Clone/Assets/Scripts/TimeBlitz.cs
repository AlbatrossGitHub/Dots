using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBlitz : MonoBehaviour
{
    public GameManager myManager;
    public GridManager gridManager;

    public Text movesText;

    public int winCond;
    public int winCount;
    public int movesLeft;

    public RectTransform panel;
    public RectTransform placer;

    public Transform moveBox;
    public Transform scoreBox;
    public Transform backBox;
    //public Transform settingsBox;

    public Transform movePlacer;
    public Transform scorePlacer;
    public Transform backPlacer;
    //public Transform settingsPlacer;

    public float lerpSpeed;

    public float timer = 60;
    public bool timerStart = false;


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
        //moveBox.position = new Vector3(movePlacer.position.x, 500, 0);

        gridManager.movesLeft = movesLeft;

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

            moveBox.position = Vector3.Lerp(moveBox.position, movePlacer.position, lerpSpeed);
            scoreBox.position = Vector3.Lerp(scoreBox.position, scorePlacer.position, lerpSpeed);
            backBox.position = Vector3.Lerp(backBox.position, backPlacer.position, lerpSpeed);
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
        
    }



}
