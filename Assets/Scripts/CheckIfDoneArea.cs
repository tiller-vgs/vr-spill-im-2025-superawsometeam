using System.Collections.Generic;
using UnityEngine;

public class CheckIfDone : MonoBehaviour
{
    public bool restartbool;
    public bool newrestartbool;
    public GameObject Spawner;
    public GameObject board;
    public GameObject merge;
    public GameObject SpawnedSushiParent;
    public List<GameObject> checking;
    private List<int> IDS;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (restartbool)
        {
            Check_Restart();
        }
        if(newrestartbool)
        {
            Check_Right_Sushi();
        }

        foreach (var item in checking)
        {
            var num = 0;
            IDS =item.GetComponent<sushi_script>().IDS;
            foreach (var CheckingIDs in IDS)
            {
                foreach (var ingredient in Spawner.GetComponent<SushiRecipie>().ingredients)
                {
                    if (CheckingIDs == ingredient.GetComponent<sushi_ingridient>().id)
                    {
                        num += 1;
                    }
                }
            }
            if (num == Spawner.GetComponent<SushiRecipie>().ingredients.Count)
            {
                checking.Clear();
                Destroy(item);
                Check_Right_Sushi();
                
                return;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ingredient")
        {
            var thing = other.transform.parent.gameObject;
            checking.Add(thing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var thing = other.transform.parent.gameObject;
        checking.Remove(thing);
    }
    public void Check_Restart()
    {
        checking.Clear();
        board.GetComponent<Countdown>().Restart();
        Spawner.GetComponent<SushiRecipie>().MakeListForRecipe();
        merge.GetComponent<MergeArea>().clear();
        restartbool = false;
    }
    public void Check_Right_Sushi()
    {
        Spawner.GetComponent<SushiRecipie>().MakeListForRecipe();
        board.GetComponent<Countdown>().Right_Sushi();
        merge.GetComponent<MergeArea>().clear();
        var childnum = SpawnedSushiParent.transform.childCount-1;
        while (childnum >= 0)
        {
            Debug.Log(SpawnedSushiParent.transform.childCount + " " + childnum + " " + (SpawnedSushiParent.transform.GetChild(0).GetComponent<sushi_script>().MovingList.Count == 0));
            if (SpawnedSushiParent.transform.GetChild(childnum).GetComponent<sushi_script>().MovingList.Count == 0)
            {
                Destroy(SpawnedSushiParent.transform.GetChild(childnum).gameObject);
            }
            childnum -= 1;
        }
        newrestartbool = false;
    }
}
