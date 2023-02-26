using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_track : MonoBehaviour
{
    public bool eyeOrExcla;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!eyeOrExcla) transform.rotation = Quaternion.Euler(-35, Camera.main.transform.rotation.eulerAngles.y, 0);
        else transform.rotation = Quaternion.Euler(35, Camera.main.transform.rotation.eulerAngles.y, 0);
    }
}
