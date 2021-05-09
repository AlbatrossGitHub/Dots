using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject selectedDot;
    public Vector3 lineEnd;
    public Vector3 dotOrigin;
    public Vector3 mousePos;

    public Text scoreText;

    public List<GameObject> selectedDots = new List<GameObject>();

    //the second dot that gamemanager collider hits
    public GameObject connectedDot;
    public GameObject endDot;

    public LineRenderer myLineRenderer;

    public bool squareReady = false;

    public GridManager gridManager;
    public MatchBlitz matchBlitz;

    public int score;

    public int matchCount;

    bool refreshDots = false;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z); //variable fo rthe mouse position
        lineEnd = mousePos; //line end is the variable for where the ray should end

        scoreText.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z); //get the mouse position
        Vector3 mousePosZ = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        gameObject.transform.position = mousePos; //moves the object this script is on to where the mouse is

        scoreText.text = "" + score;

        if (selectedDot != null) //if we have  clicked on a dot
        {
            myLineRenderer.positionCount = 0;
            if (Input.GetMouseButton(0))
            {
                myLineRenderer.enabled = true;

                if (selectedDots.Count > 1)
                {
                    myLineRenderer.positionCount = selectedDots.Count;

                    for (int i = 0; i < selectedDots.Count; i++)
                    {
                        myLineRenderer.SetPosition(i, selectedDots[i].transform.position);
                    }

                    if (endDot == null || endDot == selectedDot)
                    {
                        if (!squareReady)
                        {
                            myLineRenderer.positionCount += 1;
                            myLineRenderer.SetPosition(selectedDots.Count, mousePos);
                        }
                    }

                }

                else
                {
                    myLineRenderer.positionCount = 2;
                    lineEnd = mousePos;
                    myLineRenderer.SetPosition(0, selectedDot.transform.position);
                    myLineRenderer.SetPosition(1, lineEnd);
                }


                //Debug.Log("pressed");
            }

            else
            {
                myLineRenderer.enabled = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                selectedDots = new List<GameObject>();
                selectedDots.Add(selectedDot);

                selectedDot.GetComponent<DotBehavior>().selected = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                //GameObject.Find("GridManager").GetComponent<GridManager>().ColorClear(GameObject.Find("GridManager").GetComponent<GridManager>().tileColor[1]); THIS WAS JUST FOR TESTING

                if (selectedDot.GetComponent<DotBehavior>().selected && selectedDots.Count > 1)
                {
                    if (squareReady)
                    {
                        //if you make a square and it deletes everything
                        StartCoroutine(squareDelete());
                        refreshDots = false;
                    }
                    else
                    {
                        //straight line
                        for (int i = 0; i < selectedDots.Count; i++)
                        {
                            //Debug.Log(gridManager);                            
                            score += 100 * i;
                            selectedDots[i].GetComponent<Animator>().SetBool("delete", true);
                            //Destroy(selectedDots[i]); //deleting the dot itself

                        }

                        if (matchBlitz != null)
                        {
                            Debug.Log("hello I am here");
                            int movesLeft = matchBlitz.GetComponent<MatchBlitz>().movesLeft;
                            movesLeft--;

                            matchBlitz.GetComponent<MatchBlitz>().movesLeft = movesLeft;
                        }


                        matchCount++;
                        Debug.Log(matchCount);
                        refreshDots = true;
                    }
                    if (refreshDots)
                    {
                        selectedDots = new List<GameObject>();
                    }

                }
                if (refreshDots)
                {
                    myLineRenderer.positionCount = 0;
                    //foreach(GameObject dot in selectedDots)
                    //{
                    //    selectedDots.Remove(dot);
                    //}

                    selectedDots = new List<GameObject>();
                    selectedDot = null;
                }




            }


            if (selectedDot != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(selectedDot.transform.position, lineEnd, 25f); //
                Debug.DrawLine(selectedDot.transform.position, lineEnd, Color.red);
            }

        }



        //store information of direction of the dot

    }

    IEnumerator squareDelete()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("GridManager").GetComponent<GridManager>().ColorClear(selectedDot.GetComponent<DotBehavior>().color);
        squareReady = false;
        matchCount++;
        //Debug.Log(matchCount);
        if (matchBlitz != null)
        {
            //fDebug.Log("hello I am here");
            int movesLeft = matchBlitz.GetComponent<MatchBlitz>().movesLeft;
            movesLeft--;

            matchBlitz.GetComponent<MatchBlitz>().movesLeft = movesLeft;
        }
        myLineRenderer.positionCount = 0;
        //foreach(GameObject dot in selectedDots)
        //{
        //    selectedDots.Remove(dot);
        //}

        selectedDots = new List<GameObject>();
        selectedDot = null;

    }

    public void squareAnim()
    {
        foreach (GameObject d in selectedDots)
        {
            if (d.GetComponent<Animator>().GetBool("selected") == true)
            {
                Debug.Log("goto final selected");
                //d.GetComponent<Animator>().SetBool("final selected", true);
                d.GetComponent<Animator>().SetBool("selected", true);

            }
            else
            {
                Debug.Log("go to regular selected");
                //d.GetComponent<Animator>().SetBool("selected", false);
                d.GetComponent<Animator>().SetBool("selected", true);
            }

            //d.GetComponent<Animator>().SetTrigger("selected trigger");

        }

        gridManager.ColorPulse(selectedDot.GetComponent<DotBehavior>().color);
    }

}
