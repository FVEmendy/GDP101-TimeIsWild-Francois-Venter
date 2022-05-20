using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbing : MonoBehaviour
{
    // Enemy _enemyScript;
    BoxCollider2D grabSlot;
    bool isGrabbed;
    bool _canGrab = true;
    [SerializeField] Collider2D _grabbableItem;
    // Start is called before the first frame update
    void Start()
    {
        grabSlot = GetComponent<BoxCollider2D>();
        // _enemyScript = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _grabbableItem = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            _grabbableItem = null;
        }
    }

    void OnFire()
    {
        if (_canGrab == true && _grabbableItem != null)
        {
            _grabbableItem.transform.position = grabSlot.transform.position;
            _grabbableItem.transform.rotation = grabSlot.transform.rotation;
            _grabbableItem.transform.parent = grabSlot.transform;
            _canGrab = false;
            // _enemyScript._isAggressive = false;
            // _enemyScript._isGrabbed = true;
        }

        else if (_canGrab == false)
        {
            _grabbableItem.transform.parent = null;
            _canGrab = true;
            // _enemyScript._isGrabbed = false;
        }
    }
}
