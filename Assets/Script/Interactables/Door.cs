using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool accepted;
    public bool canAccept;
    public bool canDeliver;

    Text canDeliverHint;
    GameObject doorLight;
    Player_Interaction player_Interaction;
    GameObject catDroppingObj;
    SpriteRenderer catDroppingObjSpriteRenderer;
    Animator catDroppingAnim;
    GameObject player;

    public GameObject floatCat;
    float oriFlip;
    float timeStamp = 10f;

    private void Awake()
    {
        accepted = false;
        canAccept = false;
        doorLight = transform.Find("light").gameObject;
        player = GameObject.Find("Characters/Player_Armor");
        player_Interaction = player.GetComponent<Player_Interaction>();
        canDeliverHint = GameObject.Find("Canvas/hintText").GetComponent<Text>();
        catDroppingObj = transform.Find("catDrop").gameObject;
        catDroppingObjSpriteRenderer = catDroppingObj.GetComponent<SpriteRenderer>();
        catDroppingAnim = catDroppingObj.GetComponent<Animator>();
        catDroppingObj.SetActive(false);
    }

    private void Start()
    {
        canDeliverHint.gameObject.SetActive(false);
        doorLight.SetActive(false);
        oriFlip = catDroppingObj.transform.localScale.x;
        catDroppingObj.SetActive(true);
        catDroppingObjSpriteRenderer.enabled = false;

    }

    private void Update()
    {
        timeStamp += Time.deltaTime;
        if (!accepted)
        {
            if (canDeliver && Input.GetButtonDown("Fire1") && timeStamp > 1f)
            {
                timeStamp = 0;
                StartCoroutine(dropDownDetection());

            }
        }

        if (accepted)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            canDeliver = true;
            canDeliverHint.gameObject.SetActive(true);
            doorLight.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDeliver = false;
            canDeliverHint.gameObject.SetActive(false);
            doorLight.SetActive(false);

        }
    }

    IEnumerator dropDownDetection()
    {
        float secWaitingForJumping = 0.4f;
        if ((player.transform.position.x - transform.position.x) > 0)
        {
            catDroppingObj.transform.localPosition = new Vector2(0.12f, -0.088f);
            catDroppingObj.transform.localScale = new Vector2(oriFlip,
                catDroppingObj.transform.localScale.y);

        }
        else
        {
            catDroppingObj.transform.localPosition = new Vector2(-0.12f, -0.088f);
            catDroppingObj.transform.localScale = new Vector2(oriFlip * -1,
                catDroppingObj.transform.localScale.y);

        }
        catDroppingObjSpriteRenderer.enabled = true;
        catDroppingAnim.SetBool("PlayAnim", true);

        yield return new WaitForSeconds(secWaitingForJumping);
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
        catDroppingAnim.SetBool("PlayAnim", false);
        catDroppingObjSpriteRenderer.enabled = false;


    }

}
