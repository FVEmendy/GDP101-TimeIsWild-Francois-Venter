using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public Grabbing grabbingScript;
    // Start is called before the first frame update
    void Start()
    {
        grabbingScript = FindObjectOfType<Grabbing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "grabbedEnemy")
        {
            grabbingScript._grabbableItem = null;
            grabbingScript._canGrab = true;
            Destroy(other.gameObject);
            FindObjectOfType<GameManager>().AddScore();
        }
    }
}
