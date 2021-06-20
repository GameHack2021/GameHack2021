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

      
    }

  
    IEnumerator Post(string url, string name)
    {
        var request = new UnityWebRequest(url, "POST");
        
        PlayerInfo sendJsonData = new PlayerInfo();
        sendJsonData.playerEmail= name;
        sendJsonData.playerName = name;
        
        string bodyJsonString = JsonUtility.ToJson(sendJsonData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        string response = request.downloadHandler.text;
        int playerID = int.Parse(response.Split(',')[1].Split(':')[1]);
        
        Debug.Log("Status Code: " + request.downloadHandler.text);
        Debug.Log("PlayerID" + playerID);

        // Store userID as the information
        Info.userID = playerID;
    }

    public void registUser(string name){
        StartCoroutine(Post("http://47.98.203.153/api/player/",name ));

    }
}
