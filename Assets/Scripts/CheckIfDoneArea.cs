using System.Collections.Generic;
using UnityEngine;

public class CheckIfDone : MonoBehaviour
{
    public bool restartbool;
    public GameObject Spawner;
    public GameObject board;
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
                checking.Remove(item);
                Destroy(item);
                Spawner.GetComponent<SushiRecipie>().MakeListForRecipe();
                board.GetComponent<Countdown>().Morepoints = true;
                board.GetComponent<Countdown>().RemainingTime += 10;
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
        restartbool = false;
    }
}
