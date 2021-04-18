using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour
{

    public GameManager myManager;

    public bool selected = false; //bool for whether the dot is selected or not

    public int gridX;

    public int gridY;

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
        myManager.endDot = gameObject; //if the mouse hovers over this dot, it becomes end dot, and adds it to the list if not on the list already
        //Debug.Log("I am OVER this!");
        if (!myManager.selectedDots.Contains(gameObject))
        {
            myManager.selectedDots.Add(gameObject);
        }


    }

    void OnMouseExit()
    {
        myManager.endDot = null;
        //Debug.Log("I am NOT OVER this!");
    }

}
