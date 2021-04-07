using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawn : MonoBehaviour
{

    public GameObject dot;

    public int x;

    public int y;

    public float dist;

    public int rows, columns;

    // Start is called before the first frame update
    void Start()
    {
        spawnDot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnDot()
    {
        for(int j = 0; j < rows; j++){
            for(int i = 0; i < columns; i++){
                Instantiate(dot, new Vector3(x+i*dist, y+j, 0), Quaternion.identity);
                //Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            }
        }
    }

    //if statement to check if the next
    //dot is x+1, x-1 or y+1, y-1 of the initial dot
    

}

