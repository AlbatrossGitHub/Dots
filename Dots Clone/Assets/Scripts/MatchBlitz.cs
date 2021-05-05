using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    // Start is called before the first frame update
    void Start()
    {
        movesText.text = "";
        movesLeft = winCond;
        panel.anchoredPosition = new Vector3(placer.anchoredPosition.x, 1500, 0);
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

            panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, placer.anchoredPosition, .1f);
        }



        movesText.text = "" + movesLeft;
    }
}
