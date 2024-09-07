using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    //public UnityEvent onFinish;
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finish");
        playerController.gameObject.SetActive(false);
    }
}
