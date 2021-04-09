using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Vector3 selectedDot;
    public Transform mouse;


    public Transform direction;

    //public Vector3 mousePos;

    //Camera.ScreenToWorldPoint



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //GameObject theDot = GameObject.Find("Dot");
        //GameManager dotScript = theDot.GetComponent<DotBehavior>();

        selectedDot = GameObject.Find("Dot").GetComponent<DotBehavior>().chosenDot;
        
    }

   

}

    //raycast detect, then triggers dot behavior script
    //each dot has

    //theres a mousepressed thing we can use

    //bool for connected

    //continuous raycast from mouse

    //counter to check if the mouse is hovering over a dot the second time or the first time and then determine if it should connect or detach

    //first thing is to detect mouse click and have line follow/extend
    //second to detect and connect to other dots
    //
    //
    //last is deteching and scoring


