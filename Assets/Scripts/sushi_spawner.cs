using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class sushi_spawner : MonoBehaviour
{
    public GameObject sushi;
    public Vector3 spawnpos;
    public Vector3 distance;
    private float num;
    public float PauseForSpawn;
    public bool spawn = false;
    private float timetilspawn = 1;
    void Start()
    {
       
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
        countdowntimer();
        if (spawn == true)
        {
            sushi = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount+1)).gameObject;
            GameObject Spawned_sushi = Instantiate(sushi, spawnpos, Quaternion.identity);
            Spawned_sushi.SetActive(true);
            spawn = false;
            timetilspawn = 1;
            
        }
        
    }

    private void countdowntimer()
    {
        if (timetilspawn > 0)
        {
            timetilspawn -= Time.deltaTime;
        }
        else if (timetilspawn <= 0)
        {
            spawn = true;
        }
    }

}
