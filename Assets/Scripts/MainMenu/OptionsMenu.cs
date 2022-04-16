using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public GameObject sensiInputField;
    public GameObject sliderObj;

    TMP_InputField sensiInputTMP;
    Slider sensiSlider;

    public Toggle toggle;

    void Start()
    {
        // set the sensitivity to the current value
        float sensitivityApplied = SettingsStorage.sensitivity;
        sensiInputTMP = sensiInputField.GetComponent<TMP_InputField>();
        sensiInputTMP.text = sensitivityApplied.ToString("0.###");

        sensiSlider = sliderObj.GetComponent<Slider>();
        sensiSlider.value = sensitivityApplied;
        toggle.isOn = SettingsStorage.audioON;

        PlayerController.mouseSensitivity = SettingsStorage.sensitivity;
    }

    public void setSensitivityOnSlider(float sensitivity)
    {
        PlayerController.mouseSensitivity = sensitivity;
        SettingsStorage.sensitivity = sensitivity;
        sensiInputTMP.text = sensitivity.ToString("0.###");
    }

    public void setSensitivityOnInputField(string sensitivity)
    {
        // if sensitivity is empty string, do not change sensitivity
        if (sensitivity == "")
        {
            sensiInputTMP.text = SettingsStorage.sensitivity.ToString("0.###");
            return;
        }
        PlayerController.mouseSensitivity = float.Parse(sensitivity);
        sensiSlider.value = float.Parse(sensitivity);
        SettingsStorage.sensitivity = float.Parse(sensitivity);
    }

    public void setAudio()
    {
        if (toggle.isOn)
        {
            Debug.Log("Audio is ON");
            SettingsStorage.audioON = true;
            AudioListener.volume = 1;
        }
        else
        {
            Debug.Log("Audio is OFF");
            SettingsStorage.audioON = false;
            AudioListener.volume = 0;
        }
    }
}
