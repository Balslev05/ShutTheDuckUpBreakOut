using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item : MonoBehaviour
{
    public Objects_Weapons weaponType;
    public bool IsItThrown;
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
        //starts with a raondom Rotation
        var euler = transform.eulerAngles;
        euler.z = Random.Range(0, 360);
        transform.eulerAngles = euler;

        SpriteRenderer ItemSprite = this.gameObject.GetComponent<SpriteRenderer>();
        ItemSprite.sprite = weaponType.sprite;

        if(IsItThrown == true){
            Thrown();
        }
    }
    void Update()
    {
       
        if(IsItThrown == true)
        {
            DOVirtual.Float( thrownForce, 0, 3, LeanghtThrown =>{thrownForce = LeanghtThrown;});

            transform.position = Vector3.MoveTowards(transform.position, mousePos, thrownForce);
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
