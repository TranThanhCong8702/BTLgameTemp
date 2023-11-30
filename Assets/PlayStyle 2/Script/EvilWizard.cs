using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizard : MonoBehaviour
{
    [SerializeField] bool IsAlive;
    [SerializeField] GameObject Player;
    Animator animator;

    [SerializeField] float attckRate = 1f;
    [SerializeField] float attckDuration = 2f;
    [SerializeField] float fasterRate = 15f;
    float temp; int count = 0;int i = 0;

    [SerializeField] List<GameObject> listAttack = new List<GameObject>();
    //[SerializeField] float spawnRate = 1f;
    [SerializeField] List<GameObject> AttackPool;
    [SerializeField] float PoolAmount = 10f;

    Hp hp;
    private void Awake()
    {
        hp = GetComponent<Hp>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        CreatePool();
        StartCoroutine(Attack());
    }
    void CreatePool()
    {
        AttackPool = new List<GameObject>();
        GameObject instance;
        for (int i = 0; i < PoolAmount; i++)
        {
            int t;
            if (i < listAttack.Count)
            {
                t = i;
            }
            else
            {
                t = Random.Range(0, listAttack.Count /*- 1*/);
            }
            instance = Instantiate(listAttack[t]);
            instance.gameObject.SetActive(false);
            AttackPool.Add(instance);
        }
    }
    GameObject GetPooledObject()
    {
        int i = Random.Range(0, AttackPool.Count - 1);
        if (!AttackPool[i].activeInHierarchy)
        {
            return AttackPool[i];
        }
        return null;
    }
    //IEnumerator FireContinue()
    //{
    //    while (true)
    //    {
    //        GameObject instance;
    //        instance = GetPooledObject();
    //        if (instance != null)
    //        {
    //            instance.SetActive(true);
    //        }

    //        yield return new WaitForSeconds(spawnRate);
    //    }
    //}
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attckRate);
            animator.SetBool("IsAttack", true);
            //count = Random.Range(i, listAttack.Count);
            //listAttack[count].SetActive(true);
            //listAttack[count].GetComponent<Attack>().Fire();
            GameObject instance;
            instance = GetPooledObject();
            if (instance != null)
            {
                instance.SetActive(true);
                if(instance.GetComponent<Attack>() != null)
                {
                    instance.GetComponent<Attack>().Fire();
                }
                else
                {
                    instance.GetComponent<GroundMines>().Fire();
                }
            }
            yield return new WaitForSeconds(attckDuration);
            animator.SetBool("IsAttack", false);
        }
    }
    void Update()
    {
        fasterRate -= Time.deltaTime;
        FasterAttack();
    }

    private void FasterAttack()
    {
        if (hp.GetHp() <= 500 || fasterRate <= 30)
        {
            if ((hp.GetHp() >= 250 || fasterRate > 0) && i == 0)
            {
                attckRate = 1f;
                attckDuration = 1f;
                i++;
            }
            if ((hp.GetHp() <= 250 || fasterRate <= 0) && i == 1)
            {
                attckRate = 0.5f;
                attckDuration = 0.5f;
                i++;
            }
        }
    }
}
