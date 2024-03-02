using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    [SerializeField] private Slider volumeslider = null;
    [SerializeField] private Text volumeText = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSLider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeslider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volumeValue");
        volumeslider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
