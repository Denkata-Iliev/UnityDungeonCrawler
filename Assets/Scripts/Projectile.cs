using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vitals;

public class Projectile : MonoBehaviour
{
    public float damageDone = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;

        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Player is hit");
            // player takes damage
            hitTransform.GetComponent<Health>().Decrease(damageDone);
        }

        Destroy(gameObject, 1);
    }
}
