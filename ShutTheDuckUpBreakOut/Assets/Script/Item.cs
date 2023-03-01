using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item : MonoBehaviour
{
    public Objects_Weapons weaponType;
    public bool IsItThrown;
    Sprite sprite;
    Rigidbody2D rb;
    Vector3 mouseDir;
    Vector3 mousePos;
    
    [SerializeField] private float thrownForce = 250;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        sprite = weaponType.sprite;

        if(IsItThrown == true){
            Thrown();
        }
    }
    void Update()
    {
       if(IsItThrown == true)
       {
        DOVirtual.Float( thrownForce, 0, 3, LeanghtThrown =>{thrownForce = LeanghtThrown;});

        transform.position = Vector3.MoveTowards(transform.position, mousePos, thrownForce * Time.deltaTime);
       }
       
    }
    public void Thrown()
    {
        //Finds the mouse place to throw
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;    
    }
}
