using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D _projectileRB;
    [SerializeField] GameObject _player;
    [SerializeField] float bulletSpeed = 10f;
    public Vector2 _projectileSpeed;
    Grabbing _grabScript;

    // Start is called before the first frame update
    void Start()
    {
        _projectileRB = GetComponent<Rigidbody2D>();
        _grabScript = FindObjectOfType<Grabbing>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _projectileSpeed = new Vector2 (transform.up.x * bulletSpeed, transform.up.y * bulletSpeed);
        _projectileRB.velocity = _projectileSpeed;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().processDeath();
            Destroy(gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }

               if (other.tag == "grabbedEnemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            _grabScript._canGrab = true;
        } 
    }
    
}
