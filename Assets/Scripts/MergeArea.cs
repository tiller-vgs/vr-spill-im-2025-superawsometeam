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
    void Update()
    {
        foreach (var item in MergeList)
        {
            var itemScript = item.GetComponent<sushi_script>();
            var itemChild = itemScript.SushiIngredient;
            var itemChildScript = itemScript.IngredientScript;
            if (itemScript.IDS.Count < 1 || itemScript.IDS.Count >= 3)
            {
                MergeList.Remove(item);
                //Debug.Log("removed2 " + item + " from mergelist");
                return;
            }
            if (itemChildScript.WhatFoodIsThis == "Rice" && HaveRice==false)
            {
                HaveRice = true;
                MergingList.Add(item);
                //Debug.Log("added R");
            }
            else if (itemChildScript.WhatFoodIsThis == "Meat" && HaveMeat == false)
            {
                HaveMeat = true;
                MergingList.Add(item);
                main_ingreadient = item;
                //Debug.Log("added M");
            } else if (itemChildScript.WhatFoodIsThis == "Green" && HaveGreen == false)
            {
                HaveGreen = true;
                MergingList.Add(item);
                //Debug.Log("added G");
            }
            //return;
        }
        if (HaveGreen == true && HaveMeat == true && HaveRice == true)
        {
            //Debug.Log("starting merging");
            foreach (var item in MergingList)   
            {
                //Debug.Log(item.name+" "+MergingList);
                var itemScript = item.GetComponent<sushi_script>();
                var itemChild = item.transform.GetChild(itemScript.IngredentPlacement);
                var itemChildScript = itemChild.GetComponent<sushi_ingridient>();

                if (item!=main_ingreadient)
                {
                    main_ingreadient.GetComponent<sushi_script>().getID(itemChildScript.id);
                    itemChildScript.MergeIntoThis(main_ingreadient);
                    MergingList.Remove(item);
                    MergeList.Remove(item);
                    itemScript.deleate_clone();

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
        if (other.gameObject.name == "ingredient")
        {
            var thing = other.transform.parent.gameObject;
            //Debug.Log(thing.name);
            var itemScript = thing.GetComponent<sushi_script>();
            if (itemScript.IDS.Count >= 1 || itemScript.IDS.Count < 3)
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
