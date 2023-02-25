using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public BoxCollider box;
    public GameObject EcranDeFin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EcranDeFin.SetActive(true);
        }
    }
}
