using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderBehavior : MonoBehaviour
{

    public LineRenderer myLineRenderer;

    public GameManager myManager;

    public Vector3 nextTarget;

    public Vector3 lineEnd;

    public Vector3 previousTarget;

    public GameObject finalTarget;

    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer.positionCount = 0;

        previousTarget = gameObject.transform.GetChild(0).transform.position;
        nextTarget = previousTarget;
    }

    // Update is called once per frame
    void Update()
    {

        myLineRenderer.startColor = myManager.myLineRenderer.startColor;
        myLineRenderer.endColor = myManager.myLineRenderer.endColor;

        myLineRenderer.positionCount = myManager.selectedDots.Count;//-1;
        
        if (Input.GetMouseButton(0))
            {
                myLineRenderer.enabled = true;

                for(int i = 0; i <= gameObject.transform.childCount; i++){
                    Debug.Log("i is" + i);
                    Debug.Log("childCount is" + gameObject.transform.childCount);
            //where will the line end when its done lerping
            //previousTarget = nextTarget;
            //nextTarget = gameObject.transform.GetChild(i).transform.position;

            //if(nextTarget != null){
                // Debug.Log("should lerp");
                // lineEnd = Vector3.Lerp(previousTarget, nextTarget, .04f);
                // myLineRenderer.SetPosition(i-1, lineEnd);
            //}
            // lineEnd = Vector3.Lerp(gameObject.transform.GetChild(i).transform.position, gameObject.transform.GetChild(i+1).transform.position, .04f);
            // myLineRenderer.SetPosition(i, lineEnd);
                    if(gameObject.transform.childCount >= i){
                        myLineRenderer.SetPosition(i, gameObject.transform.GetChild(i).transform.position);
                    } else {
                        myLineRenderer.SetPosition(i, finalTarget.transform.position);
                        Debug.Log("final target");
            // if()
            //     Debug.Log("should be null");
            //}

            // if(gameObject.transform.GetChild(i) == null){
            //     Debug.Log("should be null");
            // }

            //if more positions than children stop
                    }
                }

            } else {
                myLineRenderer.enabled = false;
            }

        

        


        //panel.anchoredPosition = Vector3.Lerp(panel.anchoredPosition, placer.anchoredPosition, .04f);

        //lineEnd = Vector3.Lerp(gameObject.transform.GetChild(|i-1|).transform.position, gameObject.transform.GetChild(i).transform.position, .04f);

        //myLineRenderer.SetPosition(lastPosition, gameObject.transform.GetChild(i).transform.position)

        //where will the line end when it is done lerping
    }
}
