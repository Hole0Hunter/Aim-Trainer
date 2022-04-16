using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDumperT : MonoBehaviour
{
    [System.Serializable]
    public class TrackingStats
    {
        public int score;
        public float accuracy;
        public int targetsDestroyed;

        public TrackingStats(int score, float accuracy, int targetsDestroyed)
        {
            this.score = score;
            this.accuracy = accuracy;
            this.targetsDestroyed = targetsDestroyed;
        }
    }

    public static void Dump(int score, float accuracy, int targetsDestroyed)
    {
        TrackingStats rs = new TrackingStats(score, accuracy, targetsDestroyed);

        string json = JsonUtility.ToJson(rs);
        string path = Application.dataPath + "/TrackingStats.json";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(json);
        }
    }        
}