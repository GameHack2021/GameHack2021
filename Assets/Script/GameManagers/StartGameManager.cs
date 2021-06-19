using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    Button start;
    // Start is called before the first frame update
    void Awake()
    {
        start = GameObject.Find("Canvas/StartButton").GetComponent<Button>();
        start.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        // print(1);
        SceneManager.LoadScene("PlayingScene1");
    }
}
