using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchBlitz : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        movesLeft = winCond;
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
        //moveBox.position = new Vector3(movePlacer.position.x, 500, 0);

        

    }

    // Update is called once per frame
    void Update()
    {
        winCount = myManager.GetComponent<GameManager>().matchCount;
        if(winCount == winCond)
        {
            myManager.GetComponent<GameManager>().enabled = false;
            //gridManager.GetComponent<GridManager>().enabled = false;
            //Debug.Log("level over");

            panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, placer.anchoredPosition, .04f);

            moveBox.position = Vector3.Lerp(moveBox.position, movePlacer.position, lerpSpeed);
            scoreBox.position = Vector3.Lerp(scoreBox.position, scorePlacer.position, lerpSpeed);
            backBox.position = Vector3.Lerp(backBox.position, backPlacer.position, lerpSpeed);
        }



        movesText.text = "" + movesLeft;
    }

   


}
