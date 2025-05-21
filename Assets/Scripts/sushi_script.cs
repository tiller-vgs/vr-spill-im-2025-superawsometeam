using System.Collections.Generic;
using UnityEngine;

public class sushi_script : MonoBehaviour
{
    public float speed;
    public Vector3 moving;
    public List<int> IDS;
    public int IngredentPlacement = 0;
    public sushi_script SushiScript;
    public sushi_ingridient IngredientScript;
    public GameObject SushiIngredient;
    public List<GameObject> MovingList;
    public float time=0;
    public bool normalfood;
    void Start()
    {
        SushiScript = gameObject.GetComponent<sushi_script>();
        SushiIngredient = gameObject.transform.GetChild(IngredentPlacement).gameObject;
        IngredientScript = SushiIngredient.GetComponent<sushi_ingridient>();
        //Debug.Log(normalfood);
        if (normalfood)
        {
            IDS.Add(IngredientScript.id);
        }
        
    }
    private void Update()
    {
        if (MovingList.Count >= 1)
        {
            var rotation = MovingList[MovingList.Count-1].transform.eulerAngles.y;
            var PointHelp = (int)((rotation) / 90);
            var RotationPoint = (rotation - (PointHelp * 90)) / 90 - 0.05f;
            if ((float)(PointHelp + 1) / 4 == (int)((PointHelp + 1) / 4))
            {
                moving = new Vector3(-speed + (RotationPoint * speed), 0, 0 + (RotationPoint * speed));
            }
            else if ((float)(PointHelp + 1) / 3 == (int)((PointHelp + 1) / 3))
            {
                moving = new Vector3(0 - (RotationPoint * speed), 0, -speed + (RotationPoint * speed));
            }
            else if ((float)(PointHelp + 1) / 2 == (int)((PointHelp + 1) / 2))
            {
                moving = new Vector3(speed - (RotationPoint * speed), 0, 0 - (RotationPoint * speed));
            }
            else if ((float)(PointHelp + 1) / 1 == (int)((PointHelp + 1) / 1))
            {
                moving = new Vector3(0 + (RotationPoint * speed), 0, speed - (RotationPoint * speed));
            }
            //moving /= 200;
            var timepause = 0.005f;
            if (time < timepause)
            {
                time += Time.deltaTime;
            }
            else
            {
                StraitConveyor(moving);
                time -= timepause;
            }
            //Debug.Log(Time.deltaTime);
        }
    }
    public void StraitConveyor(Vector3 moving)
    {
        gameObject.transform.position += moving;
    }
    public void deleate_clone()
    {
        Destroy(gameObject);
    }
    public void getID(int id)
    {
        IDS.Add(id);
        //Debug.Log("got id"+id);
    }
    //public void removeID(int id)
    //{
    //    IDS.Remove(id);
    //}
    public void Clear_IDS()
    {
        IDS.Clear();
        Debug.Log("w" + IDS.Count);
    }
}
