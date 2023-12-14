using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class DebugWeaponselect : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        Gun gun = Guns.Find(gun => gun.Name == Weaponname);

        if(gun == null)
        {
            Debug.Log("Wrong gun");
            return;
        }

        ActiveGun = gun;
        gun.Spawn(WeaponParent, PartPos ,this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            ActiveGun.Despawn(); //despawns
            DestroyImmediate(ActiveGun, true); //removes model everything
            Gun gun = Guns.Find(gun => gun.Name == Weapon.Pistol); //finds a gun in the list of game that has the same as the given name
            ActiveGun = gun;
            gun.Spawn(WeaponParent, PartPos,this); //just model and part positions
        }
        if (Input.GetKeyDown("2"))
        {
            ActiveGun.Despawn();
            DestroyImmediate(ActiveGun, true);
            Gun gun = Guns.Find(gun => gun.Name == Weapon.Revolver);
            ActiveGun = gun;
            gun.Spawn(WeaponParent, PartPos ,this);
        }
    }
}
