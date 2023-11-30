
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPawner : MonoBehaviour
{
    [SerializeField] List<GameObject> listGold = new List<GameObject>();
    [SerializeField] float spawnRate = 1f;
    [SerializeField] List<GameObject> GoldPool;
    [SerializeField] float PoolAmount = 10f;
    [SerializeField] Transform spawnPos;

    void CreatePool()
    {
        GoldPool = new List<GameObject>();
        GameObject instance;
        for (int i = 0; i < PoolAmount; i++)
        {
            int t;
            if (i < listGold.Count)
            {
                t = i;
            }
            else
            {
                t = Random.Range(0, listGold.Count-1);
            }
            instance = Instantiate(listGold[t]);
            instance.gameObject.SetActive(false);
            GoldPool.Add(instance);
        }
    }
    GameObject GetPooledObject()
    {
        //for (int i = 0; i < PoolAmount; i++)
        //{
        int i = Random.Range(0, GoldPool.Count - 1);
            if (!GoldPool[i].activeInHierarchy)
            {
                return GoldPool[i];
            }
        //}
        return null;
    }
    void Start()
    {
        //for(int i = 0;i< listGold.Count;i++)
        //{
            CreatePool();
        //}
        Fire();
    }
    private void Fire()
    {
        StartCoroutine(FireContinue());
    }

    IEnumerator FireContinue()
    {
        while (true)
        {
            GameObject instance;
            instance = GetPooledObject();
            if (instance != null)
            {
                Vector2 temp = new Vector2(spawnPos.position.x + 10, instance.transform.position.y);
                instance.transform.position = temp;
                instance.transform.rotation = transform.rotation;
                instance.SetActive(true);
            }

            yield return new WaitForSeconds(spawnRate);
        }
    }
    void Update()
    {
        
    }
}
