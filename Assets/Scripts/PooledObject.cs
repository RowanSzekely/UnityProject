using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private DamageStickPool pool;
    public DamageStickPool Pool { get => pool; set => pool = value; }

    public void Release()
    {
        pool.ReturnToPool(this);
    }

}
