using UnityEngine;

public class KillplaneController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        TargetController target = other.gameObject.GetComponent<TargetController>();
        if (target != null)
        {
            GameManager.Instance.addScore((int) target.type);
            Destroy(other.gameObject);
        }
    }

}
