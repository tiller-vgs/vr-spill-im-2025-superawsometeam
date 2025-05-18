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

    void Start()
    {
        MakeListForRecipe();
    }
    public void MakeListForRecipe()
    {
        ingredientGreen = null;
        ingredientMeat = null;
        ingredients.Clear();
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
        else if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Rice")
        {
            if (ingredientRice == null)
            {
                ingredientRice = chooseIngredient;
                ingredients.Add(chooseIngredient);
            }
        }


        CheckIfDone();
    }
    private void CheckIfDone()
    {
        if (ingredientMeat == null || ingredientGreen == null || ingredientRice == null)
        {
            Prosesing();
        }
        else
        {
            var addpos = new Vector3(0, 0, 0);
            foreach (var item in ingredients)
            {
                GameObject Spawned_sushi = Instantiate(item, ShowPos-new Vector3(0,0,0), Quaternion.identity);
                Spawned_sushi.SetActive(true);
                
            }
        }
    }
}
