using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject selectedDot;
    public Vector3 lineEnd;
    public Vector3 dotOrigin;
    public Vector3 mousePos;

    //the second dot that gamemanager collider hits
    public GameObject connectedDot;
    public GameObject endDot;

    public LineRenderer myLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mousePos = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z); //variable fo rthe mouse position
        lineEnd = mousePos; //line end is the variable for where the ray should end
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log("collided");
    //     lineEnd = mousePos;
    //     if (collision.gameObject.tag == "Dot" && collision.gameObject != selectedDot) //if it has the dot tag and is not the selected dot
    //     {
    //         Debug.Log("if statement");
    //         dotOrigin = collision.gameObject.transform.position;
    //         lineEnd = dotOrigin;
    //     }
    //     else
    //     {
    //         lineEnd = mousePos;
    //     }
    //     //if(the Game manager hitbox is collding with a dot hitbox && the
    //     //game manager hitbox is NOT colliding with the dot that we are getting the selectedDot variable from)
    //     //{ dotOrigin = coordinates of the dot that the gamemanager is colliding with
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.tag == "Dot" && collision.gameObject != selectedDot)
    //     {
    //         lineEnd = mousePos;

    //     }
    // }


    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z); //get the mouse position
        Vector3 mousePosZ = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        gameObject.transform.position = mousePos; //moves the object this script is on to where the mouse is



        if (selectedDot != null) //if we have  clicked on a dot
        {

            if(endDot != null){
                lineEnd = endDot.transform.position;
            } else {
                lineEnd = mousePos;
            }

            myLineRenderer.SetPosition(0, selectedDot.transform.position);
            myLineRenderer.SetPosition(1, lineEnd);

            // RaycastHit mHit;
            // // = Physics.Raycast(mousePos, mousePosZ, 20f);
            // if(Physics.Raycast(mousePos, mousePosZ, out mHit, 20f)){
            //     lineEnd = mHit.collider.gameObject.transform.position;
            // } else {
            //     lineEnd = mousePosZ;
            // }

            //lineEnd = mousePos;

            RaycastHit2D hit = Physics2D.Raycast(selectedDot.transform.position, lineEnd, 25f); //
            Debug.DrawLine(selectedDot.transform.position, lineEnd, Color.red);
            // if (hit != null)
            // {
            //     lineEnd = dotOrigin;
            // }
        }

        /*if(Input.GetMouseButtonDown(0)){

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            

            //GameObject theDot = GameObject.Find("Dot");
            //GameManager dotScript = theDot.GetComponent<DotBehavior>();

           // selectedDot = GameObject.Find("Dot").GetComponent<DotBehavior>().chosenDot;

            Vector3 direction = Vector3.left;//(selectedDot.transform.position - mousePos).normalized;

            RaycastHit2D hit = Physics2D.Raycast(selectedDot.transform.position, mousePos, 2f);

            Debug.DrawRay(selectedDot.transform.position, direction);

            Debug.Log(hit);
            Debug.Log(hit.collider.gameObject.name);
        }
        */


    }

    
}
