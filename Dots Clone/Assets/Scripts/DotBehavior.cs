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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        myManager.selectedDot = gameObject; //lowercase G means the one we are on
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
                    myManager.endDot = gameObject; //if the mouse hovers over this dot, it becomes end dot, and adds it to the list if not on the list already
                    //Debug.Log("I am OVER this!");
                    if (!myManager.selectedDots.Contains(gameObject))
                    {
                        myManager.selectedDots.Add(gameObject);
                    }
                }
            }
        }

    }

    void OnMouseExit()
    {
        myManager.endDot = null;
        //Debug.Log("I am NOT OVER this!");
    }

}
