using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherGameManager : MonoBehaviour
{

    public GameObject selectedDot;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

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
    }
}
