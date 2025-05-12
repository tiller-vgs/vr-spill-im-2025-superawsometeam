using System.Collections.Generic;
using UnityEngine;

public class sushi_spawner : MonoBehaviour
{
    public GameObject sushi;
    public Vector3 spawnpos;
    public bool spawn;
    public int RandomNum;
    public Vector3 distance;
    void Start()
    {
        spawnpos = gameObject.transform.position;
    }

    void Update()
    {
        if (spawn)
        {
            sushi = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount+1)).gameObject;
            
            GameObject Spawned_sushi = Instantiate(sushi, spawnpos+distance, Quaternion.identity);
            Spawned_sushi.SetActive(true);
            spawn = false;
            distance += new Vector3(-1, 0, 0);
        }

    }
}
