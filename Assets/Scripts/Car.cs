using UnityEngine;

public class Car : MonoBehaviour
{
    public float acceleration;
    public float maxVelocity;
    public float turnRate;

    private Vector2 velocity;

    private void Update()
    {
        velocity *= 0.992f;

        if (Input.GetKey(KeyCode.UpArrow)) Accelerate(true);
        if (Input.GetKey(KeyCode.DownArrow)) Accelerate(false);
        if (Input.GetKey(KeyCode.LeftArrow)) Turn(false);
        if (Input.GetKey(KeyCode.RightArrow)) Turn(true);

        velocity = new Vector2(Mathf.Clamp(velocity.x, -maxVelocity, maxVelocity), Mathf.Clamp(velocity.y, -maxVelocity, maxVelocity));
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    private void Accelerate(bool _forward)
    {
        velocity += (Vector2)(_forward ? transform.up : -transform.up) * acceleration;
    }

    private void Turn(bool _right)
    {
        transform.Rotate((_right ? Vector3.back : Vector3.forward) * turnRate * Mathf.Min(1, velocity.magnitude));
    }
}
