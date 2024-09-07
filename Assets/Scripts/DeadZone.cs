using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadZone : MonoBehaviour
{
    public UnityEvent OnEnterDeadZone;

    private void OnTriggerEnter(Collider other)
    {
        OnEnterDeadZone.Invoke();
    }
}