using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    [SerializeField] private GameObject TalkingTo;
    public GameObject player;
    public DialogManger Dialogmanger;
    public GameObject dialogBox;
    public GameObject key;
    public bool Speaking;
    bool HasDropedItem = false;
    public Door DorOpen;
    
    [Header("Drop")]
    public GameObject ItemDrop;

    void Start()
    {
        dialogBox.SetActive(false);
       // key.SetActive(false);
    }
    void Update()
    {

        if(Vector2.Distance(this.gameObject.transform.position,player.transform.position) <1)
        {

            key.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                TalkingTo = this.gameObject;

                dialogBox.SetActive(true);
                triggerDialogue();
                DorOpen.Open = true;

                if(Vector2.Distance(TalkingTo.transform.position,player.transform.position) > 2 ||   Input.GetKeyDown(KeyCode.Escape) ) 
                {
                    dialogBox.SetActive(false);
                } 
            }
        }
       
    }



    public void triggerDialogue()
    {
        FindObjectOfType<DialogManger>().StartDialog(dialog);

        ItemDrop.SetActive(true);
        
    }
}
