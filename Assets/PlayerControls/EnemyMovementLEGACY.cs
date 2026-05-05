using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementLEGACY : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public float verticalSpeed; //only used during isChasing.
    public int patrolDestination;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;
    public bool WaitingAbility; //Determines whether it'll wait at patrol points or not.
    private bool waitingState; //Used if WaitingAbility is enabled.  Only set to public when Debugging.
    public float WaitTimeMin; //Since waittime is randomized, these determine the minimun and maxinum possible amount of seconds.
    public float WaitTimeMax; //same purpose as WaitTimeMin.
    private float chosenTime;
    public float EvasionDistance; //Distance before the enemy goes into Searching mode if EvasionAbility is enabled.
    private float EvasionTimer;
    public float EvasionTime;
    public bool EvasionAbility; //Determines if 'isChasing' is permenantly enabled or not when isChasing gets triggered, setting to true will enable the ability to evade from enemy.
    public bool evading;



void Start() {
        isChasing = false;
        waitingState = false;
        evading = false;
        DebugStartupCheck();
        
        //wallCollisionTimer = 3;
    }

void FixedUpdate() {
 if(!waitingState && !isChasing && !evading) {
        PatrolDirection();
    }

       if(isChasing)
        {
            if(transform.position.x > playerTransform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if(transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            if (transform.position.y > playerTransform.position.y)
            {
                transform.position += Vector3.down * verticalSpeed * Time.deltaTime;
            }
            if (transform.position.y < playerTransform.position.y)
            {
                transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
            }
            
            if(Vector2.Distance(transform.position, playerTransform.position) > EvasionDistance && EvasionAbility)
            {
                evading = true;
                isChasing = false;
                EvasionTimer = EvasionTime;
            }
            
        }
        else if(evading)
        {
            EvasionTime -= Time.deltaTime;
            evading = (EvasionTime > 0.1f);
        }

        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
                evading = false;
            }

            
            PatrolLinear();

            if(waitingState && WaitingAbility)
            {
                chosenTime -= Time.deltaTime;
                waitingState = (chosenTime > 0.1f);
                Debug.Log(chosenTime);   

            }
        }
}

    // Update is called once per frame

    void Update()
    {
 

    }
void PatrolLinear()
{
    if(!waitingState)
            {
               transform.position = Vector2.MoveTowards(transform.position, patrolPoints[patrolDestination].position, moveSpeed * Time.deltaTime);
               if(Vector2.Distance(transform.position, patrolPoints[patrolDestination].position) < .2f)
               {
                   
                   
                   if(patrolDestination >= (patrolPoints.Length - 1))
                   {
                    patrolDestination = 0;
                    chosenTime = Random.Range(WaitTimeMin, WaitTimeMax);
                    if(WaitingAbility)
                    {
                        waitingState = true;
                    }
                   }
                   else
                   {
                    patrolDestination += 1;
                    if(WaitingAbility)
                    {
                        waitingState = true;
                    }
                    chosenTime = Random.Range(WaitTimeMin, WaitTimeMax);
                   }
                   
               }
            }
}
void PatrolDirection()
{
    if(transform.position.x > patrolPoints[patrolDestination].position.x)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
    if(transform.position.x < patrolPoints[patrolDestination].position.x)
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
void DebugStartupCheck() {
    if(WaitTimeMin > WaitTimeMax) {
        Debug.Log("WaitTimeMin is greater than WaitTimeMax! Unpredicable Behavior expected!"); }
    if (chaseDistance > EvasionDistance) {
        Debug.Log("chaseDistance is greater than EvasionDistance! You can ignore this if EvasionAbility is disabled."); }
    if (moveSpeed <= 0 || chaseDistance <= 0) {
        Debug.Log("Some vital values are left at 0!"); }
}
}