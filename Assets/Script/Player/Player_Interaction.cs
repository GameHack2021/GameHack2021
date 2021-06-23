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
    Text timeUpSign;
    Text outOfCats;
    Text winSign;
    Text fall;

    float timeLimitation = 200f;
    float timeStamp;
    // Interaction objects variablex
    public int catsToTake;
    public int goalSends = 8;
    public int cat_Carried;
    public int cat_Sent = 0;
    CameraSaturationSettings cameraSaturationSettings;
    bool canTakeCats;


    apiRequests mapiRequest;

    private void Awake()
    {
        catNumber = GameObject.Find("Canvas/MainSceneUI/catNumber").GetComponent<Text>();
        catsSentSuccessfully = GameObject.Find("Canvas/MainSceneUI/catsSentSuccessfully").GetComponent<Text>();
        timeShowing = GameObject.Find("Canvas/MainSceneUI/time").GetComponent<Text>();
        timeUpSign = GameObject.Find("Canvas/MainSceneUI/timeUpSign").GetComponent<Text>();
        outOfCats = GameObject.Find("Canvas/MainSceneUI/outOfCats").GetComponent<Text>();
        winSign = GameObject.Find("Canvas/MainSceneUI/winSign").GetComponent<Text>();
        fall = GameObject.Find("Canvas/MainSceneUI/fall").GetComponent<Text>();
        cameraSaturationSettings = GameObject.Find("Cameras/Main Camera").GetComponent<CameraSaturationSettings>();
        timeStamp = timeLimitation + 1;
    }

    void Start()
    {
        player = GetComponent<Player>();
        // initialize variables
        canTakeCats = true;
        timeUpSign.gameObject.SetActive(false);
        outOfCats.gameObject.SetActive(false);
        winSign.gameObject.SetActive(false);
        fall.gameObject.SetActive(false);

        mapiRequest = GetComponent<apiRequests>();
    }

    // Update is called once per frame
    void Update()
    {
        timeStamp -= Time.deltaTime;
        catNumber.text = "Cats left: " + cat_Carried;
        catsSentSuccessfully.text = "Cats sent: " + cat_Sent;
        timeShowing.text = ((int)timeStamp).ToString();
        cameraSaturationSettings.saturation = Mathf.Clamp(cat_Sent / 8 + 0.5f, 0f, 1f) ;
        if (cat_Sent >= 1)
        {
            LoadWinScene();
            return;
        }
        if ((int)timeStamp <= 0)
        {
            LoadLoseScene(1);
            return;
        }
        if(cat_Carried <= 0)
        {
            LoadLoseScene(2);
            return;
        }
        if(player.transform.position.y <= -100)
        {
            LoadLoseScene(3);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Home")
        {
            if (canTakeCats)
            {
                cat_Carried = cat_Carried + catsToTake;
            }
        }

        if (other.gameObject.tag == "Cat")
        {
            cat_Carried = cat_Carried + 1;
        }
    }

    void LoadLoseScene(int type)
    {
        StartCoroutine(OnFail(type));
    }

    void LoadWinScene()
    {
        OnWin();
    }
    
    IEnumerator OnFail(int type)
    {
        if(type == 1)
        {
            timeUpSign.gameObject.SetActive(true);

        }if(type == 2)
        {
            outOfCats.gameObject.SetActive(true);
        }
        if (type == 3)
        {
            fall.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("endS");
    }

    public void OnWin()
    {
        if(winSign.gameObject.activeSelf != true){
            winSign.gameObject.SetActive(true);
            mapiRequest.endRun();
        }

        // yield return new WaitForSeconds(1);
        // SceneManager.LoadScene("newChat");
    }
}