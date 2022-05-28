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
    [SerializeField] public float SlowTime = 5.99f;
    [SerializeField] public float timer;
    [SerializeField] public float rechargeTime = 10.99f;
    [SerializeField] public float timerRecharge;
    public static string showTimeUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = normalTime;
        _canSlow = true;
        showTimeUI = "TIME";
    }

    // Update is called once per frame
    void Update()
    {
        if (_isSlowed == true)
        {
            timer -= Time.deltaTime;
            showTimeUI = timer.ToString("n0");

            if (timer <= 1)
            {
                Time.timeScale = normalTime;
                _isSlowed = false;
                _canSlow = false;
                timerRecharge = rechargeTime;
                showTimeUI = timerRecharge.ToString();
            }
        }
        
        else if (_isSlowed == false && _canSlow == false)
        {
            timerRecharge -= Time.deltaTime;
            showTimeUI = timerRecharge.ToString("n0");

            if (timerRecharge <= 1)
            {
               _canSlow = true;
               showTimeUI = "TIME";

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
