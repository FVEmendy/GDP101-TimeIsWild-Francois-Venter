using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyObject; // Enemy
    [SerializeField] GameObject playerSlot; // Grab Slot on Player
    public bool _isAggressive;
    [SerializeField] float moveDuration = 5f;
    [SerializeField] float pauseDuration = 7f;
    [SerializeField] float timer;
    bool paused;
    private Vector2 movementDirection;
    private Vector2 enemyMovement;
    [SerializeField] float enemySpeed = 2f;



    // Start is called before the first frame update
    void Start()
    {

        if (_isAggressive == false) // Enemy moves at start if player is out of range
        {
            timer = moveDuration;
            paused = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAggressive == false)
        {
            Movement();
        }

        else if (_isAggressive == true)
        {
            Attack();
        }

    }

    void Movement()
    {
        if (enemyObject.transform.parent != playerSlot.transform) // Enemy doesnt move if you pick it up
        {

            timer -= Time.deltaTime; // timer runs out

            if (timer <= 0)
            {
                if (paused)
                {
                    timer = moveDuration; //moving starts
                    RandomMovement();
                    paused = false;
                }
                else
                {
                    timer = pauseDuration; // stand still starts
                    paused = true;
                }
            }

            if (!paused)
            {
                transform.position = new Vector2(transform.position.x + (enemyMovement.x * Time.deltaTime),
                 transform.position.y + (enemyMovement.y * Time.deltaTime));

            }
        }


    }

    void RandomMovement()
    {
        movementDirection = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized; // chooses random direction
        enemyMovement = movementDirection * enemySpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) //Player gets close = enemy gets mad
    {
        if (other.tag == "Player")
        {
            _isAggressive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) // player far = enemy passive
    {
        if (other.tag == "Player")
        {
            _isAggressive = false;
        }
    }
    void Attack()
    {
        if (_isAggressive == true)
        {
            
        }
    }
}
