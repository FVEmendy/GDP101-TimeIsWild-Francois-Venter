using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D _projectileRB;
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _projectileRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}