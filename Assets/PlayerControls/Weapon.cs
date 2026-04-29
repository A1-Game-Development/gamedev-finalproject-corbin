using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Transform firepointposition = this.transform.GetChild(transform.childCount -1).transform;
        Quaternion firedirection = Quaternion.LookRotation(this.transform.position - firepointposition.position);

        Instantiate(bulletPrefab, firePoint.position, firedirection);
        //Shooting Logic
        Debug.Log(firedirection);
    }
}
