using UnityEngine;

public class delete_sushi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("del");
        if(other.gameObject.tag=="sushi")
        other.gameObject.GetComponent<sushi_script>().deleate_clone();
    }
}
