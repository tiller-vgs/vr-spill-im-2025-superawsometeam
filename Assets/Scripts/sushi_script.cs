using System.Collections.Generic;
using UnityEngine;

public class sushi_script : MonoBehaviour
{
    public List<int> IDS;
    void Start()
    {
        //gameObject.transform.position += new Vector3(0, 5, 0);
        IDS.Add(gameObject.transform.GetChild(1).GetComponent<sushi_ingridient>().id);
    }
    void Update()
    {
        if (gameObject.transform.position.y > -1)
        {
            //Debug.Log("1");
        }
    }// Quaternion rotation
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
    public void addids()
    {

    }
}
