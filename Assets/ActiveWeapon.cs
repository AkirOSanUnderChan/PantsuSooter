using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class ActiveWeapon : MonoBehaviour
{
    public UnityEngine.Animations.Rigging.Rig handIk;
    public Transform crossHairTarget;
    public Transform weaponParent;
    RaycastWeapon weapon1;

    public GameObject AK47;

    void Start()
    {
        RaycastWeapon existingWeapon = GetComponentInChildren<RaycastWeapon>();
        if (existingWeapon)
        {
            
            Equip(existingWeapon);
        }
    }

    void Update()
    {
        if (weapon1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AK47Sounds gg = GetComponentInChildren<AK47Sounds>();
                gg.PlayAK47Sound();
                weapon1.StartFiring();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                weapon1.StopFiring();

            }
        }
        else
        {
            //handIk.weight = 0.0f;
        }
        
    }

    public void Equip(RaycastWeapon newWeapon)
    {
        RaycastWeapon existingWeapon = weapon1; // «бер≥гаЇмо посиланн€ на поточну зброю

        if (existingWeapon != null)
        {
            Destroy(existingWeapon.gameObject); // «нищуЇмо поточну зброю
        }

        //weapon1 = Instantiate(newWeapon, weaponParent);
        weapon1 = newWeapon;
        weapon1.raycastDestination = crossHairTarget;
        weapon1.transform.parent = weaponParent;
        weapon1.transform.localPosition = Vector3.zero;
        weapon1.transform.localRotation = Quaternion.identity;

        handIk.weight = 1.0f;
    }
}
