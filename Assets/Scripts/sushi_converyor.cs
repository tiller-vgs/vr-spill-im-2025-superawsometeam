using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class sushi_converyor : MonoBehaviour
{
    public float speed;
    public Vector3 moving;
    public string ee;
    public List<GameObject> MovingList;
    
    void Update()
    {
        //var rotation = gameObject.transform.eulerAngles.y;
        //var PointHelp = (int)((rotation + 1) / 90);
        //var RotationPoint = (rotation - (PointHelp * 90)) / 90;
        //if ((float)(PointHelp + 1) / 4 == (int)((PointHelp + 1) / 4))
        //{
        //    moving = new Vector3(-speed + (RotationPoint * speed), 0, 0 + (RotationPoint * speed));
        //}
        //else if ((float)(PointHelp + 1) / 3 == (int)((PointHelp + 1) / 3))
        //{
        //    moving = new Vector3(0 - (RotationPoint * speed), 0, -speed + (RotationPoint * speed));
        //}
        //else if ((float)(PointHelp + 1) / 2 == (int)((PointHelp + 1) / 2))
        //{
        //    moving = new Vector3(speed - (RotationPoint * speed), 0, 0 - (RotationPoint * speed));
        //}
        //else if ((float)(PointHelp + 1) / 1 == (int)((PointHelp + 1) / 1))
        //{
        //    moving = new Vector3(0 + (RotationPoint * speed), 0, speed - (RotationPoint * speed));
        //}
        //moving /= 200;

        //Debug.Log(moving + " " + RotationPoint + " " + rotation+" "+PointHelp);


        //var self_pos = gameObject.transform.position;
        //foreach (var item in MovingList)// get all tutching  Quaternion.identity
        //{
        //    item.transform.parent.GetComponent<sushi_script>().StraitConveyor(moving);
        //    Debug.Log("aa");
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " " + (other.gameObject.name == "ingredient"));
        if (other.gameObject.name == "ingredient")
        {
            other.gameObject.transform.parent.GetComponent<sushi_script>().speed=speed;
            other.gameObject.transform.parent.GetComponent<sushi_script>().MovingList.Add(gameObject);
            Debug.Log("ee");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ingredient")
        {
            other.gameObject.transform.parent.GetComponent<sushi_script>().MovingList.Remove(gameObject);
            Debug.Log("ee");
        }
    }
}
