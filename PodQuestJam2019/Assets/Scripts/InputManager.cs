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
        if (Input.GetButtonDown("Vertical"))
        {
            float axisVertical = Input.GetAxisRaw("Vertical");
            
            if (axisVertical == 1)
            {
                OnUp?.Invoke();
                return;
            }

            if (axisVertical == -1)
            {
                OnDown?.Invoke();
                return;
            }
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            float axisHorizontal = Input.GetAxisRaw("Horizontal");

            if (axisHorizontal == -1)
            {
                OnLeft?.Invoke();
                return;
            }

            if (axisHorizontal == 1)
            {
                OnRight?.Invoke();
                return;
            }
        }
    }
}
