using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject selectedDot;
    public Vector3 lineEnd;
    public Vector3 dotOrigin;
    public Vector3 mousePos;

    public List<GameObject> selectedDots = new List<GameObject>();

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


    // Update is called once per frame
    void Update()
    {
        mousePos = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z); //get the mouse position
        Vector3 mousePosZ = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        gameObject.transform.position = mousePos; //moves the object this script is on to where the mouse is



        if (selectedDot != null) //if we have  clicked on a dot
        {

            myLineRenderer.positionCount = 0;

            

            if(Input.GetMouseButton(0))
            {
                myLineRenderer.enabled = true;

                if (selectedDots.Count > 1)
                {
                    myLineRenderer.positionCount = selectedDots.Count;

                    for (int i = 0; i < selectedDots.Count; i++)
                    {
                        myLineRenderer.SetPosition(i, selectedDots[i].transform.position);
                    }

                    if(endDot == null || endDot == selectedDot)
                    {

                        myLineRenderer.positionCount += 1;
                        myLineRenderer.SetPosition(selectedDots.Count, mousePos);

                    }

                }

                else
                {
                    myLineRenderer.positionCount = 2;
                    lineEnd = mousePos;
                    myLineRenderer.SetPosition(0, selectedDot.transform.position);
                    myLineRenderer.SetPosition(1, lineEnd);
                }

                
                Debug.Log("pressed");
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

                if (selectedDot.GetComponent<DotBehavior>().selected && selectedDots.Count > 1)
                {
                    for (int i = 0; i < selectedDots.Count; i++)
                    {
                        Destroy(selectedDots[i]);
                    }

                    selectedDots = new List<GameObject>();
                }

                myLineRenderer.positionCount = 0;
                //foreach(GameObject dot in selectedDots)
                //{
                //    selectedDots.Remove(dot);
                //}

                selectedDots = new List<GameObject>();
                selectedDot = null;

                

            }

            
            if(selectedDot != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(selectedDot.transform.position, lineEnd, 25f); //
                Debug.DrawLine(selectedDot.transform.position, lineEnd, Color.red);
            }

        }

        
        //store information of direction of the dot

    }

    
}
