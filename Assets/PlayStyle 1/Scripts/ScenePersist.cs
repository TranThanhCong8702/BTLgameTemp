using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake()
    {
        int numOfSession = FindObjectsOfType<ScenePersist>().Length;
        if (numOfSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetscenePersist()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
