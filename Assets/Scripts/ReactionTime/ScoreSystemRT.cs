using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystemRT : MonoBehaviour
{
    [SerializeField] private GameObject scoreTextGameObject;
    [SerializeField] private GameObject finalScoreTextGameObject;
    private static TextMeshProUGUI scoreText;
    private static TextMeshProUGUI finalScoreText;

    [SerializeField] static int penalty = 200;
    [SerializeField] static int maxScore = 100000;
    private static int currentScore;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();
        finalScoreText = finalScoreTextGameObject.GetComponent<TextMeshProUGUI>();
    }

    public static int GivePenalty()
    {
        currentScore -= penalty;
        scoreText.text = currentScore.ToString("0");
        return currentScore;
    }
    
    public static int GiveScore(float reactionTime)
    {
        // reactionTime is in milliseconds
        // return a value such that as reaction time tends to 0 the score tends to maxScore and as the reaction time tends to infinite the score tends to 0
        currentScore += (int)(maxScore / (reactionTime + 1));
        scoreText.text = currentScore.ToString("0");
        return currentScore;
    }

    public static int UpdateFinalScore(float avgReactionTime)
    {
        finalScoreText.text = currentScore.ToString("0");
        JsonDumperRT.Dump(currentScore, avgReactionTime);
        return currentScore;
    }
}
