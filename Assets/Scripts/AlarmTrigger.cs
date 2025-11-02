using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private AlarmSound _alarmSound;

    private void OnTriggerEnter(Collider other)
    {
        _alarmSound.OnActivate();
    }

    private void OnTriggerExit(Collider other)
    {
        _alarmSound.OnDeactivate();
    }
}
