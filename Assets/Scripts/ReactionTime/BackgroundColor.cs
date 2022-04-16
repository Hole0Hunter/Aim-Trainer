using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColor : MonoBehaviour
{
    public static bool isRed;
    public static float timeToPop;
    static Image img;

    [SerializeField] static float timeToPopLowerBound = 2f;
    [SerializeField] static float timeToPopUpperBound = 3f;

    // Note: Wait color RGB Values are: rgb(241,119,32)
    [SerializeField] static Color waitColor = new Color32(241, 119, 32, 255);
    // Note: Go color RGB Values are  : rgb(4,116,186)
    [SerializeField] static Color goColor = new Color32(4, 116, 186, 255);

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        RestartBackground();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad >= timeToPop)
        {
            isRed = false;
            img.color = goColor;
        }
    }

    public static float RestartBackground()
    {
        isRed = true;
        img.color = waitColor;
        // Debug.Log("Restarting background");
        timeToPop = Random.Range(timeToPopLowerBound, timeToPopUpperBound);
        return timeToPop;
    }
}
