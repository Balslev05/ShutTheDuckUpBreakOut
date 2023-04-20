using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Item_Melee : MonoBehaviour
{
    public Objects_Weapons MeleeType;
    public bool IsItThrown;
    
    Rigidbody2D rb;
    Vector3 mouseDir;
    Vector3 mousePos;

    [SerializeField] private float thrownForce = 250;   
    private float speed;
    private Vector3 lastPos;
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

        if(IsItThrown == true){
            ThrowMelee();
        }
    }
    void Update()
    {
        SpriteRenderer ItemSprite = this.gameObject.GetComponent<SpriteRenderer>();
        ItemSprite.sprite = MeleeType.sprite;      
        ItemSprite.sprite = MeleeType.sprite;      
        
        this.gameObject.transform.localScale = MeleeType.WeaponSize;
        
    }

    public void ThrowMelee()
    {
        //Finds the mouse place to throw
        Vector2 tempPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - tempPos;

        transform.DOLocalRotate(new Vector3(0, 0, 600), 1, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.OutCubic);

        rb.AddForce( direction * thrownForce);
    }
}

