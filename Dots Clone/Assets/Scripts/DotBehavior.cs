using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour
{

    public GameManager myManager;

    public bool selected = false; //bool for whether the dot is selected or not

    public int gridX;

    public int gridY;

    public Color color;

    public int selectionCounter = 0; //turn this into an enum later

    public Vector3 gridPosition;

    public float step = .1f;

    // Start is called before the first frame update
    void Start()
    {
        //set grid position
        //gridPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(gameObject.transform.position, gridPosition) > .1f)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gridPosition, step);
        }
    }

    void OnMouseDown()
    {
        myManager.selectedDot = gameObject; //lowercase G means the one we are on
        myManager.myLineRenderer.startColor = color;
        myManager.myLineRenderer.endColor = color;
        //when we click the mouse, this dot becomes the selected dot
    }



    void OnMouseEnter()
    {
        if(myManager.selectedDots.Count > 0){ //if the x and y is within one of this one, and if it is not outside the bounds
            int xPrevious = myManager.selectedDots[myManager.selectedDots.Count-1].GetComponent<DotBehavior>().gridX;
            int yPrevious = myManager.selectedDots[myManager.selectedDots.Count-1].GetComponent<DotBehavior>().gridY;
            if(Mathf.Abs(gridX-xPrevious) <= 1){
                if(gridX-xPrevious != 0){
                    if(gridY-yPrevious != 0){
                        return;
                    }
                } else if(Mathf.Abs(gridY-yPrevious) > 1){
                    return;
                }
            }
            if(Mathf.Abs(gridX-xPrevious) <= 1 && Mathf.Abs(gridY-yPrevious) <= 1){
                if(myManager.selectedDot != null && myManager.selectedDot.GetComponent<DotBehavior>().color == color){
                    if(myManager.squareReady == false){
                        myManager.endDot = gameObject; //if the mouse hovers over this dot, it becomes end dot, and adds it to the list if not on the list already
                    }
                    //Debug.Log("I am OVER this!");
                    if (!myManager.selectedDots.Contains(gameObject) && myManager.squareReady == false)
                    {
                        myManager.selectedDots.Add(gameObject);
                    } else {
                        if(myManager.selectedDots[myManager.selectedDots.Count - 1] == gameObject && selectionCounter == 1){ //if this is the last thing on the list
                            if(myManager.squareReady == false){
                                myManager.selectedDots.Remove(gameObject);
                            } else {
                                myManager.squareReady = false;
                                myManager.selectedDots.RemoveAt(myManager.selectedDots.Count-1);
                            }
                            selectionCounter = 2;
                            myManager.endDot = null;
                        }
                        if(selectionCounter < 2 && myManager.selectedDots.Count - myManager.selectedDots.IndexOf(gameObject) >= 3 && myManager.squareReady == false){
                            myManager.selectedDots.Add(gameObject);
                            myManager.squareReady = true;//GameObject.Find("GridManager").GetComponent<GridManager>().ColorClear(color);
                        }
                    }
                }
            }
        }
    }

    void OnMouseExit()
    {
        myManager.endDot = null;
        //Debug.Log("I am NOT OVER this!");
        if(selectionCounter == 0){
            selectionCounter = 1;
        }
        if(selectionCounter == 2){
            selectionCounter = 0;
        }



    }

}
