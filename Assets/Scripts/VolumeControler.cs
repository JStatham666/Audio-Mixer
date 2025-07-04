using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControler : MonoBehaviour
{
    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _volumeSlider;

    private const float _multiplier = 20f;

    private float _volumeValue;

    private void Awake()
    {
        _volumeSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(_volumeParameter, Mathf.Log10(_volumeSlider.value) * _multiplier);
        _volumeSlider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _volumeValue);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        _mixer.SetFloat(_volumeParameter, _volumeValue);
    }
}