using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchBlitz : MonoBehaviour
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

    //public Transform moveBox;
    //public Transform scoreBox;
    //public Transform backBox;
    //public Transform settingsBox;

    //public Transform movePlacer;
    //public Transform scorePlacer;
    //public Transform backPlacer;
    ////public Transform settingsPlacer;

    public float lerpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        movesLeft = winCond;
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
        //moveBox.position = new Vector3(movePlacer.position.x, 500, 0);

        gridManager.movesLeft = movesLeft;

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        winCount = myManager.GetComponent<GameManager>().matchCount;
        if(winCount == winCond && gridManager.lastMatch)
        {
            
            //gridManager.GetComponent<GridManager>().enabled = false;
            //Debug.Log("level over");

            panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, placer.anchoredPosition, .04f);

            endCounter++;

        }

        if (endCounter == 1)
        {
            levelEnd();
        }

        movesText.text = "" + movesLeft;
    }


   void levelEnd()
    {
        soundManager.PlaySound(soundManager.levelEnd);
    }


}
