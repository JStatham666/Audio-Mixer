using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    [SerializeField] private string _volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer _mixer;

    private void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(_volumeParameter, -80f);
        _mixer.SetFloat(_volumeParameter, volumeValue);
    }
}