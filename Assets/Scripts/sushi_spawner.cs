using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class sushi_spawner : MonoBehaviour
{
    public GameObject sushi;
    public Vector3 spawnpos;
    public bool spawn = false;
    public int RandomNum;
    private float timetilspawn = 1;
    void Start()
    {
       
    }

    void Update()
    {
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
