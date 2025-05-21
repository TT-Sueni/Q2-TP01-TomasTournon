
using System;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviourSingleton<ObjectPool>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        //public GameObject prefab;
        public int sizeofPool;
    }




    //private List<Pool> pools;
    private Dictionary<Type, IPooleable> prefabs = new Dictionary<Type, IPooleable>();
    private Dictionary<Type, Queue<IPooleable>> poolDictionary = new Dictionary<Type, Queue<IPooleable>>();
    
    

   

    public void InitializePool<T>(T prefab, int poolSize = 10) where T : MonoBehaviour,IPooleable
    {
        if (!prefabs.ContainsKey(typeof(T)))
            prefabs.Add(typeof(T), prefab);
        Debug.Log(prefabs);

        if (!poolDictionary.ContainsKey(typeof(T)))
            poolDictionary.Add(typeof(T),new Queue<IPooleable>());
        for (int i = 0; i < poolSize; i++)
        {
            T instance = Instantiate(prefab, transform);
            instance.gameObject.SetActive(false);
            instance.SetParent();
           
            
            poolDictionary[typeof(T)].Enqueue(instance);
           
        }
       
    
     
    }
    public T Get<T>() where T : MonoBehaviour, IPooleable
    {
        bool hasKey = false;
        foreach (var obj in poolDictionary)
        {
            if (obj.Key == typeof(T))
            {
                if (obj.Value.Count > 0)
                {
                    T instance = (T)obj.Value.Dequeue();
                    //instance.ResetToDefault();
                    return instance;
                }
                else
                {
                    hasKey = true;
                    break;
                }
            }
            
        }

        foreach (var prefab in prefabs)
        {
            if (prefab.Key == typeof(T))
            {
                if (!hasKey)
                {
                    poolDictionary.Add(typeof(T), new Queue<IPooleable>());

                }

               //T objectToSpawn = (T)prefab.Value;
               //objectToSpawn.transform.position = position;
               //objectToSpawn.transform.rotation = rotation;
               //objectToSpawn.gameObject.SetActive(true);

                return GameObject.Instantiate((MonoBehaviour)prefab.Value,transform) as T;
            }
            
        }
        return null;

    }

    public void ReturnToPool<T>(T objectToPool) where T : MonoBehaviour, IPooleable
    {
        if (!poolDictionary.ContainsKey(typeof(T)))
            poolDictionary.Add(typeof(T), new Queue<IPooleable>());

        //objectToPool.gameObject.SetActive(false);
        poolDictionary[typeof(T)].Enqueue(objectToPool);
    }
    
}
