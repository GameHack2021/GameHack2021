using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trans : MonoBehaviour
{
    public void nextScene(){
        SceneManager.LoadScene("newChat");
    }
}
