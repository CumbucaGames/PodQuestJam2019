using UnityEngine;

public class CarSteering : MonoBehaviour
{
    [SerializeField] float accelerationPower = 5f;
    [SerializeField] float steeringPower = 5;
    private float steeringAmount;
    private float speed;
    private float direction;

    private Rigidbody2D rb2d;

    private void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        steeringAmount = Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accelerationPower;
        direction = Mathf.Sign(Vector2.Dot(rb2d.velocity, rb2d.GetRelativeVector(Vector2.up)));
        rb2d.rotation = steeringAmount * steeringPower * rb2d.velocity.magnitude * direction;

        rb2d.AddRelativeForce(Vector2.up * speed);
        rb2d.AddRelativeForce(-Vector2.right * rb2d.velocity.magnitude * steeringPower / 2);
    }
}