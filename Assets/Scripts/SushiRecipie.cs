using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SushiRecipie : MonoBehaviour
{
    private GameObject chooseIngredient;
    private string rightFood;
    private GameObject ingredientMeat;
    private GameObject ingredientGreen;
    private GameObject ingredientRice;
    public List<GameObject> ingredients;
    public Vector3 ShowPos;
    private List<GameObject> Spawned_sushi_List = new List<GameObject> { };

    void Start()
    {
        MakeListForRecipe();
    }
    public void MakeListForRecipe()
    {
        ingredientGreen = null;
        ingredientMeat = null;
        ingredients.Clear();
        //Debug.Log(Spawned_sushi_List.Count);
        if (Spawned_sushi_List.Count > 0)
        {
            for (int i = 0; i <= Spawned_sushi_List.Count; i++)
            {
                //Debug.Log(Spawned_sushi_List.Count + " uu");
                var obj = Spawned_sushi_List[0];
                Destroy(obj);
                Spawned_sushi_List.Remove(obj);
            }
        }
        Spawned_sushi_List = new List<GameObject> { };
        Prosesing();
    }
    private void Prosesing()
    {
        chooseIngredient = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).GetChild(0).gameObject;
        if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Green")
        {
            if (ingredientGreen == null)
            {
                ingredientGreen = chooseIngredient;
                ingredients.Add(chooseIngredient);
            }
        }
        else if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Meat")
        {
            if (ingredientMeat == null)
            {
                ingredientMeat = chooseIngredient;
                ingredients.Add(chooseIngredient);
            }
        }
        //else if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Rice")
        //{
        //    if (ingredientRice == null)
        //    {
        //        ingredientRice = chooseIngredient;
        //        ingredients.Add(chooseIngredient);
        //    }
        //}
        CheckIfDone();
    }
    private void CheckIfDone()
    {
        if (ingredientMeat == null || ingredientGreen == null)// || ingredientRice == null)
        {
            Prosesing();
        }
        else
        {
            var addpos = new Vector3(0, 0, -1);
            foreach (var item in ingredients)
            {
                GameObject Spawned_sushi = Instantiate(item, ShowPos + addpos, Quaternion.identity);
                Spawned_sushi.SetActive(true);
                Spawned_sushi.transform.rotation = Quaternion.Euler(270, 90, 180);
                Spawned_sushi_List.Add(Spawned_sushi);
                addpos += new Vector3(0, 0, 1);
            }
        }
    }
}