using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDamagers : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject damageStick;

    int i = 1;


    

    void Start()
    {
        StartCoroutine(SpawnDelay());
    }




    private IEnumerator SpawnDelay(){
        
        
        while(player.activeSelf == true){

            Vector3 randomSpawn = new Vector3(Random.Range(20,30), 40, Random.Range(-13, 13));
            

            yield return new WaitForSeconds(4);
            
            var newObject = Instantiate(damageStick, randomSpawn, Quaternion.identity);

            newObject.name = "DamageStick Copy #" + i;
            i++;
            

        }
    }

    
}
