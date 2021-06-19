using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateUser : MonoBehaviour
{
     public class PlayerInfo{
        public string playerName;
        public string playerEmail;
    }

    private void Start() {
        // StartCoroutine(postRequest("http:///www.yoururl.com", "your json"));
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

     IEnumerator PostRequest(string url, string json){
     var uwr = new UnityWebRequest(url, "POST");
     byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
     uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
     uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
     uwr.SetRequestHeader("Content-Type", "application/json");

     //Send the request then wait here until it returns
     yield return uwr.SendWebRequest();

     if (uwr.isNetworkError)
     {
         Debug.Log("Error While Sending: " + uwr.error);
     }
     else
     {
         Debug.Log("Received: " + uwr.downloadHandler.text);
     }
 }

}
