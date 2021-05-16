using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ReloadButton : MonoBehaviour
{
    public Button reloadButton;
    public Button reloadBarButton;
    public Button mmButton;
    public SoundManager soundManager;
    

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();

        Button btn = reloadButton.GetComponent<Button>();
        btn.onClick.AddListener(ReloadScene);

        Button mmbtn = mmButton.GetComponent<Button>();
        mmbtn.onClick.AddListener(GotoMM);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene()
    {
        soundManager.PlaySound(soundManager.btnClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMM()
    {
        soundManager.PlaySound(soundManager.btnBack);
        SceneManager.LoadScene("Main Menu");
    }

}
