using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : MonoBehaviourPunCallbacks
{
    public GameObject Gun;
    public GameObject projectile;
    public GameObject cm;
    public Transform barrell;
    
    public int ammoInChamber, ammoReserve;
    public int maxAmmoInChamber, maxAmmoInReserve;

    float timer, resetTimer;


    void Update()
    {
        if (!photonView.IsMine)
            return;
       

        //float left = Input.GetAxis("LeftTrigger");
        float right = Input.GetAxis("RightTrigger");
        Debug.Log(right);

        if (Input.GetMouseButtonDown(0) || right > .5f)
            Fire();

        if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("XButton"))
            Reload();

        timer += Time.deltaTime;

    }//end of update

    public void Fire()
    {
        if (timer > .27f && ammoInChamber > 0)
        {
            Instantiate(projectile, barrell.transform.position, cm.transform.rotation);//what orientation to spawn projectile
            ammoInChamber--;
            timer = resetTimer;
        }

    }//end of shoot

    protected void Reload()
    {

        //cant reload dont do anything
        if (ammoInChamber == maxAmmoInChamber || ammoReserve == 0)
            return;

        int reloadAmount = maxAmmoInChamber - ammoInChamber;

        if (ammoInChamber == 0 && ammoReserve >= maxAmmoInChamber)
        {
            ammoInChamber = maxAmmoInChamber;
            ammoReserve -= maxAmmoInChamber;

        }
        else if (ammoInChamber != 0 && ammoInChamber < maxAmmoInChamber && ammoReserve > 1)
        {
            if (reloadAmount > ammoReserve)
            {
                ammoInChamber += ammoReserve;
                ammoReserve -= ammoReserve;

            }
            else
            {
                ammoInChamber += reloadAmount;
                ammoReserve -= reloadAmount;

            }
        }
        else
        {
            ammoInChamber = ammoReserve;
            ammoReserve = 0;
        }

    }//end of reload

}//end of script