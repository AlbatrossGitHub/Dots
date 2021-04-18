using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject tileObj;
    public int xSize, ySize;
    public Color[] tileColor; //making an array of colors
    public Vector3 startPos;
    public float xStagger, yStagger;

    List<GameObject> tiles = new List<GameObject>();

    GameObject[,] gridArray;

    // Start is called before the first frame update
    void Start()
    {
        gridArray = new GameObject [xSize, ySize];
        for(int x = 0; x < xSize; x++){
            for(int y = 0; y < ySize; y++){
                gridArray[x, y] = CreateTile(x, y); //our 2D array is an array of x that holds an array of y that holds an array of gameobjects.
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject CreateTile(int x, int y){ //this is a function which will return a gameobject value.
        GameObject newTile = Instantiate(tileObj, transform.position, transform.rotation);
        newTile.transform.position = new Vector3(startPos.x + x*xStagger, startPos.y + y*yStagger, transform.position.z);
        newTile.transform.SetParent(gameObject.transform);
        SpriteRenderer myRenderer = newTile.GetComponent<SpriteRenderer>(); //access new tile sprite renderer
        int randCol = Random.Range(0, tileColor.Length); //generate a random number between zero and however many colors I have
        tiles.Add(newTile);
        DotBehavior myBehavior = newTile.GetComponent<DotBehavior>();
        myBehavior.myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        myBehavior.color = tileColor[randCol];
        myRenderer.color = myBehavior.color; //set the color to whatever index the tile color has in the array
        myBehavior.gridX = x;
        myBehavior.gridY = y;
        return newTile;
    }

    public void ColorClear(Color Col){
        for(int i = 0; i < xSize; i++){
            for(int j = 0; j < ySize; j++){
                if(gridArray[i, j].GetComponent<DotBehavior>().color == Col){
                    Destroy(gridArray[i, j]);
                    gridArray[i, j] = null;
                }
            }
        }
    }

}
