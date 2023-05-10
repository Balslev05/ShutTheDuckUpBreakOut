using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Open;
    Animator DoorAnim;
    void Start()
    {
        DoorAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Open == true){
            DoorAnim.Play("DoorOpen");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
