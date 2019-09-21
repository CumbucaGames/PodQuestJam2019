using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void Up();
    public delegate void Down();
    public delegate void Left();
    public delegate void Right();
    
    public event Up OnUp;
    public event Down OnDown;
    public event Left OnLeft;
    public event Right OnRight;
    
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            OnUp?.Invoke();
            return;
        }

        if (Input.GetKeyDown("down"))
        {
            OnDown?.Invoke();
            return;
        }
        
        if (Input.GetKeyDown("left"))
        {
            OnLeft?.Invoke();
            return;
        }

        if (Input.GetKeyDown("right"))
        {
            OnRight?.Invoke();
            return;
        }

    }
}
