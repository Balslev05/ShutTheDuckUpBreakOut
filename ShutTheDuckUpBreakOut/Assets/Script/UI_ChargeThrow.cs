using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_ChargeThrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon MeeleSystem;
    public Guns GunSystem;

    public Player player;
    public Image UI_Charge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.CarryingMelee == true)
        {
            CarringMelee();

        } 
        
        if(player.CarryingGun == true)
        {
            CarringGun();
        } 

        if(player.CarryingGun  == false && player.CarryingMelee == false){
            UI_Charge.fillAmount = 0;
            
        }
    }

    void CarringMelee(){
        UI_Charge.fillAmount = MeeleSystem.ChargeTimer / MeeleSystem.Time_Charge;
        
    }
    void CarringGun(){
        UI_Charge.fillAmount = GunSystem.ChargeTimer / GunSystem.Time_Charge;
        
    }
    


}
