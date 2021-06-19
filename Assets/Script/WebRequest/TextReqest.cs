using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class TextReqest : MonoBehaviour
{
    InputField outputArea;
    string myWord = "吴汶轩";

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

    public byte[] SendtypeToBytes(SendType s)
    {
        string json = JsonUtility.ToJson(s);
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json); // 把字符串转换为bype数组
        return postData;
    }

    public string ParseJson(string t)
    {
        ReceiveType rec = JsonUtility.FromJson<ReceiveType>(t);
        string words = myWord + rec.result[0];
        return words;
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
