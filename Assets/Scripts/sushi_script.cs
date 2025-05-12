using System.Collections.Generic;
using UnityEngine;

public class sushi_script : MonoBehaviour
{
    public List<int> IDS;
    public int IngredentPlacement = 0;
    public sushi_script SushiScript;
    public sushi_ingridient IngredientScript;
    public GameObject SushiIngredient;
    void Start()
    {
        SushiScript = gameObject.GetComponent<sushi_script>();
        SushiIngredient = gameObject.transform.GetChild(IngredentPlacement).gameObject;
        IngredientScript = SushiIngredient.GetComponent<sushi_ingridient>();
        IDS.Add(IngredientScript.id);
    }
    public void StraitConveyor(Vector3 moving)
    {
        //gameObject.transform.rotation = rotation;// rotation to convayer
        gameObject.transform.position += moving;
        Debug.Log("working");

    }
    public void deleate_clone()
    {
        Destroy(gameObject);
    }
    public void getID(int id)
    {
        IDS.Add(id);
        Debug.Log("got id");
    }
    public void removeID(int id)
    {
        IDS.Remove(id);
    }
}
