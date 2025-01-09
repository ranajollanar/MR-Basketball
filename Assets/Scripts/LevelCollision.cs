using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelCollision : MonoBehaviour
{
   [SerializeField] private NetGoalManager netGoalManager;
   private void OnCollisionEnter(Collision other)
   {
      if ((netGoalManager.currentLevel == 0) && (transform.gameObject.name == "Level1") && (other.gameObject.CompareTag("Ball")))
      {
         netGoalManager.currentLevel = 1;
      }
      else if ((netGoalManager.currentLevel == 1) && (transform.gameObject.name == "Level2") && (other.gameObject.CompareTag("Ball")))
      {
         netGoalManager.currentLevel = 2;
      }
      else if ((netGoalManager.currentLevel == 2) && (transform.gameObject.name == "Level3") && (other.gameObject.CompareTag("Ball")))
      {
         netGoalManager.currentLevel = 3;
      }
      
   }

}
