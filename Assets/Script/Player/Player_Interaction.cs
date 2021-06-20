using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Interaction : MonoBehaviour
{
    Player player;
    Text catNumber;
    Text catsSentSuccessfully;
    Text timeShowing;

    float timeLimitation = 10f;
    float timeStamp;
    // Interaction objects variablex
    public int catsToTake;
    public int cat_Carried;
    public int cat_NeedToGive = 1;
    public int cat_Sent = 0;
    bool canTakeCats;

    private void Awake()
    {
        catNumber = GameObject.Find("Canvas/MainSceneUI/catNumber").GetComponent<Text>();
        catsSentSuccessfully = GameObject.Find("Canvas/MainSceneUI/catsSentSuccessfully").GetComponent<Text>();
        timeShowing = GameObject.Find("Canvas/MainSceneUI/time").GetComponent<Text>();
        timeStamp = timeLimitation + 1;
    }

    void Start()
    {
        player = GetComponent<Player>();
        // initialize variables
        canTakeCats = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp -= Time.deltaTime;
        catNumber.text = "Cats left: " + cat_Carried;
        catsSentSuccessfully.text = "Cats sent: " + cat_Sent;
        timeShowing.text = ((int)timeStamp).ToString();
        if(cat_Sent >= cat_NeedToGive)
        {
            LoadWinScene();
        }
        if((int)timeStamp <= 0 || cat_Carried <= 0)
        {
            LoadLoseScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Home"){
            if(canTakeCats){
                cat_Carried = cat_Carried + catsToTake;
            }
        }

        if(other.gameObject.tag == "Cat"){
            cat_Carried = cat_Carried + 1;
        }
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene("newChat");
    }

    void LoadLoseScene()
    {
        SceneManager.LoadScene("endS");
    }


}
