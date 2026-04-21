using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
           
            playerHealth.TakeDamage(damage);
            //Debug.Log(collision.gameObject.name);
        }
    }

}
