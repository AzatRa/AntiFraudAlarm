using System.Collections;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField] private AudioClip _alarmSound;
    [SerializeField] private AlarmTrigger _alarmTrigger;

    private AudioSource _audioSource;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0f;
    private float _fadeSpeed = 0.1f;
    private float _targetVolume = 0f;

    private Coroutine _volumeCoroutine;

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

    private void Start()
    {
        Restart();
    }

    private void Restart()
    {
        _alarmTrigger.OnActivated += OnTriggerActivate;
        _alarmTrigger.OnDeactivated += OnTriggerDeactivate;
    }

    private void PlaySound()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
    }

    private IEnumerator FadeVolumeCoroutine()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnTriggerActivate()
    {
        _alarmTrigger.OnActivated -= OnTriggerActivate;
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

        if (_volumeCoroutine  != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(FadeVolumeCoroutine());
    }

    private void OnTriggerDeactivate()
    {
        _alarmTrigger.OnDeactivated -= OnTriggerDeactivate;
        _targetVolume = _minVolume;

        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(FadeVolumeCoroutine());

        if (_audioSource.volume == _minVolume)
            _audioSource.Stop();

        Restart();
    }
}
