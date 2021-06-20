using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat_Manage : MonoBehaviour
{
   GameObject Player;
   GameObject Cat; 
   Text player_Talk;
   Text cat_Talk;
   Text input;

   public string[] playerScript = new string[]{"啊？我已经，很多年，没有见到过动物了！这是……猫？按照我的印象，这种动物已经在城市中灭绝了。但看着这么可爱，带回家应该也没问题吧？","可是，可是，这里，地下室很破败，也算不上什么家呢。"};

   public string[] catScript = new string[]{"太好了！！！真的很感谢喵！终于有家了喵！"};

   int playerChatPosi;
   int catChatPosi;

   private void Start() {

      Player = GameObject.Find("Player");
      Cat = GameObject.Find("Cat");
      player_Talk = GameObject.Find("playerTalk").GetComponent<Text>();
      cat_Talk = GameObject.Find("catTalk").GetComponent<Text>();
      input = GameObject.Find("inputText").GetComponent<Text>();

      playerChatPosi = 0;
      catChatPosi = 0;

      intialization();
   }
   private void Update() {

      if(Input.GetButtonDown("Submit")){
         nextConversation();
      }
   }

   void intialization(){
      generatePlayerTalk();
      Player.SetActive(true);
      Cat.SetActive(false);
   }

   void nextConversation(){
      if(Player.active){
         Cat.SetActive(true);
         Player.SetActive(false);
         generateCatTalk();
      }else{
         Cat.SetActive(false);
         Player.SetActive(true);
         generatePlayerTalk();
      }
   }

   void generateCatTalk(){
      // TODO:call api  
      cat_Talk.text = catScript[catChatPosi];
      catChatPosi = catChatPosi +1;
      
      // Clear Input Field and hide the input
      input.transform.parent.gameObject.SetActive(false);
   }

   void generatePlayerTalk(){
      player_Talk.text = playerScript[playerChatPosi];
      playerChatPosi = playerChatPosi +1;

      input.transform.parent.gameObject.SetActive(true);


   }

   public void sendText(){
      player_Talk.text = input.text;
      input.transform.parent.GetComponent<InputField>().Select();
      input.transform.parent.GetComponent<InputField>().text = "";

   }
}
