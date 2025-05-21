using System.Linq.Expressions;
using UnityEngine;
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Citizen citizenPrefab;


    private void Start()
    {
        ObjectPool.Instance.InitializePool(bulletPrefab,0);
        ObjectPool.Instance.InitializePool(enemyPrefab,10);
        ObjectPool.Instance.InitializePool(citizenPrefab, 10);
        
    }
}

