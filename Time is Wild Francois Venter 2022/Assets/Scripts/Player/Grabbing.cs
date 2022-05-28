using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grabbing : MonoBehaviour
{
    BoxCollider2D grabSlot;
    public bool _canGrab = true;
    [SerializeField] public Collider2D _grabbableItem;
    // Start is called before the first frame update
    void Start()
    {
        grabSlot = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other != null)
        {
            _grabbableItem = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy" && other != null)
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
            _grabbableItem.tag = "grabbedEnemy";
        }

        else if (_canGrab == false && _grabbableItem != null)
        {
            _grabbableItem.transform.parent = null;
            _canGrab = true;
            _grabbableItem.tag = "Enemy";
        }
    }
}
