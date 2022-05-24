using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyObject; // Enemy
    [SerializeField] GameObject playerSlot; // Grab Slot on Player
    [SerializeField] GameObject _player;
    public bool _isAggressive;
    [SerializeField] float moveDuration = 5f;
    [SerializeField] float pauseDuration = 7f;
    [SerializeField] float timer; // timer for movement
    [SerializeField] float attackTimer; // timer for attacks
    [SerializeField] float attackDelay = 1f;
    [SerializeField] GameObject _enemyProjectile;
    [SerializeField] GameObject _enemyGun;
    bool paused;
    private Vector2 movementDirection;
    private Vector2 enemyMovement;
    [SerializeField] float enemySpeed = 2f;



    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackDelay;

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
            EnemyAim();
        }

    }

    void Movement()
    {
        if (enemyObject.transform.parent != playerSlot.transform && _isAggressive == false) // Enemy doesnt move if you pick it up
        {

            timer -= Time.deltaTime; // timer time decreases

            if (timer <= 0) // if timer runs out
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


    void EnemyAim()
    {
        if (_isAggressive == true && enemyObject.transform.parent != playerSlot.transform)
        {
            Vector2 _playerDirection = new Vector2(_player.transform.position.x - transform.position.x,
             _player.transform.position.y - transform.position.y);
            transform.up = _playerDirection;
        }

        Attack();
        // attackTimer = attackDelay;

    }

    void Attack()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            attackTimer = attackDelay;
            Instantiate(_enemyProjectile, _enemyGun.transform.position, Quaternion.identity);
        }
    }
}
