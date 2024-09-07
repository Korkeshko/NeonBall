using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private DeadZone deadZone;
    [SerializeField] private StarCollection starCollection;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        deadZone.OnEnterDeadZone.AddListener(Respawn);
    }

    private void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.transform.position = respawnPoint.position;  
        starCollection.DecreaseScore();
    }
}
