using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Windows : MonoBehaviour
{
    public Player_Controller1 _player;
    //public GameObject PressA;
    //public Transform _snapPoint;
    //public Vector3 _lookAtPoint;
    public Transform _FinalJumpStatePoint;

    float _startTime;
    float _journeyLength;
    // Start is called before the first frame update
    void Start()
    {
        //_startTime = Time.time;
        //_journeyLength = Vector3.Distance(_snapPoint.position, _FinalJumpStatePoint.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //PressA.SetActive(true);
            _player.transform.position = _FinalJumpStatePoint.transform.position;

            /*if (Input.GetAxis("Fire1") > 0)
            {
                _player.transform.position = _snapPoint.transform.position;
                _player.transform.LookAt(_lookAtPoint);


            }*/
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //PressA.SetActive(false);
        }

    }
}
