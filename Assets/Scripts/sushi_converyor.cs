using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class sushi_converyor : MonoBehaviour
{
    public Vector3 moving;
    public string ee;
    public List<GameObject> MovingList;
    void Start()
    {
        
    }
    void Update()
    {
        //gameObject.transform.localScale = ;
        var rotation = gameObject.transform.rotation.y;
        var PointHelp= (int)((rotation + 1) / 90);
        //rotation -= PointHelp * 90;
        var RotationPoint = (rotation - (PointHelp * 90)) / 90;
        if ((PointHelp + 1)/4== (int)((PointHelp + 1)/4))
        {
            moving = new Vector3(-1 + RotationPoint, 0, 0 + RotationPoint);
        }
        else if ((PointHelp + 1) / 3 == (int)((PointHelp + 1) / 3))
        {
            moving = new Vector3(0 - RotationPoint, 0, -1 + RotationPoint);
        }
        else if((PointHelp + 1) / 2 == (int)((PointHelp + 1) / 2))
        {
            moving = new Vector3(1 - RotationPoint, 0, 0 - RotationPoint);
        }
        else if ((PointHelp + 1) / 1 == (int)((PointHelp + 1) / 1))
        {
            moving = new Vector3(0 + RotationPoint, 0, 1 - RotationPoint);
        }
        moving /= 5;
        var self_pos = gameObject.transform.position;
        //if (self_pos.x < 0 && self_pos.x > 0  &&  )
        {

        }
        
        foreach (var item in MovingList)// get all tutching
        {
            item.GetComponent<sushi_script>().StraitConveyor(Quaternion.identity, moving);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        MovingList.Add(other.gameObject);
        Debug.Log("yee");
    }
    private void OnTriggerExit(Collider other)
    {
        MovingList.Remove(other.gameObject);
        Debug.Log("yes");
    }
}
