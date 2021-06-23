using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class apiRequests: MonoBehaviour{
    public class endRunInfo{
        public int runId;
    }

    IEnumerator endRunIE(string url, int runId){
        var request = new UnityWebRequest(url, "POST");
        
        endRunInfo sendJsonData = new endRunInfo();
        sendJsonData.runId= runId;

        string bodyJsonString = JsonUtility.ToJson(sendJsonData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        string response = request.downloadHandler.text;
        Debug.Log(response);
        
        SceneManager.LoadScene("newChat");
    }

    public void endRun(){
        StartCoroutine(endRunIE("http://47.98.203.153/api/end_run/",Info.runID));
    }

}
