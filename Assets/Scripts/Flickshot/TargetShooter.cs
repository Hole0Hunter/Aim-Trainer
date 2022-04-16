 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    [SerializeField] Camera cam;
    public int numOfClicks;
    public int numOfHits;
    private static bool done;

    // Start is called before the first frame update
    void Start()
    {
        numOfClicks = 0;
        numOfHits = 0;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused && !CountdownTimer.isCountingDown)
        {
            numOfClicks++;
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit) && !CountdownTimer.isCountingDown && !Timer.gameOver)
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                // Debug.Log(target.name);
                if (target != null)
                {
                    // Destroy(target.gameObject);
                    target.Hit();
                    numOfHits++;
                    ScoreSystem.UpdateScoreAndAccuracy(ScoreSystem.score, CalculateAccuracy());
                }
            }
            else if(!CountdownTimer.isCountingDown && !Timer.gameOver && !done)
            {
                // Debug.Log("No target found");
                ScoreSystem.UpdateScoreAndAccuracy(ScoreSystem.penalty, CalculateAccuracy());
            }
        }

        if (Timer.gameOver && !done)
        {
            done = true;
            ScoreSystem.UpdateFinalScoreAndAccuracy(CalculateAccuracy(), numOfHits);
        }
    }

    public float CalculateAccuracy()
    {
        if (numOfClicks == 0)
        {
            return 0;
        }
        return (float)(numOfHits * 100) / (float)numOfClicks;
    }
}
