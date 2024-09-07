using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Star : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    
    public UnityEvent OnStarCollected;
    
    private void OnTriggerEnter(Collider other)
    {
        OnStarCollected.Invoke();
        PlayEffect();
        Destroy(gameObject);
    }

    private void PlayEffect()
    {
        particle.transform.SetParent(null);
        particle.Play();
        Destroy(particle.gameObject, particle.main.duration);
    }
}