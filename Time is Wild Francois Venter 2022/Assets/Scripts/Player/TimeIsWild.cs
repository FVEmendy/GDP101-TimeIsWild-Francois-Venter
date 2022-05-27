using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeIsWild : MonoBehaviour
{
    public bool _canSlow;
    public float slowTime = 0.5f;
    public float normalTime = 1f;
    public bool _isSlowed;
    [SerializeField] public float SlowTime = 5f;
    [SerializeField] public float timer;
    [SerializeField] public float rechargeTime = 100f;
    [SerializeField] public float timerRecharge;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = normalTime;
        _canSlow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSlowed == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Time.timeScale = normalTime;
                _isSlowed = false;
                _canSlow = false;
                timerRecharge = rechargeTime;
            }
        }
        
        else if (_isSlowed == false && _canSlow == false)
        {
            timerRecharge -= Time.deltaTime;

            if (timerRecharge <= 0)
            {
               _canSlow = true;
            }
        }
    }

    void OnTime()
    {
        if (_canSlow == true)
        {
            if (_isSlowed == false)
            {
                Time.timeScale = slowTime;
                _isSlowed = true;
                timer = SlowTime;
            }

            else if (_isSlowed == true)
            {
                Time.timeScale = normalTime;
                _isSlowed = false;
                _canSlow = false;
                timerRecharge = rechargeTime;
            }
        }
    }
       


}
