using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Objects_Guns", menuName = "Guns", order = 0)]
public class Objects_Guns : ScriptableObject {
    public Sprite sprite;
    public int Weight;
    public float BulletDamage;  // the damage you do
    public int RealoadeSpeed; 
    public int SpeedBullet;  // the damage you do
    public int ShotsInMagasin; // how many hits you can hit
    public int bulletFiredPerShot; // how many shots per Bullet
    public int knockBack; // knockback
    public float bulletSPread; // bulletSpread

}
