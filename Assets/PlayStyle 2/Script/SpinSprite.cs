using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSprite : MonoBehaviour
{
    [SerializeField] float SpinAm;
    private void Spinning()
    {
        transform.Rotate(0, 0, SpinAm * Time.deltaTime);
    }
    void Start()
    {
        Spinning();
    }


    void Update()
    {
        Spinning();
    }
}
