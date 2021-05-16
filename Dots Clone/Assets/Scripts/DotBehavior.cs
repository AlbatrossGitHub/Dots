using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour
{

    public GameManager myManager;

    

    public SoundManager soundManager;

    public bool selected = false; //bool for whether the dot is selected or not

    public int gridX;

    public int gridY;

    public Color color;

    public int selectionCounter = 0; //turn this into an enum later

    public Vector3 gridPosition;

    public float step = .1f;

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        //set grid position
        //gridPosition = gameObject.transform.position;

        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(gameObject.transform.position, gridPosition) > .05f)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, gridPosition, step);
        }

        // if(selected == true){
        //     myAnim.SetBool("selected", true);
        // }
    }

    void OnMouseDown()
    {
        myManager.selectedDot = gameObject; //lowercase G means the one we are on        
        if (myManager.isActiveAndEnabled == true)
        {
            Debug.Log("play clicked when selected");
            
            myAnim.SetBool("selected", true);

            soundManager.PlayConnect(1);
        }
        myManager.myLineRenderer.startColor = color;
        myManager.myLineRenderer.endColor = color;
        //when we click the mouse, this dot becomes the selected dot
        //myAnim.SetBool("selected", true);
    }



    void OnMouseEnter()
    {
        myAnim.SetBool("hover", true);
        if(myManager.selectedDots.Count > 0){ //if the x and y is within one of this one, and if it is not outside the bounds
            int xPrevious = 0;
            int yPrevious = 0;
            //for debugging when a dot is being accesssed when its disappearing
            if(myManager.selectedDots[myManager.selectedDots.Count -1] != null)
            {
                xPrevious = myManager.selectedDots[myManager.selectedDots.Count - 1].GetComponent<DotBehavior>().gridX;
                yPrevious = myManager.selectedDots[myManager.selectedDots.Count - 1].GetComponent<DotBehavior>().gridY;
            }
            else
            {
                myManager.selectedDots = new List<GameObject>();
                myManager.myLineRenderer.positionCount = 0;
                return;
            }

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
                    //adding dots to list when selected (NOT square)
                    if (!myManager.selectedDots.Contains(gameObject) && myManager.squareReady == false)
                    {
                        myManager.selectedDots.Add(gameObject);
                        if (myManager.isActiveAndEnabled == true)
                        {
                            //myAnim.SetTrigger("selected trigger");
                            Debug.Log("go to regular connected selected");
                            myAnim.SetBool("selected", true);

                            soundManager.PlayConnect(myManager.selectedDots.Count);
                        }

                    } else {
                        if(myManager.selectedDots[myManager.selectedDots.Count - 1] == gameObject && selectionCounter == 1){ //if this is the last thing on the list
                            if(myManager.squareReady == false){
                                myManager.selectedDots.Remove(gameObject);
                                GameObject.Find("White").GetComponent<Animator>().SetBool("solid", true);
                                myAnim.SetBool("selected", false);
                            } else {
                                myManager.squareReady = false;
                                GameObject.Find("White").GetComponent<Animator>().SetBool("solid", true);
                                myManager.selectedDots.RemoveAt(myManager.selectedDots.Count-1);
                                //myAnim.SetBool("selected", false);
                            }
                            selectionCounter = 2;
                            myManager.endDot = null;
                        }
                        if(selectionCounter < 2 && myManager.selectedDots.Count - myManager.selectedDots.IndexOf(gameObject) >= 3 && myManager.squareReady == false){
                            myManager.selectedDots.Add(gameObject);
                            myManager.squareReady = true;//GameObject.Find("GridManager").GetComponent<GridManager>().ColorClear(color);
                            GameObject.Find("White").GetComponent<Animator>().SetBool("solid", false);
                            //myAnim.SetTrigger("selected trigger");
                            myManager.squareAnim();

                            soundManager.PlaySound(soundManager.squareConnect);
                        }
                    }
                }
            }
        }
    }

    void OnMouseExit()
    {
        myAnim.SetBool("hover", false);
        myManager.endDot = null;
        //Debug.Log("I am NOT OVER this!");
        if(selectionCounter == 0){
            selectionCounter = 1;
        }
        if(selectionCounter == 2){
            selectionCounter = 0;
        }


    }

    private void OnMouseUpAsButton()
    {
        if(myManager.selectedDots.Count == 1)
        {
            myManager.selectedDot = null;
        }
        
        myAnim.SetBool("selected", false);

        
    }

    public void DestroyGameObject()
    {
        Debug.Log(transform.localScale);
        myManager.gridManager.gridArray[gridX, gridY].dot = null; //removing the dot from the datastructure
        for (int c = 0; c < myManager.gridManager.tileColor.Length; c++)
        {
            if (myManager.gridManager.tileColor[c] == color)
            {
                myManager.gridManager.prevColor = c;
            }
        }


        
        Destroy(gameObject);
    }

    public void ColliderOff()
    {
        
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Debug.Log(gameObject.GetComponent<CircleCollider2D>().enabled);
    }

    public void boolFalse()
    {
        //myAnim.SetBool("selected", false);
    }

    public void OnMouseUp(){
        myAnim.SetBool("selected", false);
    }

}
