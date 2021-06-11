using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    ObjectPooler objectPooler;
    public float xBound;
    public static SpawnManager instance;

    float timeSinceTreeSpawned = 0f;
    float timeSinceObstacleSpawned = 0f;
    [SerializeField]
    float objSpwnSpeed;
    [SerializeField]
    float zBoundary;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectPooler = ObjectPooler.instance;
    }
    void Update()
    {
        if(timeSinceTreeSpawned > 0.5f)
        {
            timeSinceTreeSpawned = 0f;
            SpawnTree();
        }
        timeSinceTreeSpawned += Time.deltaTime;

        if(timeSinceObstacleSpawned > 0.75f)
        {
            timeSinceObstacleSpawned = 0f;
            SpawnObstacle();
        }
        timeSinceObstacleSpawned += Time.deltaTime;
    }

    public float GetZboundary()
    {
        return zBoundary;
    }

    public float GetSpeed()
    {
        return objSpwnSpeed;
    }

    void SpawnTree()
    {
        Vector3 rdnPos = new Vector3(Random.Range(-xBound, +xBound), 5f, transform.position.z);
        transform.position = rdnPos;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if(hit.collider.gameObject.tag == "ground")
            {
                //spawn tree at random
                // % chance of spawning a tree
                float rdnPercent;
                rdnPercent = Random.Range(0f, 1f);
                if(rdnPercent <= 0.75f)
                {
                    Vector3 treePos = new Vector3(rdnPos.x, -5f, transform.position.z);
                    objectPooler.SpawnFromPool("tree", treePos, Quaternion.identity);
                }
            }
        }
    }

    void SpawnObstacle()
    {
        Vector3 rdnPos = new Vector3(Random.Range(-xBound, +xBound), 5f, transform.position.z);
        transform.position = rdnPos;
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if(hit.collider.gameObject.tag == "ground")
            {
                //spawn obstacle at random
                // % chance of spawning a obstacle
                float rdnPercent;
                rdnPercent = Random.Range(0f, 1f);
                if(rdnPercent <= 0.5f)
                {
                    Vector3 obstaclePos = new Vector3(rdnPos.x, -5f, transform.position.z);
                    objectPooler.SpawnFromPool("obstacle", obstaclePos, Quaternion.identity);
                }
            }
        }
    }
}
