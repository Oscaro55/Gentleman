using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_track : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(35, Camera.main.transform.rotation.eulerAngles.y, 0);
    }
}
