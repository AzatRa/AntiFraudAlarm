using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action OnActivated;
    public event Action OnDeactivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            OnActivated?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            OnDeactivated?.Invoke();
        }
    }
}
