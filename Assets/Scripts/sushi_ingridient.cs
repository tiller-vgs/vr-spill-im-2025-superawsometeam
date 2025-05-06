using UnityEngine;

public class sushi_ingridient : MonoBehaviour
{
    public string WhatFoodIsThis;
    public GameObject parentto;
    void Start()
    {
    }

    void Update()
    {

    }
    public void WantsToMerge()
    {
        
    }
    public void MergeIntoThis(GameObject parenttwo)
    {
        Debug.Log(gameObject.transform.parent = parenttwo.transform);
    }
}
