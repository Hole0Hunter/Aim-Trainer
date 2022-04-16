using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDumperRT : MonoBehaviour
{
    [System.Serializable]
    public class ReactionTimeStats
    {
        public int score;
        public float avgReactionTime;

        public ReactionTimeStats(int score, float avgReactionTime)
        {
            this.score = score;
            this.avgReactionTime = avgReactionTime;
        }
    }

    public static void Dump(int score, float avgReactionTime)
    {
        ReactionTimeStats rts = new ReactionTimeStats(score, avgReactionTime);

        string json = JsonUtility.ToJson(rts);
        string path = Application.dataPath + "/ReactionTimeStats.json";
        using (StreamWriter sw = File.AppendText(path))
        {
            sw.WriteLine(json);
        }
    }
}