using UnityEngine;

public class sushi_ingridient : MonoBehaviour
{
    public string WhatFoodIsThis;
    public int id;
    public GameObject parentto;
    public void WantsToMerge()
    {
        
    }
    public void MergeIntoThis(GameObject parenttwo)
    {
        
        gameObject.transform.parent.gameObject.GetComponent<sushi_script>().removeID(id);
        gameObject.transform.parent = parenttwo.transform;
        var aa = gameObject.transform.parent.GetChild(1).position;
        var ee = new Vector3(0, 1, 0);
        if (WhatFoodIsThis == "Meat")
        {
            gameObject.transform.position = aa;
        }
        else if (WhatFoodIsThis == "Rice")
        {
            gameObject.transform.position = aa+ee;
        }
        else if (WhatFoodIsThis == "Green")
        {
            gameObject.transform.position = aa-ee;
        }
        //gameObject.transform.position = aa;
        Debug.Log("moved and " + aa);
    }
}
