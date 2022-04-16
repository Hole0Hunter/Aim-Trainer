using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDumper : MonoBehaviour
{
    [System.Serializable]
    public class FlickshotStats
    {
        public int score;
        public float accuracy;
        public int targetsDestroyed;

        public FlickshotStats(int score, float accuracy, int targetsDestroyed)
        {
            this.score = score;
            this.accuracy = accuracy;
            this.targetsDestroyed = targetsDestroyed;
        }
    }

    public static void Dump(int score, float accuracy, int targetsDestroyed)
    {
        FlickshotStats fs = new FlickshotStats(score, accuracy, targetsDestroyed);
        
        string json = JsonUtility.ToJson(fs);
        string path = Application.dataPath + "/FlickshotStats.json";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(json);
        }
    }
}
