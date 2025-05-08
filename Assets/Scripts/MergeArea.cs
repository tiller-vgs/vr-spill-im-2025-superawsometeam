using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MergeArea : MonoBehaviour
{
    public GameObject main_ingreadient;
    public List<GameObject> MergeList;
    public List<GameObject> MergingList;
    public bool HaveRice;
    public bool HaveMeat;
    public bool HaveGreen;
    public int IngredentPlacement = 1;
    void Update()
    {
        var IDcheck = false;
        foreach (var item in MergeList)
        {
            if (item.GetComponent<sushi_script>().IDS.Count < 1 || item.GetComponent<sushi_script>().IDS.Count >= 3)
            {
                //if (!IDcheck)
                //{
                //    GiveIDTo = item;
                //    IDcheck = true;
                //}
                MergeList.Remove(item);
                Debug.Log("removed2 " + item + " from mergelist");
                return;
            }
            if (item.transform.GetChild(IngredentPlacement).GetComponent<sushi_ingridient>().WhatFoodIsThis == "Rice" && HaveRice==false)
            {
                HaveRice = true;
                MergingList.Add(item);
                Debug.Log("added R");
            }
            else if (item.transform.GetChild(IngredentPlacement).GetComponent<sushi_ingridient>().WhatFoodIsThis == "Meat" && HaveMeat == false)
            {
                HaveMeat = true;
                MergingList.Add(item);
                main_ingreadient = item;
                Debug.Log("added M");
            } else if (item.transform.GetChild(IngredentPlacement).GetComponent<sushi_ingridient>().WhatFoodIsThis == "Green" && HaveGreen == false)
            {
                HaveGreen = true;
                MergingList.Add(item);
                Debug.Log("added G");
            }
            //return;
        }
        if (HaveGreen == true && HaveMeat == true && HaveRice == true)
        {
            //Debug.Log("starting merging");
            foreach (var item in MergingList)   
            {
                Debug.Log(item.name+" "+MergingList);
                var ee = item;// MergingList[MergingList.Count - 1];
                if (item==main_ingreadient)
                {
                    
                }
                else
                {
                    main_ingreadient.GetComponent<sushi_script>().getID(ee.transform.GetChild(IngredentPlacement).GetComponent<sushi_ingridient>().id);
                    ee.transform.GetChild(IngredentPlacement).GetComponent<sushi_ingridient>().MergeIntoThis(main_ingreadient);
                    MergingList.Remove(ee);
                    MergeList.Remove(ee);
                    ee.GetComponent<sushi_script>().deleate_clone();
                    
                    return;
                }
            }
            //Debug.Log("reseting");
            HaveGreen = false;
            HaveMeat = false;
            HaveRice = false;
            MergingList = new List<GameObject>();
        }
        else
        {
            //Debug.Log("reseting");
            HaveGreen = false;
            HaveMeat = false;
            HaveRice = false;
            MergingList = new List<GameObject>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var thing = other.transform.parent.gameObject;
        //Debug.Log(thing.name);
        if (thing.GetComponent<sushi_script>().IDS.Count == 1)
        {
            MergeList.Add(thing);
            Debug.Log("added " + thing + " to mergelist");
        }
        else
        {
            Debug.Log("cannot add " + thing + "to mergelist");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var thing = other.transform.parent.gameObject;
        MergeList.Remove(thing);
        Debug.Log("removed " + thing + " from mergelist");
    }
}
