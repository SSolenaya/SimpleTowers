using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Seka;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static Dictionary<string, Stack<GameObject>> _poolsDict;

    private static Dictionary<string, Stack<Enemy>> _poolsEnemyDict;
    private static Dictionary<string, Stack<Bullet>> _poolsBulletDict;
    private  static Transform _parentForDeactivatedGO;
    public Transform _parentGO;

    void Start() {
        Init();
    }

    public  void Init()   //  public static void Init(Transform pooledObjContainer)
    {
        _parentForDeactivatedGO = _parentGO;
        //parentForDeactivatedGO = pooledObjContainer;
        _poolsDict = new Dictionary<string, Stack<GameObject>>();
        _poolsEnemyDict = new Dictionary<string, Stack<Enemy>>();
        _poolsBulletDict = new Dictionary<string, Stack<Bullet>>();
    }

    public static Enemy GetEnemyFromPull(Enemy enemyPrefab)
    { //  получение объекта из пула по имени префаба
        if (!_poolsEnemyDict.ContainsKey(enemyPrefab.name))
        {
            _poolsEnemyDict[enemyPrefab.name] = new Stack<Enemy>();
        }

        Enemy result;
        if (_poolsEnemyDict[enemyPrefab.name].Count > 0)
        {
            result = _poolsEnemyDict[enemyPrefab.name].Pop();
            return result;
        }

        result = Instantiate(enemyPrefab, _parentForDeactivatedGO);
        result.name = enemyPrefab.name;
        return result;
    }

    public static void PutEnemyToPool(Enemy target)
    {
        _poolsEnemyDict[target.name].Push(target);
        target.transform.parent = _parentForDeactivatedGO;
        target.gameObject.SetActive(false);
    }

    public static Bullet GetBulletFromPull(Bullet bulletPrefab)
    { //  получение объекта из пула по имени префаба
        if (!_poolsBulletDict.ContainsKey(bulletPrefab.name))
        {
            _poolsBulletDict[bulletPrefab.name] = new Stack<Bullet>();
        }

        Bullet result;
        if (_poolsBulletDict[bulletPrefab.name].Count > 0)
        {
            result = _poolsBulletDict[bulletPrefab.name].Pop();
            return result;
        }

        result = Instantiate(bulletPrefab, _parentForDeactivatedGO);
        result.name = bulletPrefab.name;
        return result;
    }

    public static void PutBulletToPool(Bullet target)
    {
        _poolsBulletDict[target.name].Push(target);
        target.transform.parent = _parentForDeactivatedGO;
        target.gameObject.SetActive(false);
    }


    public static GameObject GetGOFromPull(GameObject prefab)
    { //  получение объекта из пула по имени префаба
        if (!_poolsDict.ContainsKey(prefab.name))
        {
            _poolsDict[prefab.name] = new Stack<GameObject>();
        }

        GameObject result;
        if (_poolsDict[prefab.name].Count > 0)
        {
            result = _poolsDict[prefab.name].Pop();
            return result;
        }

        result = Instantiate(prefab);
        result.name = prefab.name;
        return result;
    }

    public static void PutGOToPool(GameObject target)
    {
        _poolsDict[target.name].Push(target);
        //target.transform.parent = parentForDeactivatedGO;
        target.SetActive(false);
    }
}
