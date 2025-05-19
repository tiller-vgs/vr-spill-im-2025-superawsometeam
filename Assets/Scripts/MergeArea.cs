using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MergeArea : MonoBehaviour
{
    public List<GameObject> MergeList;
    public List<GameObject> MergingList;
    public bool HaveRice;
    public bool HaveMeat;
    public bool HaveGreen;
    public List<int> idlist;
    public GameObject SpawnedSushiParent;

    void Update()
    {
        foreach (var item in MergeList)
        {
            var itemScript = item.GetComponent<sushi_script>();
            var itemChild = itemScript.SushiIngredient;
            var itemChildScript = itemScript.IngredientScript;
            if (itemScript.IDS.Count < 1 || itemScript.IDS.Count >= 2)
            {
                MergeList.Remove(item);
                //Debug.Log("removed2 " + item + " from mergelist");
                return;
            }
            if (itemChildScript.WhatFoodIsThis == "Green" && HaveGreen == false)
            {
                HaveGreen = true;
                MergingList.Add(item);
                //Debug.Log("added G");
            }
            else if (itemChildScript.WhatFoodIsThis == "Meat" && HaveMeat == false)
            {
                HaveMeat = true;
                MergingList.Add(item);
                //Debug.Log("added M");
            } //else if (itemChildScript.WhatFoodIsThis == "Rice" && HaveRice == false)
            //{
            //    HaveRice = true;
            //    MergingList.Add(item);
            //    //Debug.Log("added R");
            //}
            //return;
        }
        if (HaveGreen == true && HaveMeat == true)// && HaveRice == true)
        {
            idlist.Clear();

            foreach (var item in MergingList)   
            {
                var itemScript = item.GetComponent<sushi_script>();
                var itemChildScript = itemScript.IngredientScript;

                idlist.Add(itemChildScript.id);
                Debug.Log("a" + itemChildScript.id);
                MergingList.Remove(item);
                MergeList.Remove(item);
                itemScript.deleate_clone();
                return;
            }

            var rannum = Random.Range(0, transform.childCount);
            GameObject Spawned_sushi = Instantiate(transform.GetChild(rannum).gameObject, transform.GetChild(rannum).position, Quaternion.identity, SpawnedSushiParent.transform);
            Spawned_sushi.GetComponent<sushi_script>().normalfood = false;
            Spawned_sushi.SetActive(true);
            Spawned_sushi.GetComponent<sushi_script>().normalfood = false;

            Debug.Log(idlist.Count+"t1"+ Spawned_sushi.GetComponent<sushi_script>().IDS.Count); 
            foreach (var item in idlist)
            {
                Debug.Log(item);
                Spawned_sushi.GetComponent<sushi_script>().getID(item);
            }
            //Spawned_sushi.GetComponent<sushi_script>().Clear_IDS();
            Spawned_sushi.GetComponent<sushi_script>().IDS = idlist;
            Debug.Log(idlist.Count + "t2" + Spawned_sushi.GetComponent<sushi_script>().IDS.Count);

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
        if (other.gameObject.name == "ingredient")
        {
            var thing = other.transform.parent.gameObject;
            //Debug.Log(thing.name);
            var itemScript = thing.GetComponent<sushi_script>();
            if (itemScript.IDS.Count >= 1 || itemScript.IDS.Count < 2)
            {
                MergeList.Add(thing);
                //Debug.Log("added " + thing + " to mergelist");
            }
            else
            {
                //Debug.Log("cannot add " + thing + "to mergelist");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var thing = other.transform.parent.gameObject;
        MergeList.Remove(thing);
        //Debug.Log("removed " + thing + " from mergelist");
    }
}
