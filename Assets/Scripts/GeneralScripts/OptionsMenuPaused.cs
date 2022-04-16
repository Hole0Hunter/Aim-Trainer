using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuPaused: MonoBehaviour
{
    public float sensitivity;
    public GameObject sliderObj;
    public GameObject sensiInputField;

    Slider sensiSlider;
    TMP_InputField sensiInputTMP;
        
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        sensitivity = SettingsStorage.sensitivity;
        // audio stuff
        toggle.isOn = SettingsStorage.audioON;
        gameObject.SetActive(false);

        sensiInputTMP = sensiInputField.GetComponent<TMP_InputField>();
        sensiInputTMP.text = sensitivity.ToString("0.###");

        sensiSlider = sliderObj.GetComponent<Slider>();
        sensiSlider.value = sensitivity;    
    }

    public void setSensitivityOnSlider(float sensitivity)
    {
        // Debug.Log(sensitivity);
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
