using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class TextReqest : MonoBehaviour
{
    InputField outputArea;
    string myWord = "������";

    public class SendType
    {
        public int number;
        public int length;
        public float top_p;
        public float temperature;
        public string prompt;
    }

    public class ReceiveType
    {
        public List<string> result;
    }

    public class PlayerInfo{
        public string playerName;
        public string playerEmail;
    }

    public byte[] SendtypeToBytes(SendType s)
    {
        string json = JsonUtility.ToJson(s);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json); // ���ַ���ת��Ϊbype����
        return postData;
    }

    public string ParseJson(string t)
    {
        ReceiveType rec = JsonUtility.FromJson<ReceiveType>(t);
        string words = myWord + rec.result[0];
        return words;
    }

    UnityWebRequest createUser(string username){
        string uri = "http://47.98.203.153/api/player/";

        PlayerInfo sendJsonData = new PlayerInfo();
        sendJsonData.playerEmail= username;
        sendJsonData.playerName = username;

        using UnityWebRequest request = UnityWebRequest.Post(uri, UnityWebRequest.kHttpVerbPOST);
        request.chunkedTransfer = false;

        string json = JsonUtility.ToJson(sendJsonData);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;

    }

    UnityWebRequest SetRequests()
    {
        string uri = "https://test.rct.ai/z";
        SendType sendJsonData = new SendType();
        sendJsonData.number = 1;
        sendJsonData.length = 25;
        sendJsonData.top_p = 1f;
        sendJsonData.temperature = 1f;
        sendJsonData.prompt = myWord;


        using UnityWebRequest request = UnityWebRequest.Post(uri, UnityWebRequest.kHttpVerbPOST);
        request.chunkedTransfer = false;
        request.uploadHandler = new UploadHandlerRaw(SendtypeToBytes(sendJsonData));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;

    }

    // Start is called before the first frame update
    void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
    }

    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        outputArea.text = "loading ...";
        UnityWebRequest request = SetRequests();
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            outputArea.text = request.error;
        }
        else
        {
            string receiveText = request.downloadHandler.text;
            outputArea.text = ParseJson(receiveText);
        }
    }
}
