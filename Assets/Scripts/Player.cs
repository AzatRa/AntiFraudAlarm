using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;

    private void FixedUpdate()
    {
        _mover.Move(_inputReader.VerticalDirection);
        _mover.Rotate(_inputReader.HorizontalDirection);

        if (_inputReader.GetIsJump())
            _mover.Jump();
    }
}
