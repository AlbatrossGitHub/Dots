using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgColorChangBehavior : MonoBehaviour
{

    public SpriteRenderer myRenderer;
    public GameObject myManager;

    // Start is called before the first frame update
    void Start()
    {
        //access my sprite renderer
        myRenderer = gameObject.GetComponent<SpriteRenderer>();

        //access the game manager to access its line renderer component later on
        myManager = GameObject.Find("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        //my color will be the color of the linerenderer
        myRenderer.color = myManager.GetComponent<LineRenderer>().startColor;
    }
}
