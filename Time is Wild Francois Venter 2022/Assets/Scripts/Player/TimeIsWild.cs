using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeIsWild : MonoBehaviour
{
    public float slowTime = 0.5f;
    public float normalTime = 1f;
    public bool _isSlowed;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = normalTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTime()
    {
        if (_isSlowed == false)
        {
            Time.timeScale = slowTime;
            _isSlowed = true;
        }
        else if (_isSlowed == true)
        {
           Time.timeScale = normalTime;
           _isSlowed = false; 
        }
    }
}
