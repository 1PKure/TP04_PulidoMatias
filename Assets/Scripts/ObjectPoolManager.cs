using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{

    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private List<GameObject> pool;

    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(powerUpPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }

    public void SpawnPowerUp(Vector2 position)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = position;
            obj.SetActive(true);
        }
    }
}
