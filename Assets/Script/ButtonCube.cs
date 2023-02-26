using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCube : MonoBehaviour
{
    private bool CanClick;
    public GameObject A;
    public Animator anim;
    private bool once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0.1f && CanClick)
        {
            anim.SetBool("Activate", true);
            if (!once)
            {
                FindObjectOfType<AudioManager>().Play("Bouton");
                once = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            A.SetActive(true);
            CanClick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        A.SetActive(false);
        CanClick = false;
    }
}
