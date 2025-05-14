using UnityEngine;

public class delete_sushi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("del");
        if (other.gameObject.tag == "ingredient")
        {
            other.transform.parent.gameObject.GetComponent<sushi_script>().deleate_clone();

        }
    }
}
