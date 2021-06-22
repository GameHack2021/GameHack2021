using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;
    public bool canDeliver;

    PlayingSceneSFX audioManager;


    Text canDeliverHint;
    GameObject doorLight;
    Player_Interaction player_Interaction;
    GameObject catDroppingObj;
    Animator catDroppingAnim;
    GameObject player;

    public GameObject floatCat;



    private void Awake() {
        accepted = false;
        canAccept = false;
        doorLight = transform.Find("light").gameObject;
        player = GameObject.Find("Characters/Player_Armor");
        player_Interaction = player.GetComponent<Player_Interaction>();
        canDeliverHint = GameObject.Find("Canvas/hintText").GetComponent<Text>();
        catDroppingObj = transform.Find("catDrop").gameObject;
        catDroppingAnim = catDroppingObj.GetComponent<Animator>();
        catDroppingObj.SetActive(false);
        audioManager = GameObject.Find("SoundManagers/SFXAudioManager").gameObject.GetComponent<PlayingSceneSFX>();

    }

    private void Start()
    {
        canDeliverHint.gameObject.SetActive(false);
        doorLight.SetActive(false);

    }

    private void Update() {
        if(!accepted){
            if(canDeliver && Input.GetButtonDown("Fire1")){
                StartCoroutine(dropDownDetection());
                
            }
        }
        
        if(accepted){
            GetComponent<SpriteRenderer>().color = Color.green;
            transform.Find("Sprite Mask").Find("control").gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Player"){
            canDeliver = true;
            canDeliverHint.gameObject.SetActive(true);
            doorLight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            canDeliver = false;
            canDeliverHint.gameObject.SetActive(false) ;
            doorLight.SetActive(false);

        }
    }

    IEnumerator dropDownDetection()
    {
        catDroppingObj.SetActive(true);
        catDroppingAnim.SetBool("PlayAnim", true);
        audioManager.playBalloon();
        yield return new WaitForSeconds(0.5f);
        if (canAccept)
        {
            accepted = true;
            player_Interaction.cat_Sent++;
        }
        else
        {
            GameObject temp = Instantiate(floatCat, transform);
            temp.transform.localPosition = new Vector3(0, 0.42f, 0);
        }

        player_Interaction.cat_Carried = player_Interaction.cat_Carried - 1;
        catDroppingObj.SetActive(false);
        catDroppingAnim.SetBool("PlayAnim", false);
    }
    
}
