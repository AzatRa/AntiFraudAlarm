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
            //_alarmSound.OnActivate();
            OnActivated?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            //_alarmSound.OnDeactivate();
            OnDeactivated?.Invoke();
        }
    }
}
