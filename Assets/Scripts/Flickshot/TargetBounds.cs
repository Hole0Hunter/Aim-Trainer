using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;
    [SerializeField] private GameObject target;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider boxCollider;
    List<Vector3> spawnPositions;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPositions = new List<Vector3>();
        Vector3 center = boxCollider.center + transform.position;

        // bounds of our random spawn
        float minX = center.x - boxCollider.size.x / 2f;
        float maxX = center.x + boxCollider.size.x / 2f;
        float minY = center.y - boxCollider.size.y / 2f;
        float maxY = center.y + boxCollider.size.y / 2f;
        float minZ = center.z - boxCollider.size.z / 2f;
        float maxZ = center.z + boxCollider.size.z / 2f;
        
        // X-axis
        for (float i = (float)minX; i < (float)maxX; i += 3f)
        {
            // Y-axis
            for (float j = (float)minY; j < (float)maxY; j += 3f)
            {
                Vector3 pos = new Vector3(i, j, minZ);
                spawnPositions.Add(pos);
            }
        }

        // Spawn 3 targets with their positions randomly selected from the list
        List<Vector3> tempList = new List<Vector3>(spawnPositions);
        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, tempList.Count);
            Vector3 pos = (Vector3)tempList[index];
            tempList.RemoveAt(index);
            Instantiate(target, pos, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Vector3[] GetCurrentTargetPositions()
    {
        GameObject[] currTargets;
        currTargets = GameObject.FindGameObjectsWithTag("Target");
        Vector3[] currTargetPositions = new Vector3[currTargets.Length];
        for (int i = 0; i < currTargets.Length; i++)
        {
            currTargetPositions[i] = currTargets[i].transform.position;
        }

        return currTargetPositions;
    }
    
    public List<Vector3> UpdateSpawnPositionsList()
    {
        List<Vector3> updatedSpawnPositions = new List<Vector3>(spawnPositions);
        Vector3[] currTargetPositions = GetCurrentTargetPositions();
        for (int i = 0; i < currTargetPositions.Length; i++)
        {
            updatedSpawnPositions.Remove(currTargetPositions[i]);
        }
        return updatedSpawnPositions;
    }

    public Vector3 GetRandomPosition()
    {
        // remove already occupying positions from the list
        List<Vector3> updatedSpawnPositions = UpdateSpawnPositionsList();   

        // random vector3 generation in the spawn area from the spawnPositions
        int index = Random.Range(0, updatedSpawnPositions.Count);
        Vector3 randomPosition = updatedSpawnPositions[index];
        return randomPosition;
    }
}
