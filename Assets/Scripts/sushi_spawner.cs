using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class sushi_spawner : MonoBehaviour
{
    public float timetilspawn;
    public GameObject sushi;
    public Vector3 spawnpos;
    public Vector3 distance;
    public GameObject SpawnedSushiParent;
    //public float PauseForSpawn;
    //public bool spawn = false;
    
    void Update()
    {
        timetilspawn -= Time.deltaTime;

        if (timetilspawn <= 0)
        {
            Spawn();
            timetilspawn += 1;
        }
    }
    public void Spawn()
    {
        sushi = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject;
        GameObject Spawned_sushi = Instantiate(sushi, spawnpos, Quaternion.identity);
        Spawned_sushi.GetComponent<sushi_script>().normalfood = true;
        Spawned_sushi.SetActive(true);
        Spawned_sushi.GetComponent<sushi_script>().normalfood = true;
        Spawned_sushi.transform.parent = SpawnedSushiParent.transform;
        //distance += new Vector3(-1, 0, 0);
    }
}
