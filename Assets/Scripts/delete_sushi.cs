using UnityEngine;

public class delete_sushi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ingredient")
        {
            other.transform.parent.gameObject.GetComponent<sushi_script>().deleate_clone();
        }
    }
}
