using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineManager : MonoBehaviour
{
    public GameObject player;
    public GameObject WeaponManager;

    // Start is called before the first frame update
   
        
        
       
        
   void StartCutScene()
  {
        player.GetComponent<Player>().enabled = enabled;
        player.GetComponent<PlayerMovment>().enabled = enabled;
        player.GetComponent<Mouse>().enabled = enabled;
        player.GetComponent<AimWithGun>().enabled = enabled;
        
  }
  void EndCutScene()
  {
        player.GetComponent<Player>().enabled = enabled;
        player.GetComponent<PlayerMovment>().enabled = enabled;
        player.GetComponent<Mouse>().enabled = enabled;
        player.GetComponent<AimWithGun>().enabled = enabled;
        
  }

}
