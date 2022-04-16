using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelHandlerRC : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] GameObject finalSuccessMenu;
    [SerializeField] GameObject successMenu;
    [SerializeField] GameObject failedMenu;
    [SerializeField] GameObject rxntimeGameObject;
    [SerializeField] GameObject finalRxntimeGameObject;
    [SerializeField] GameObject numOfTargetsGameObject;

    [SerializeField] AudioClip destroySFX;

    bool endMenuPopped;  // to prevent multiple popups
    [SerializeField] int numOfIterations = 10; // number of iterations to run the game
    int iterations = 0;

    List<float> reactionTimes;

    TextMeshProUGUI rt;
    TextMeshProUGUI avgRt;
    TextMeshProUGUI numOfTargets;

    void Start()
    {   
        reactionTimes = new List<float>();
        rt = rxntimeGameObject.GetComponent<TextMeshProUGUI>();
        avgRt = finalRxntimeGameObject.GetComponent<TextMeshProUGUI>();
        numOfTargets = numOfTargetsGameObject.GetComponent<TextMeshProUGUI>();
        numOfTargets.SetText("Targets: " + iterations.ToString() + "/" + numOfIterations.ToString());
        RestartScene();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && !endMenuPopped)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        // Debug.Log(Time.timeScale);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void GoBackHome()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClick()
    {
        // Debug.Log("CLICKED!");
        // if clicked early, display failed menu
        if (BackgroundColor.isRed)
        {
            // give penalty
            ScoreSystemRT.GivePenalty();
        }
        // if clicked late, display success menu
        else
        {
            // calculate reaction time
            AudioSource.PlayClipAtPoint(destroySFX, Camera.main.transform.position);
            float reactionTime = (Time.timeSinceLevelLoad - BackgroundColor.timeToPop) * 1000;
            rt.SetText(reactionTime.ToString("0.###") + "ms");
            reactionTimes.Add(reactionTime);
            iterations++;
            numOfTargets.SetText("Targets: " + iterations.ToString() + "/" + numOfIterations.ToString());

            ScoreSystemRT.GiveScore(reactionTime);
            if (iterations == numOfIterations)
            {
                // calculate average reaction time
                float avgReactionTime = 0;
                foreach (float rt_ in reactionTimes)
                {
                    Debug.Log("Reaction time: " + rt_);
                    avgReactionTime += rt_;
                }
                avgReactionTime /= numOfIterations;
                avgRt.SetText(avgReactionTime.ToString("0.###") + "ms");
                finalSuccessMenu.SetActive(true);

                ScoreSystemRT.UpdateFinalScore(avgReactionTime);
            }
            else
            {
                successMenu.SetActive(true);
            }
            endMenuPopped = true;
            BackgroundColor.timeToPop = BackgroundColor.RestartBackground() + Time.timeSinceLevelLoad;
            Time.timeScale = 0f;
        }
        // Debug.Log("Time since level load: " + Time.timeSinceLevelLoad);
    }

    public void Retry()
    {
        RestartScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        successMenu.SetActive(false);
        finalSuccessMenu.SetActive(false);
        failedMenu.SetActive(false);
        endMenuPopped = false;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
