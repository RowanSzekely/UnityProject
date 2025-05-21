using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{

    private int damageAmount = 5;

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Decrement(damageAmount);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Didn't find Health on collision gameobject");
        }
    }
}
