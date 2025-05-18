using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class sushi_spawner : MonoBehaviour
{
    public GameObject sushi;
    public Vector3 spawnpos;
    public Vector3 distance;
    //public float PauseForSpawn;
    //public bool spawn = false;
    private float timetilspawn = 1;
    void Update()
    {
        timetilspawn -= 1*Time.deltaTime;

        if (timetilspawn <= 0)
        {
            Spawn();
            timetilspawn = 1;
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
