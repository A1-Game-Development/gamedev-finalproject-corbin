using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Transform firePoint;
   public GameObject bulletPrefab;
   public float bulletSpeed;

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

        GameObject newProjectile = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation);
        Rigidbody2D firing = newProjectile.GetComponent<Rigidbody2D>();
        firing.AddForce((firePoint.position - this.transform.position) * bulletSpeed, ForceMode2D.Impulse);
    }
}
