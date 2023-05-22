
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Objects_Weapons", menuName = "Weapons", order = 0)]
public class Objects_Weapons : ScriptableObject 
{
    public enum Type {
        Light,
        Medium,
        Heavy,
    };
    public Sprite sprite;
    public int Damage;  // the damage you do
    public int Durability; // how many hits you can hit 
    public int weight; // Slows the Cooldown
    public float KnockBack; //knockbacks the enemy
    public  float throwSpeed;
    public Vector3 WeaponSize; 
    public Type AttackType = new Type();

}
    