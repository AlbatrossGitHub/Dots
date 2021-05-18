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

    public Transform topBar;
    public Transform botBar;

    public Transform topPlacer;
    public Transform botPlacer;

    public float lerpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        movesLeft = winCond;
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
        //moveBox.position = new Vector3(movePlacer.position.x, 500, 0);
        //topBar.position = new Vector3(topPlacer.position.x, 500, 0);
        //botBar.position = new Vector3(botPlacer.position.x, -500, 0);

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
            topBar.position = Vector3.Lerp(topBar.position, topPlacer.position, .01f);
            botBar.position = Vector3.Lerp(botBar.position, botPlacer.position, .01f);

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
