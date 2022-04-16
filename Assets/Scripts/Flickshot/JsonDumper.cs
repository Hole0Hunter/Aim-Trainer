using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONDumper : MonoBehaviour
{
    [System.Serializable]
    public class FlickshotStats
    {
        int score;
        float accuracy;
        int targetsDestroyed;
    }

    [System.Serializable]
    public class FlickshotStatsList
    {
        public List<FlickshotStats> stats;
    }

    public FlickshotStatsList stats = new FlickshotStatsList();

    public void OutputJSON()
    {
        string json = JsonUtility.ToJson(new FlickshotStatsList());
        File.WriteAllText(Application.dataPath + "FlickshotStats.json", json);
    }

}
