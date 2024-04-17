using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnobject;

    public SpawnCount spawncount;

    public int maxobjects;

    private int randomint;

    private void Start()
    {
        Invoke("Spawn", 0);
    }

    private void Spawn()
    {
        if (spawncount.allobjects < maxobjects)
        {
            randomint = Random.Range(0, 10);

            if (randomint == 5)
            {
                Instantiate(spawnobject, transform.position, transform.rotation);
                spawncount.allobjects++;
            }
            else
            {
                Invoke("Spawn", spawncount.delay);
            }
        }
    }
}
