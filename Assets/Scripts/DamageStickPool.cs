using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageStickPool : MonoBehaviour
{
    [SerializeField] private PooledObject damageStick;
    [SerializeField] private int poolSize;

    private Stack<PooledObject> stack;

    


    void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;

        for (int i = 0; i < poolSize; i++)
        {   
            Vector3 randomSpawn = new Vector3(Random.Range(20,30), 40, Random.Range(-13, 13));
            instance = Instantiate(damageStick, randomSpawn, Quaternion.identity);

            instance.Pool = this;

            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public PooledObject GetFromPool(Color color)
    {
        if (stack.Count != 0)
        {
            PooledObject nextInstance = stack.Pop();
            nextInstance.gameObject.GetComponentInChildren<Renderer>().material.color = color;
            nextInstance.gameObject.SetActive(true);
            return nextInstance;
        }
        else
        {
            Vector3 randomSpawn = new Vector3(Random.Range(20,30), 40, Random.Range(-13, 13));
            PooledObject newInstance = Instantiate(damageStick, randomSpawn, Quaternion.identity);
            newInstance.gameObject.GetComponentInChildren<Renderer>().material.color = color;

            newInstance.Pool = this;

            return newInstance;
        }
    }

    public void ReturnToPool(PooledObject returningStick)
    {
        if (stack.Count < poolSize)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(20,30), 40, Random.Range(-13, 13));
            
            returningStick.GetComponent<Transform>().position = randomSpawn;
            stack.Push(returningStick);
            returningStick.gameObject.SetActive(false);
        }
    }
}
