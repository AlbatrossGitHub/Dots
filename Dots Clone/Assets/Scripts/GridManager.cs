using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameManager myManager;
    public GameObject tileObj;
    public int xSize, ySize;
    public Color[] tileColor; //making an array of colors
    public Vector3 startPos;
    public float xStagger, yStagger;

    List<GameObject> tiles = new List<GameObject>();

    public gridPos[,] gridArray;
    
    [Range(0, 1)]
    public float step = .1f;

    public int numColors;

    public struct gridPos
    {
        public GameObject dot;
        public Vector3 location;
        public gridPos(GameObject d, Vector3 l)
        {
            this.dot = d;
            this.location = l;
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        gridArray = new gridPos [xSize, ySize];
        for(int x = 0; x < xSize; x++){
            for(int y = 0; y < ySize; y++){
                GameObject newTile = CreateTile(x, y);
                gridArray[x, y] = new gridPos(newTile, newTile.transform.position); //our 2D array is an array of x that holds an array of y that holds an array of gameobjects.
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        dropDown();
        repopulate();
    }

    GameObject CreateTile(int x, int y){ //this is a function which will return a gameobject value.
        GameObject newTile = Instantiate(tileObj, transform.position, transform.rotation);
        newTile.transform.position = new Vector3(startPos.x + x*xStagger, startPos.y + y*yStagger, transform.position.z);
        newTile.transform.SetParent(gameObject.transform);
        SpriteRenderer myRenderer = newTile.GetComponent<SpriteRenderer>(); //access new tile sprite renderer
        int randCol = Random.Range(0, numColors); //generate a random number between zero and however many colors I have
        tiles.Add(newTile);
        DotBehavior myBehavior = newTile.GetComponent<DotBehavior>();
        myBehavior.myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        myBehavior.color = tileColor[randCol];
        myRenderer.color = myBehavior.color; //set the color to whatever index the tile color has in the array
        myBehavior.gridX = x;
        myBehavior.gridY = y;
        myBehavior.gridPosition = newTile.transform.position;
        myBehavior.step = step;
        return newTile;
    }

    GameObject CreateTile(int x, int y, Vector3 flingPos){ //this is a function which will return a gameobject value.
        GameObject newTile = Instantiate(tileObj, transform.position, transform.rotation);
        newTile.transform.position = flingPos;
        newTile.transform.SetParent(gameObject.transform);
        SpriteRenderer myRenderer = newTile.GetComponent<SpriteRenderer>(); //access new tile sprite renderer
        int randCol = Random.Range(0, numColors); //generate a random number between zero and however many colors I have
        tiles.Add(newTile);
        DotBehavior myBehavior = newTile.GetComponent<DotBehavior>();
        myBehavior.myManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        myBehavior.color = tileColor[randCol];
        myRenderer.color = myBehavior.color; //set the color to whatever index the tile color has in the array
        myBehavior.gridX = x;
        myBehavior.gridY = y;
        myBehavior.gridPosition = new Vector3(startPos.x + x*xStagger, startPos.y + y*yStagger, transform.position.z);
        myBehavior.step = step;
        return newTile;
    }

    // when youre making a square
    public void ColorClear(Color Col){
        //declaring variable for score
        int scoreSquare = myManager.GetComponent<GameManager>().score;
        int colorCount = 0;

        for (int i = 0; i < xSize; i++){
            for(int j = 0; j < ySize; j++){
                if(gridArray[i, j].dot != null && gridArray[i, j].dot.GetComponent<DotBehavior>().color == Col){
                    scoreSquare += 100 * colorCount;
                    colorCount++;
                    Destroy(gridArray[i, j].dot);
                    Debug.Log(scoreSquare);
                    gridArray[i, j].dot = null;
                }
            }
        }
        //dropDown();

        //update the points in the GameManager
        myManager.GetComponent<GameManager>().score = scoreSquare;
    }

    //to have dots fall
    public void dropDown()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                
                if(gridArray[i,j].dot != null && j > 0)
                {
                    //Debug.Log(i + "," + j);
                    if (gridArray[i, j - 1].dot == null)
                    {
                        int origY = j;

                        GameObject thisDot = gridArray[i, j].dot;

                        while (thisDot.GetComponent<DotBehavior>().gridY > 0 && gridArray[i, thisDot.GetComponent<DotBehavior>().gridY - 1].dot == null)
                        {
                            int localY = thisDot.GetComponent<DotBehavior>().gridY;
                            gridArray[i, localY].dot.GetComponent<DotBehavior>().gridPosition = gridArray[i, localY - 1].location;
                            gridArray[i, localY - 1].dot = gridArray[i, localY].dot;
                            //gridArray[i, localY].dot = null;

                            gridArray[i, localY - 1].dot.GetComponent<DotBehavior>().gridY -= 1;

                        }

                        while(origY > thisDot.GetComponent<DotBehavior>().gridY){
                            gridArray[i, origY].dot = null;
                            origY--;
                        }

                    }
                }
                
            }
        }
    }

    public void repopulate()
    {
        
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++){
                if(gridArray[i, j].dot == null){
                    Vector3 offsetPos = new Vector3(gridArray[i, ySize - 1].location.x, gridArray[i, ySize - 1].location.y + j * yStagger, gridArray[i, ySize - 1].location.z);
                    gridArray[i, j].dot = CreateTile(i, j, offsetPos);
                    gridArray[i, j].dot.GetComponent<DotBehavior>().gridPosition = gridArray[i, j].location;
                }
            }
            // if (gridArray[i, ySize - 1].dot == null)
            // {
            //     gridArray[i, ySize - 1].dot = CreateTile(i, ySize - 1);                
            // }
        }

    }

    //variable used in repopulate check n stuff
    int extraCheck = 0;

    public void repopulateCheck()
    {
        int nullCounter = 0;

        for (int i = 0; i < xSize; i++)
        {
            if (gridArray[i, ySize - 1].dot == null)
            {                
                nullCounter++;
            }
        }        

        if (nullCounter > 0)
        {
            repopulate();
        }
    }

    //maybe need to copy dropDown function to make it look up
    //make another function. if theres another 

}
