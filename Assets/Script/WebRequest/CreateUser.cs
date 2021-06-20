using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Http;
using System.Dynamic;
using System.Text;

public class CreateUser : MonoBehaviour
{
     public class PlayerInfo{
        public string playerName;
        public string playerEmail;
    }

    private void Start() {
    
       StartCoroutine(Post("http://47.98.203.153/api/player/"));
    }

  
    IEnumerator Post(string url)
    {
        var request = new UnityWebRequest(url, "POST");
        
        PlayerInfo sendJsonData = new PlayerInfo();
        sendJsonData.playerEmail= "Test";
        sendJsonData.playerName = "test";
        
        string bodyJsonString = JsonUtility.ToJson(sendJsonData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        
        Debug.Log("Status Code: " + request.downloadHandler.text);
    }

}
