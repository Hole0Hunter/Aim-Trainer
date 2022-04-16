using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillSelection : MonoBehaviour
{
    /*
     * In the build settings 
     * Menu Index -> 0
     * Flickshot Index -> 1
     * ReactionTime Index -> 2
     * Tracking Index -> 3
    */
    public void FlickshotSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void ReactionTimeSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void TrackingSelect()
    {
        SceneManager.LoadScene(3);
    }

}
