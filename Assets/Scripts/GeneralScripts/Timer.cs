using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeLeft = 60f;
    [SerializeField] private GameObject gameOverScreen;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        gameOver = false;
        timerText.text = "Time Left: " + timeLeft.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountdownTimer.isCountingDown)
        {
            timeLeft -= 1 * Time.deltaTime;
        }
        
        timerText.text = "Time Left: " + timeLeft.ToString("0");

        if (timeLeft <= 0)
        {
            timerText.text = "Time Left: " + "0";
            timeLeft = 0;
            // display game over screen
            gameOverScreen.SetActive(true);
            gameOver = true;
        }
    }
}
