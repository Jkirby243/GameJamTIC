using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class DebugWeaponselect : MonoBehaviour
{

    [SerializeField]
    private Weapon Weaponname;
    [SerializeField]
    private Transform WeaponParent;
    [SerializeField]
    private List<Gun> Guns;
    [SerializeField]
    private Transform PartPos;

    [Space]
    public Gun ActiveGun;

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
            ActiveGun.Despawn();
            DestroyImmediate(ActiveGun, true);
            Gun gun = Guns.Find(gun => gun.Name == Weapon.Pistol);
            ActiveGun = gun;
            gun.Spawn(WeaponParent, PartPos,this);
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
