using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    Button start;
    InputField input;

    CreateUser createUser;
    // Start is called before the first frame update
    void Awake()
    {
        start = GameObject.Find("Canvas/StartButton").GetComponent<Button>();
        input = GameObject.Find("InputField").GetComponent<InputField>();
        createUser = GetComponent<CreateUser>();
        start.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        // print(1);
        createUser.registUser(input.text);
        SceneManager.LoadScene("PlayingScene1");
    }
}
