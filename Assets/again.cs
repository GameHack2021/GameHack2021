using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class again : MonoBehaviour
{
    public void returntoScene(){
        SceneManager.LoadScene("level1");
    }
}
