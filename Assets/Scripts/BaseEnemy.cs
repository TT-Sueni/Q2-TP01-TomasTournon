using UnityEngine;
public abstract class BaseEnemy : MonoBehaviour, IDamageable, IPooleable
{
    [SerializeField] protected float speed = 1f;

    [SerializeField] protected GameObject target;
    [SerializeField] protected LayerMask bulletMask;
    [SerializeField] protected GameObject prefab;
    
    protected bool isAlive;

  


    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public virtual void GetObjectFromPool()
    {
      
    }

    public virtual void ResetToDefault()
    {
        
    }

    public virtual void ReturntoPool()
    {
        
    }

    public virtual void SetParent()
    {
        
    }
}

