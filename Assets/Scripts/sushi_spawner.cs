using System.Collections.Generic;
using UnityEngine;

public class sushi_spawner : MonoBehaviour
{
    public GameObject sushi;
    public Vector3 spawnpos;
    public Vector3 distance;
    private float num;
    public float PauseForSpawn;
    void Start()
    {
        spawnpos = gameObject.transform.position;
    }

    void Update()
    {
        num += 1*Time.deltaTime;

        if (num >= PauseForSpawn && PauseForSpawn != 0)
        {
            num=0;
            Spawn();
        }
    }
    public void Spawn()
    {
        sushi = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject;
        GameObject Spawned_sushi = Instantiate(sushi, spawnpos, Quaternion.identity);
        Spawned_sushi.SetActive(true);
        //distance += new Vector3(-1, 0, 0);
    }
}
