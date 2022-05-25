using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public Enemy _enemyScript;
    // Start is called before the first frame update
    void Start()
    {
        _enemyScript = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       private void OnTriggerEnter2D (Collider2D other) //Player gets close = enemy gets mad
    {
        if (other.tag == "Player")
        {
           _enemyScript._isAggressive = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other) // player far = enemy passive
    {
        if (other.tag == "Player")
        {
            _enemyScript._isAggressive = false;
        }
    }

    // void Aggressive()
    // {
    //     if (player.transform.position)
    //     {
            
    //     }
    // }
}
