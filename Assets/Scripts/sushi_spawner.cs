using System.Collections.Generic;
using UnityEngine;

public class sushi_spawner : MonoBehaviour
{
    public List<GameObject> allenemyes;
    public GameObject sushi;
    public Vector3 spawnpos = new Vector3(0, 0, 0);
    public bool spawn;
    public int RandomNum;
    public Vector3 distance = new Vector3(0,0,0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawnpos = sushi.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn)
        {
            sushi = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount+1)).gameObject;
            
            GameObject Spawned_sushi = Instantiate(sushi, spawnpos+distance, Quaternion.identity);
            //allenemyes.Add(newPlatform);
            Spawned_sushi.SetActive(true);
            //newPlatform.GetComponent<enemye_script>();
            spawn = false;
            distance += new Vector3(-1, 0, 0);
        }

    }
}
