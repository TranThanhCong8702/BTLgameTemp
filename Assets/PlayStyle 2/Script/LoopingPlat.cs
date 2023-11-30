using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingPlat : MonoBehaviour
{
    [SerializeField] float LoopSpeed = 5f;
    [SerializeField] Renderer ren;
    [SerializeField] Material mat;
    //[SerializeField] GameObject Boss;
    Meteor met;
    int count = 0;
    private void Findmet()
    {
        //if(count == 0)
        //{
            met = FindObjectOfType<Meteor>();
        //}

    }
    // Update is called once per frame
    void Update()
    {
        Findmet();
        if (met != null && count == 0)
        {
            if (met.getBool())
            {
                change();
                count++;
            }
        }
    }
    private void LateUpdate()
    {
        ren.material.mainTextureOffset += new Vector2(LoopSpeed * Time.deltaTime, 0f);
    }
    void change()
    {
        ren.material = mat;
    }
}
