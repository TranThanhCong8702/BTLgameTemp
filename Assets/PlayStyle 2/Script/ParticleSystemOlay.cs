using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemOlay : MonoBehaviour
{
    ParticleSystem particle;
    public void ParticlePlay()
    {
        particle.Play();
    }
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
}
