using UnityEngine;
using Vitals;

public class HealPlayer : MonoBehaviour
{
    private bool hasHealed = false;

    private void OnTriggerEnter(Collider other)
    {
        Transform otherTransform = other.transform;
        if (hasHealed)
        {
            return;
        }

        if (otherTransform.CompareTag("Player"))
        {
            Health health = otherTransform.GetComponent<Health>();
            health.Increase(health.Value / 2f);
            hasHealed = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
