using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject playerSlot;
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

        if (_isAggressive == false)
        {
            timer = moveDuration;
            paused = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (enemyObject.transform.parent != playerSlot.transform)
        {

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                if (paused)
                {
                    timer = moveDuration;
                    RandomMovement();
                    paused = false;
                }
                else
                {
                    timer = pauseDuration;
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
        movementDirection = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        enemyMovement = movementDirection * enemySpeed;
    }
}
