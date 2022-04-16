using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    // Making a countdown timer
    [SerializeField] float startTime = 5.0f;
    public float currentTime;

    [SerializeField] GameObject countdownTimerGameObject;
    public static bool isCountingDown;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        isCountingDown = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI rt = countdownTimerGameObject.GetComponent<TextMeshProUGUI>();
        currentTime -= 1 * Time.deltaTime;
        rt.SetText(currentTime.ToString("0"));

        if (currentTime <= 0)
        {
            isCountingDown = false;
            Destroy(this.gameObject);
        }
    }
}
