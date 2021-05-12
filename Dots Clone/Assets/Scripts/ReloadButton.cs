using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ReloadButton : MonoBehaviour
{
    public Button myButton;


    // Start is called before the first frame update
    void Start()
    {
        

        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


// Update is called once per frame
void Update()
    {
        
    }

public void TaskOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
