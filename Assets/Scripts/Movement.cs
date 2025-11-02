using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");

        float distance = _moveSpeed * direction * Time.deltaTime;
        transform.Translate(distance * Vector3.forward);
    }
}
