using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{

    [SerializeField]
    private Weapon Weaponname; //name of the weapon, each gun has a weapon name assigned to it
    [SerializeField]
    private Transform WeaponParent;
    [SerializeField]
    private List<Gun> Guns; //weapon scripts
    [SerializeField]
    private Transform PartPos;

    [Space]
    public Gun ActiveGun; //actual active gun


    private bool inCowboyTriggerZone, inSenatorTriggerZone, inTweakerdTriggerZone; 

    // Start is called before the first frame update
    void Start()
    {
        Gun gun = Guns.Find(gun => gun.Name.ToString().Contains(Weaponname.ToString()));
        print("Gun: " + gun.name);
        //if (gun == null)
        //{
        //    Debug.Log("WARNING: No Weapon has been set as a default weapon in Weapons Manager");
        //    return;
        //}

        ActiveGun = gun;
        gun.Spawn(WeaponParent, PartPos, this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inCowboyTriggerZone && !inSenatorTriggerZone && !inTweakerdTriggerZone)
            {
                if(ActiveGun != null)
                {
                    ActiveGun.Despawn();
                }
                Gun gun = Guns.Find(gun => gun.Name == Weapon.Revolver);
                ActiveGun = gun;
                gun.Spawn(WeaponParent, PartPos, this);
            }
            else if(inSenatorTriggerZone && !inTweakerdTriggerZone && !inCowboyTriggerZone)
            {
                if (ActiveGun != null)
                {
                    ActiveGun.Despawn();
                }
                Gun gun = Guns.Find(gun => gun.Name == Weapon.Pistol);
                ActiveGun = gun;
                gun.Spawn(WeaponParent, PartPos, this);
            }
            else if(inTweakerdTriggerZone && !inSenatorTriggerZone && !inCowboyTriggerZone)
            {

                Debug.Log("Selected Tweaker Weapon: TWEAKER NOT CURRENTLY IMPLEMENTED");

                //if (ActiveGun != null)
                //{
                //    ActiveGun.Despawn();
                //    DestroyImmediate(ActiveGun, true);
                //}
                //Gun gun = Guns.Find(gun => gun.Name == Weapon.Revolver);
                //ActiveGun = gun;
                //gun.Spawn(WeaponParent, PartPos, this);
            }
        }
    }

    public void SetCowboyTriggerZone(bool value)
    {
        inCowboyTriggerZone = value; 
    }
    public void SetSenatorTriggerZone(bool value)
    {
        inSenatorTriggerZone = value;
    }
    public void SetTweakerTriggerZone(bool value)
    {
        inTweakerdTriggerZone = value; 
    }

    public Gun GetActiveGun()
    {
        return ActiveGun;
    }
}
