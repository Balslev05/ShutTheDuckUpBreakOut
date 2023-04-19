using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Objects_Guns", menuName = "Guns", order = 0)]
public class Objects_Guns : ScriptableObject 
{
    public string GunName;
    public Sprite sprite;
    public float  TimeBetweenShots; 
    public float BulletDamage;  // the damage you do
    public int Weight;
    public int SpeedBullet;  // the damage you do
    public int ShotsInMagasin; // how many hits you can hit
    public int bulletFiredPerShot; // how many shots per Bullet
    public float knockBack; // knockback
    public float bulletSPread; // bulletSpread
    public bool HoldToFire;
    public Vector3 BulletSize;
    public Vector3 GunSize;
    public float GunScreenshake;



}
