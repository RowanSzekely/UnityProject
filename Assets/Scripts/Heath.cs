using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth = 10;

    [SerializeField] GameObject loseCam;

    [SerializeField] GameObject loseScreen;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount){
        health -= amount;
        if(health <= 0){
            Destroy(gameObject);
            loseCam.SetActive(true);
            loseScreen.SetActive(true);
            
        }
    }

    public int intPlayerHealth(){
        return health;
    }
}
