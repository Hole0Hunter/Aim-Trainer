using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystemT : MonoBehaviour
{
    [SerializeField] private GameObject scoreTextGameObject;
    [SerializeField] private GameObject accuracyTextGameObject;
    [SerializeField] private GameObject finalScoreTextGameObject;
    [SerializeField] private GameObject finalAccuracyTextGameObject;
    [SerializeField] private GameObject numOfTargetsHitGameObject;

    private static TextMeshProUGUI scoreText;
    private static TextMeshProUGUI accuracyText;
    private static TextMeshProUGUI finalScoreText;
    private static TextMeshProUGUI finalAccuracyText;
    private static TextMeshProUGUI numOfTargetsHitText;

    [SerializeField] public static int score = 50;
    [SerializeField] public static int penalty = -20;
    private static int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText = scoreTextGameObject.GetComponent<TextMeshProUGUI>();
        finalScoreText = finalScoreTextGameObject.GetComponent<TextMeshProUGUI>();
        accuracyText = accuracyTextGameObject.GetComponent<TextMeshProUGUI>();
        finalAccuracyText = finalAccuracyTextGameObject.GetComponent<TextMeshProUGUI>();
        numOfTargetsHitText = numOfTargetsHitGameObject.GetComponent<TextMeshProUGUI>();
    }

    public static void UpdateScoreAndAccuracy(int points, float accuracy)
    {
        currentScore += points;
        scoreText.text = currentScore.ToString("0");
        accuracyText.text = accuracy.ToString("0") + "%";
    }

    public static void UpdateFinalScoreAndAccuracy(float accuracy, int numOfTargetsHit)
    {
        finalScoreText.text = currentScore.ToString("0");
        finalAccuracyText.text = accuracy.ToString("0") + "%";
        numOfTargetsHitText.text = numOfTargetsHit.ToString("0");
        JsonDumperT.Dump(currentScore, accuracy, numOfTargetsHit);
    }
}
