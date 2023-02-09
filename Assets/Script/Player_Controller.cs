using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Vector3 _input;
    public Rigidbody rb;
    public float _Speed;
    public float _RotaSpeed;
    public bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        GatherInputs();
        Look();
        GroundDetection();
    }

    void GatherInputs()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _Speed * Time.deltaTime);
    }

    void Look()
    {
        if (_input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));

            var SkewedInput = matrix.MultiplyPoint3x4(_input);

            var relative = (transform.position + SkewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _RotaSpeed * Time.deltaTime);
        }
    }

    void GroundDetection()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, 0.9f, 0), Vector3.down, 0.3f))
        {
            Grounded = true;
        }
        else Grounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position - new Vector3(0, 0.9f, 0), Vector3.down *0.3f);
    }

}
