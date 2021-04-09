using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour
{
    public Color red, blue, green, yellow;
    public SpriteRenderer dotSprite;

    public int dotColor;
    public Vector3 chosenDot;


    // Start is called before the first frame update
    void Start()
    {
        colorGen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void colorGen()
    {
        int rand = UnityEngine.Random.Range(0, 4);

        if(rand == 0)
        {
            dotSprite.color = red;
            dotColor = rand;
        }

        if(rand == 1)
        {
            dotSprite.color = blue;
        }

        if(rand == 2)
        {
            dotSprite.color = green;
        }

        if(rand == 3)
        {
            dotSprite.color = yellow;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            chosenDot = gameObject.transform.position;
            
            
        }
        
    }

    void OnMouseExit()
    {
        
    }


    //click first dot drag to other dots.
}
