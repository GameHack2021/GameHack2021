using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat_Manage : MonoBehaviour
{
   GameObject Player;
   GameObject Cat; 

   private void Start() {
      Player = GameObject.Find("Player");
      Cat = GameObject.Find("Cat");
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
         generateDogTalk();
      }
   }

   void generateCatTalk(){
      // TODO:call api
   }

   void generateDogTalk(){

   }
}
