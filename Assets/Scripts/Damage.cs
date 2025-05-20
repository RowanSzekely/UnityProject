using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private int damageAmount = 5;


    void Start()
    {
        StartCoroutine(DeleteAfterTime());
    }


    private IEnumerator DeleteAfterTime(){
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.Decrement(damageAmount);
        }
        else
        {
            Debug.Log("Didn't find Health on collision gameobject");
        }
    }
}
