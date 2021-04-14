using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class oldDotBehavior : MonoBehaviour
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
        Vector3 selectedDot = GameObject.Find("Game Manager").GetComponent<GameManager>().selectedDot;
        if(transform.position.y > selectedDot.y && gameObject.tag == "Dot"){
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
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
            gameObject.GetComponent<BoxCollider2D>().enabled = false; //   REMEMBER TO TURN THIS BACK ON LATER
            
            
        }
        
    }

    void OnMouseUp()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }


    //click first dot drag to other dots.
}
*/
