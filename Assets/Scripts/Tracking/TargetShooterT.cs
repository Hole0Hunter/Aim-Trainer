using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooterT : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float damage = 10f;

    [SerializeField] float rayTime;
    [SerializeField] float rayOnTargetTime;

    public static int numOfTargetsDestroyed;
    private static bool done;

    // Start is called before the first frame update
    void Start()
    {
        rayTime = 0f;
        rayOnTargetTime = 0f;
        numOfTargetsDestroyed = 0;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if(!PauseMenu.GameIsPaused && !CountdownTimer.isCountingDown)
        {
            rayTime += Time.deltaTime;
            if (Physics.Raycast(ray, out RaycastHit hit) && !CountdownTimer.isCountingDown && !Timer.gameOver)
            {
                TargetT target = hit.collider.gameObject.GetComponent<TargetT>();
                if (target != null)
                {
                    // Take damage
                    target.TakeDamage(damage * Time.deltaTime);
                    rayOnTargetTime += Time.deltaTime;
                    ScoreSystemT.UpdateScoreAndAccuracy(ScoreSystemT.score, CalculateAccuracy());
                }
            }
            else if (!CountdownTimer.isCountingDown && !Timer.gameOver)
            {
                ScoreSystemT.UpdateScoreAndAccuracy(ScoreSystemT.penalty, CalculateAccuracy());
            }
        }

        if (Timer.gameOver && !done)
        {
            done = true;
            ScoreSystemT.UpdateFinalScoreAndAccuracy(CalculateAccuracy(), numOfTargetsDestroyed);
        }
    }

    public float CalculateAccuracy()
    {
        if (rayTime == 0)
        {
            return 0;
        }
        return (rayOnTargetTime * 100) / rayTime;
    }
}
