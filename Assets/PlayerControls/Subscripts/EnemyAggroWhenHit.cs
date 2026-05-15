using UnityEngine;

public class EnemyAggroWhenHit : MonoBehaviour

{
public WaterEnemyMovement WaterEnemyMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void OnTriggerEnter2D (Collider2D hitInfo) {
        Bullet bulletdetect = hitInfo.GetComponent<Bullet>();
        if (bulletdetect != null) {
            WaterEnemyMovement.isChasing = true;
        }
    }

}
