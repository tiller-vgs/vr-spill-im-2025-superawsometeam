using UnityEngine;

public class sushi_script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.position += new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > -1)
        {
            //gameObject.transform.position += new Vector3(0, -1, 0);
            Debug.Log("1");
        }
    }
    public void StraitConveyor(Quaternion rotation,Vector3 moving)
    {
        gameObject.transform.rotation = rotation;// rotation to convayer
        gameObject.transform.position += moving;
        Debug.Log("working");

    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position += new Vector3(0,0,5);
        Debug.Log("working kind of");
        if (gameObject.tag == "sushi") { Debug.Log("aa"); }
    }
    public void deleate_clone()
    {
        Destroy(gameObject);
    }
}
