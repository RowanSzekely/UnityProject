using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 2;
    public Health playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DeleteAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){

            if(playerHealth == null){
                playerHealth = collision.gameObject.GetComponent<Health>();
            }
            Destroy(gameObject);
            playerHealth.TakeDamage(damage);
            
        }
    }

    private IEnumerator DeleteAfterTime(){
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
