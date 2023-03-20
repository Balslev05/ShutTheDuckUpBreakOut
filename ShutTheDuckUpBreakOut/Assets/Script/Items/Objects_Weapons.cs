
using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[CreateAssetMenu(fileName = "Objects_Weapons", menuName = "Weapons", order = 0)]
public class Objects_Weapons : ScriptableObject 
{
    public Sprite sprite;
    public int Damage;  // the damage you do
    public int Durability; // how many hits you can hit 
    public int weight; // Slows the Cooldown
    public int KnockBack; //knockbacks the enemy

    public  float throwSpeed;
}
    