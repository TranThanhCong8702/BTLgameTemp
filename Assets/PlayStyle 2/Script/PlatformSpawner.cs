using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPOS;
    [SerializeField] Transform spawnNEG;
    [SerializeField] Transform Holder;
    [SerializeField] List<GameObject> plat = new List<GameObject>();
    [SerializeField] float fixPos=0;
    [SerializeField] float spawnRate=1f;
    [SerializeField] bool startSpawn = false;

    void Start()
    {
        //Vector2 pos = new Vector2(spawnPOS.position.x - fixPos, spawnPOS.position.y);
        //Instantiate(spawnNEG, pos, Quaternion.identity);
        Spawnning();
    }
    private void Spawnning()
    {
        StartCoroutine(Spawn());

    }
    IEnumerator Spawn()
    {
        while (true)
        {
            if (startSpawn)
            {
                Vector2 pos = new Vector2(spawnPOS.position.x - fixPos, spawnPOS.position.y);
                GameObject temp = Instantiate(plat[0], pos, Quaternion.identity, Holder);
                yield return new WaitForSeconds(spawnRate);
            }
            else
            {
                yield return new WaitForSeconds(0);
            }
            //startSpawn = false;
        }
    }
    void Update()
    {
        //Spawnning();
    }
}
