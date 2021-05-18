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

    private Vector3[] linePositions;

    public float lineTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
        linePositions = new Vector3[gameObject.transform.childCount+1];
        Debug.Log(linePositions.Length);
        myLineRenderer.positionCount = 0;
        previousTarget = gameObject.transform.GetChild(0).transform.position;
        nextTarget = previousTarget;
    }

    // Update is called once per frame
    void Update()
    {
        myLineRenderer.startColor = myManager.myLineRenderer.startColor;
        myLineRenderer.endColor = myManager.myLineRenderer.endColor;

        if (myManager.selectedDots.Count <= gameObject.transform.childCount && myManager.squareReady == false){
            myLineRenderer.positionCount = (int)lineTotal;//-1;
            if(lineTotal < myManager.selectedDots.Count){
                lineTotal += .04f;
            } else if (lineTotal > myManager.selectedDots.Count + .15f){
                lineTotal -= .04f;
            }
            myLineRenderer.loop = false;
            GameObject.Find("White").GetComponent<Animator>().SetBool("solid", true);
            for(int i = myManager.selectedDots.Count; i < linePositions.Length; i++){
                linePositions[i] = Vector3.zero;
            }
        } else {
            myLineRenderer.positionCount = gameObject.transform.childCount;
            // myLineRenderer.positionCount = (int)lineTotal;
            
            // if(lineTotal < gameObject.transform.childCount){
            //     lineTotal+= .04f;
            // } else if (lineTotal > gameObject.transform.childCount + .15f){
            //     lineTotal-= .04f;
            // } else {
                 myLineRenderer.loop = true;
                 GameObject.Find("White").GetComponent<Animator>().SetBool("solid", false);
            // }
        }
        
        if (Input.GetMouseButton(0))
            {
                myLineRenderer.enabled = true;

                for(int i = 0; i <= gameObject.transform.childCount; i++){
                    if(myLineRenderer.positionCount > i){
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
                            //where the points start
                            if(myManager.squareReady == false){
                                if(linePositions[i] == Vector3.zero && i > 0){
                                    linePositions[i] = gameObject.transform.GetChild(i-1).transform.position;
                                }
                                //having the lines lerp
                                Debug.Log("CURRENTLY LERPING; " + i);
                                linePositions[i] = Vector3.Lerp(linePositions[i], gameObject.transform.GetChild(i).transform.position, .08f);
                            } else {
                                linePositions[i] = gameObject.transform.GetChild(i).transform.position;
                            }
                            myLineRenderer.SetPosition(i, linePositions[i]);
                        } else {
                            myLineRenderer.SetPosition(i, finalTarget.transform.position);
                            Debug.Log("final target");
                        }
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
