using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item_Gun : MonoBehaviour
{
   
    public Objects_Guns GunType;
    public bool IsItThrown;
    Rigidbody2D rb;
    Vector3 mouseDir;
    Vector3 mousePos;
    [SerializeField] private float thrownForce = 250;

    private SpriteRenderer ItemSprite;
    
    private float speed;
    private Vector3 lastPos;
    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        ItemSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        ItemSprite.sprite = GunType.sprite;    

        //starts with a raondom Rotation
        var euler = transform.eulerAngles;
        euler.z = Random.Range(0, 360);
        transform.eulerAngles = euler;

        if(IsItThrown == true){
            Thrown();
        }
    }
    void Update()
    {
        transform.localScale = GunType.GunSize;
    }


    public void Thrown()
    {

        //Finds the mouse place to throw
        Vector2 tempPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - tempPos;

        transform.DOLocalRotate(new Vector3(0, 0, 600), 1, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.OutCubic);

        rb.AddForce( direction * thrownForce);
    }
    /* public void SlowDown()
    {
        DOVirtual.Float( thrownForce, 0, 1f, LeanghtThrown =>{thrownForce = LeanghtThrown;});
    } */
}

       /*  mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;   */  

