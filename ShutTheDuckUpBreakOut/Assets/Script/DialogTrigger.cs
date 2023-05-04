using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public GameObject player;

    public GameObject dialogBox;
    public GameObject key;

    void Start()
    {
        dialogBox.SetActive(false);
       // key.SetActive(false);
    }
    void Update()
    {
         if(Vector2.Distance(transform.position,player.transform.position) > 4 || Input.GetKeyDown(KeyCode.Escape) ) 
         {
            dialogBox.SetActive(false);
         }

        if(Vector2.Distance(transform.position,player.transform.position) <3)
        {
            key.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogBox.SetActive(true);
                triggerDialogue();
            }
        } //else{key.SetActive(false);}
       
       
       /*  if(Input.GetKey(KeyCode.KeypadEnter))
        {
            
        } */
    }



    public void triggerDialogue()
    {
        FindObjectOfType<DialogManger>().StartDialog(dialog);
    }
}
