using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Toggle _volumeButton;

    private float _valueMute = -80f;
    private float _currentValue;

    private void Awake()
    {
        _volumeButton.onValueChanged.AddListener(ToggleSound);
    }
    private void OnDisable()
    {
        _volumeButton.onValueChanged.RemoveListener(ToggleSound);
    }
    private void ToggleSound(bool isDisabled)
    {
        if (isDisabled)
        {
            _mixer.SetFloat(_volumeParameter, _valueMute);    
        }
        else
        {
            _currentValue = PlayerPrefs.GetFloat(_volumeParameter);
            _mixer.SetFloat(_volumeParameter, _currentValue);
        }
    }
}