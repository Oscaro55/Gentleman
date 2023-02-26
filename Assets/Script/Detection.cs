using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public LightStates state;
    // Start is called before the first frame update
    void Start()
    {
        state = GameObject.Find("States").GetComponent<LightStates>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) state.Detected = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) state.Detected = false;
    }
}
