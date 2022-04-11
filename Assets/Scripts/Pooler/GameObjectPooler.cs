using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPooler : MonoBehaviour, IPooler<GameObject>
{
    [SerializeField] private int poolSize;
    [SerializeField] private int maxPoolSize;
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> pool;

    private void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(prefab);
            instance.transform.SetParent(this.transform, false);
            instance.SetActive(false);
            pool.Enqueue(instance);
        }
    }
    public GameObject Get(Transform parent)
    {
        GameObject instance;
        if (pool.Count > 0)
        {
            instance = pool.Dequeue();
        }
        else
        {
            instance = Instantiate(prefab);
        }

        instance.transform.SetParent(parent, false);
        return instance;
    }

    public void PutBack(GameObject objectToPutback)
    {
        if (pool.Count > maxPoolSize)
        {

            objectToPutback.transform.SetParent(this.transform, false);
            objectToPutback.SetActive(false);
            pool.Enqueue(objectToPutback);
            return;
        }

        Destroy(objectToPutback);
    }
}
