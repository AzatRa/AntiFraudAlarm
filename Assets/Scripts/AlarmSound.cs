using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    private AudioSource _audioSource;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0f;
    private float _fadeSpeed = 0.01f;
    private float _targetVolume = 0f;

    private void Awake()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }

        _audioSource.clip = _alarmSound;
        _audioSource.loop = true;
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed);
    }

    private void PlaySound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    public void OnActivate()
    {
        _targetVolume = _maxVolume;

        if (_audioSource != null)
        {
            if (!_audioSource.isPlaying)
            {
                PlaySound();
            }
        }
        else
        {
            Debug.LogError("_audioSource не назначен");
        }
    }

    public void OnDeactivate()
    {
        _targetVolume = _minVolume;

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();
    }
}
