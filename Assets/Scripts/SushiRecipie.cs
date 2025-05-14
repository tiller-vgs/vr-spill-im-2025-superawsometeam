using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class SushiRecipie : MonoBehaviour
{
    private GameObject chooseIngredient;
    private string rightFood;
    private GameObject ingredientRice;
    private GameObject ingredientMeat;
    private GameObject ingredientGreen;
    public List<GameObject> ingredients;
    public Vector3 ShowPos;

    void Start()
    {
        MakeListForRecipe();
    }
    public void MakeListForRecipe()
    {
        ingredientRice = null;
        ingredientGreen = null;
        ingredientMeat = null;
        ingredients.Clear();
        Prosesing();
    }
    private void Prosesing()
    {
        chooseIngredient = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject.GetComponent<sushi_script>().SushiIngredient;
        if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Green")
        {
            if (ingredientGreen == null)
            {
                ingredientGreen = chooseIngredient;
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
        else if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == "Meat")
        {
            if (ingredientMeat == null)
            {
                ingredientMeat = chooseIngredient;
                ingredients.Add(chooseIngredient);
            }
        }


        CheckIfDone();
    }
    private void CheckIfDone()
    {
        if (ingredientRice == null || ingredientMeat == null || ingredientGreen == null)
        {
            Prosesing();
        }
        else
        {
            foreach (var item in ingredients)
            {
                GameObject Spawned_sushi = Instantiate(item, ShowPos, Quaternion.identity);
                Spawned_sushi.SetActive(true);
                
            }
        }
    }



    //void randomSushiRecipie()
    //{
    //    chooseIngredient = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject.GetComponent<sushi_script>().SushiIngredient;
    //    Debug.Log("Early" + chooseIngredient);
    //    if (ingredientRice != null && ingredientMeat != null)
    //    {
    //        rightFood = "Green";
    //        findRightRecipie();
    //    }
    //    else if (ingredientRice != null)
    //    {
    //        rightFood = "Meat";
    //        findRightRecipie();
    //    }
    //    else
    //    {
    //        rightFood = "Rice";
    //        findRightRecipie();
    //    }



    //}

    //void findRightRecipie()
    //{
    //    if (chooseIngredient.GetComponent<sushi_ingridient>().WhatFoodIsThis == rightFood)
    //    {
    //        giveValueToRecipie();
    //    }
    //    else
    //    {
    //        randomSushiRecipie();
    //    }
    //}

    //void giveValueToRecipie()
    //{
    //    if (ingredientRice != null && ingredientMeat != null)
    //    {
    //        ingredientGreen = chooseIngredient;
    //        Debug.Log(ingredientGreen);
    //    }
    //    else if (ingredientRice != null)
    //    {
    //        ingredientMeat = chooseIngredient;
    //        Debug.Log(ingredientMeat);
    //        randomSushiRecipie();

    //    }
    //    else
    //    {
    //        ingredientRice = chooseIngredient;
    //        Debug.Log(ingredientRice);
    //        randomSushiRecipie();
    //    }
    //}
}
