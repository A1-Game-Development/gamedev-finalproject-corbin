using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        EnemyDamage enemy = hitInfo.GetComponent<EnemyDamage>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
