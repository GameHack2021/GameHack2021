using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpToDoorDetection : MonoBehaviour
{
    public NeighbourHideNSeek neighbourHideNSeek;
    public Text hintText;

    bool isPlayerInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isPlayerInside = true;
            hintText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInside = false;
            hintText.gameObject.SetActive(false);
        }
    }
}
