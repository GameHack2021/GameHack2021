using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    bool show;
    GameObject tempShader;
    void Start()
    {
        tempShader = GameObject.Find("Main Camera");

        show = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && !show){
            showMenu();
           
        }else if(Input.GetButtonDown("Cancel")){
            hideMenu();
        }
        
    }

    void showMenu(){
        Time.timeScale = 0;
        show = true;
        tempShader.GetComponent<Camera>().backgroundColor = Color.black;
    }

    void hideMenu(){
        Time.timeScale = 1;
        show = false;
        tempShader.GetComponent<Camera>().backgroundColor = Color.blue;

    }
}
