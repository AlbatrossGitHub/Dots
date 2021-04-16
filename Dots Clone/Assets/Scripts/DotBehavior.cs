using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour
{

    public GameManager myManager;

    public bool selected = false;

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
        //gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }



    void OnMouseEnter()
    {
        myManager.endDot = gameObject;
        Debug.Log("I am OVER this!");//if()

        if (!myManager.selectedDots.Contains(gameObject))
        {
            myManager.selectedDots.Add(gameObject);
        }


    }

    void OnMouseExit()
    {
        myManager.endDot = null;
        Debug.Log("I am NOT OVER this!");
    }

}
