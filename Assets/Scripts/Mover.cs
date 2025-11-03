using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15;
    [SerializeField] private float _rotationSpeed = 40;
    [SerializeField] private float _jumpForce = 20;

    private Rigidbody _rigidbody;

    public void Rotate(float direction)
    {
        transform.Rotate(_rotationSpeed * direction * Time.deltaTime * Vector3.up);
    }

    public void Move(float direction)
    {
        float distance = _moveSpeed * direction * Time.deltaTime;
        transform.Translate(distance * Vector3.forward);
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
    }
}
