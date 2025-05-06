using UnityEngine;

public class SushiRecipie : MonoBehaviour
{
    private GameObject chooseIngredient;
    private string rightFood;
    private GameObject ingredientRice;
    private GameObject ingredientMeat;
    private GameObject ingredientGreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomSushiRecipie();
        ingredientRice = null;
        ingredientGreen = null;
        ingredientMeat = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomSushiRecipie()
    {
        chooseIngredient = gameObject.transform.GetChild(Random.Range(0, gameObject.transform.childCount)).gameObject;
        Debug.Log("Early" + chooseIngredient);
        if (ingredientRice != null && ingredientMeat != null)
        {
            rightFood = "Green";
            findRightRecipie();
        }
        else if (ingredientRice != null)
        {
            rightFood = "Meat";
            findRightRecipie();
        }
        else
        {
            rightFood = "Rice";
            findRightRecipie();
        }



    }

    void findRightRecipie()
    {
        if (chooseIngredient.GetComponent<giveIngredentTag>().FoodTag == rightFood)
        {
            giveValueToRecipie();
        }
        else
        {
            randomSushiRecipie();
        }
    }

    void giveValueToRecipie()
    {
        if (ingredientRice != null && ingredientMeat != null)
        {
            ingredientGreen = chooseIngredient;
            Debug.Log(ingredientGreen);
        }
        else if (ingredientRice != null)
        {
            ingredientMeat = chooseIngredient;
            Debug.Log(ingredientMeat);
            randomSushiRecipie();

        }
        else
        {
            ingredientRice = chooseIngredient;
            Debug.Log(ingredientRice);
            randomSushiRecipie();
        }
    }
}
