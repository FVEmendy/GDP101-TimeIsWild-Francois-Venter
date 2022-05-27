using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    Vector2 moveInput;
    Rigidbody2D _playerRB;
    Collider2D _circleCollider;
    public bool inputFlipped = false;


    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<Collider2D>();
        _playerRB.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        Run();
        Aim();
        // Die();
        // CheckCollision();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        _playerRB.velocity = playerVelocity;
    }

    void Aim()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
      
        transform.up = direction;
    }

    // void Die()
    // {
    //     if (_circleCollider.IsTouchingLayers(LayerMask.GetMask("Bullets")))
    //     {
    //        FindObjectOfType<GameManager>().processDeath();
    //     }
    // }

//    void CheckCollision()
//    {
//        if (_circleCollider.IsTouchingLayers(LayerMask.GetMask("Wall")))
//        {
//            Debug.Log("touching Wall");
           
//            inputFlipped = true;
//        }
       
//        if (!_circleCollider.IsTouchingLayers(LayerMask.GetMask("Wall")) && inputFlipped == true)
//        {
//            moveInput = -moveInput;
//            inputFlipped = false;
//        }
//    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //    if (other.tag == "Wall" && inputFlipped == false)
    //    {
    //        moveInput = -moveInput;
    //        inputFlipped = true;
    //    }
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.tag == "Wall" && inputFlipped == true)
    //     {
    //         moveInput = -moveInput;
    //         inputFlipped = false;
    //     }
    // }

}
