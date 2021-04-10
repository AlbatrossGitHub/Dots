using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherGameManager : MonoBehaviour
{

    public GameObject selectedDot;
    public Vector3 lineEnd;
    public Vector3 dotOrigin;
    public Vector3 mousePos;

    //the second dot that gamemanager collider hits
    public GameObject connectedDot;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lineEnd = mousePos;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        lineEnd = mousePos;
        if (collision.gameObject.tag == "Dot" && collision.gameObject != selectedDot)
        {
            dotOrigin = collision.gameObject.transform.position;
            lineEnd = dotOrigin;

        }
        else
        {
            lineEnd = mousePos;
        }

        //if(the Game manager hitbox is collding with a dot hitbox && the
        //game manager hitbox is NOT colliding with the dot that we are getting the selectedDot variable from)
        //{ dotOrigin = coordinates of the dot that the gamemanager is colliding with
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dot" && collision.gameObject != selectedDot)
        {
            lineEnd = mousePos;

        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //get the mouse position
        gameObject.transform.position = mousePos;

        if (selectedDot != null)
        {
            //lineEnd = mousePos;

            RaycastHit2D hit = Physics2D.Raycast(selectedDot.transform.position, lineEnd, 25f);
            Debug.DrawLine(selectedDot.transform.position, lineEnd, Color.red);
            if (hit != null)
            {
                lineEnd = dotOrigin;
            }
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
