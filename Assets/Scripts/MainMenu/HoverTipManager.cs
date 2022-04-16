using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTipManager : MonoBehaviour
{
    [SerializeField] private GameObject flickshotTip;
    [SerializeField] private GameObject ReactionTimeTip;
    [SerializeField] private GameObject TrackingTip;

    // Start is called before the first frame update
    void Start()
    {
        flickshotTip.SetActive(false);
        ReactionTimeTip.SetActive(false);
        TrackingTip.SetActive(false);
    }

    public void ShowFlickshotTip()
    {
        flickshotTip.SetActive(true);
    }

    public void ShowReactionTimeTip()
    {
        ReactionTimeTip.SetActive(true);
    }

    public void ShowTrackingTip()
    {
        TrackingTip.SetActive(true);
    }

    public void HideFlickshotTip()
    {
        flickshotTip.SetActive(false);
    }

    public void HideReactionTimeTip()
    {
        ReactionTimeTip.SetActive(false);
    }

    public void HideTrackingTip()
    {
        TrackingTip.SetActive(false);
    }
}
