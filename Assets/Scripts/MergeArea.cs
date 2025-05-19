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
    public GameObject Spawned_sushi;
    public bool spawning_sushi=false;

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
            if (!spawning_sushi)
            {
                spawning_sushi = true;
                var rannum = Random.Range(0, transform.childCount);
                Spawned_sushi = Instantiate(transform.GetChild(rannum).gameObject, transform.GetChild(rannum).position, Quaternion.identity, SpawnedSushiParent.transform);
                start1(); 
                start1();




                //Debug.Log(idlist.Count+"t1"+ Spawned_sushi.GetComponent<sushi_script>().IDS.Count);
                for (global::System.Int32 i = 0; i < 2; i++)
                {
                    //Debug.Log("num" + idlist[0] + " idlistcount" + idlist.Count);
                    Spawned_sushi.GetComponent<sushi_script>().getID(idlist[0]);
                    idlist.Remove(idlist[0]);
                }
                //Spawned_sushi.GetComponent<sushi_script>().Clear_IDS();
                //Debug.Log(idlist.Count + "t2" + Spawned_sushi.GetComponent<sushi_script>().IDS.Count);
                spawning_sushi = false;
                //Debug.Log("ww");
            }
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
    private void start1()
    {
        //Debug.Log("a");
        
        var ee = Spawned_sushi.GetComponent<sushi_script>();
        ee.normalfood = false;
        Spawned_sushi.SetActive(true);
        foreach (var item in MergingList)
        {
            var itemScript = item.GetComponent<sushi_script>();
            var itemChildScript = itemScript.IngredientScript;

            idlist.Add(itemChildScript.id);
            //Debug.Log("a" + itemChildScript.id+" margecount"+MergingList.Count);
            MergingList.Remove(item);
            MergeList.Remove(item);
            itemScript.deleate_clone();
            return;
        }
    }
    public void clear()
    {
        MergingList.Clear();
        MergeList.Clear();
        idlist.Clear();
        Spawned_sushi=null;
        spawning_sushi = false;
        HaveGreen = false;
        HaveMeat = false;
        HaveRice = false;
    }
}
