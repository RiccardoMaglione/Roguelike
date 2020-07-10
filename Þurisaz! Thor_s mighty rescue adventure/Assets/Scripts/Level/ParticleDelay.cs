using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDelay : MonoBehaviour
{
    ParticleSystem particle;

    void StartTimerDelay()
    {
        float rand = Random.Range(0f, 1f);
        var main = particle.main;
        main.startDelay = rand;
    }

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Start()
    {
        StartTimerDelay();
    }
}
