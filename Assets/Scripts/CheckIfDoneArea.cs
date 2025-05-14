using System.Collections.Generic;
using UnityEngine;

public class CheckIfDone : MonoBehaviour
{
    public int points;
    public GameObject Spawner;
    public List<GameObject> checking;
    private List<int> IDS;
    private List<bool> checklist = new List<bool> { false, false, false };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //checklist.Add(false); 
        //checklist.Add(false); 
        //checklist.Add(false);
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var num = 0;
        foreach (var item in checking)
        {
            IDS=item.GetComponent<sushi_script>().IDS;
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
            if (num == 3)
            {
                checking.Remove(item);
                Destroy(item);
                points += 1;
                Spawner.GetComponent<SushiRecipie>().MakeListForRecipe();
                checklist = new List<bool> { false, false, false };
                return;
            }
            checklist = new List<bool> { false, false, false };
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
}
