using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnDamagers : MonoBehaviour
{
    [SerializeField] DamageStickPool damageStickPool;
    [SerializeField] GameObject player;

    public Color red;
    public Color pink;





    void Start()
    {
        StartCoroutine(SpawnDelay());
    }




    private IEnumerator SpawnDelay()
    {
        while (player.activeSelf == true)
        {
            yield return new WaitForSeconds(4);
            PooledObject instance = damageStickPool.GetFromPool(pink);
            StartCoroutine(DeleteAfterTime(instance));
        }
    }

    private IEnumerator DeleteAfterTime(PooledObject returningStick)
    {
        yield return new WaitForSeconds(8);
        Debug.Log("Should turn Red Now");
        returningStick.gameObject.GetComponentInChildren<Renderer>().material.color = red;
        yield return new WaitForSeconds(2);
        damageStickPool.ReturnToPool(returningStick);
         
    }

    
}
