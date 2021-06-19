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

   private void Start() {

      Player = GameObject.Find("Player");
      Cat = GameObject.Find("Cat");
      player_Talk = GameObject.Find("playerTalk").GetComponent<Text>();
      cat_Talk = GameObject.Find("catTalk").GetComponent<Text>();
      input = GameObject.Find("inputText").GetComponent<Text>();

      intialization();
   }
   private void Update() {

      if(Input.GetButtonDown("Submit")){
         nextConversation();
      }
   }

   void intialization(){
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
      cat_Talk.text = "...";
      
      // Clear Input Field and hide the input
      input.transform.parent.gameObject.SetActive(false);
   }

   void generatePlayerTalk(){
      player_Talk.text = "...";
      input.transform.parent.gameObject.SetActive(true);


   }

   public void sendText(){
      player_Talk.text = input.text;
      input.transform.parent.GetComponent<InputField>().Select();
      input.transform.parent.GetComponent<InputField>().text = "";

   }
}
