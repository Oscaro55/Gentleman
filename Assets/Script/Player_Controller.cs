using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Vector3 _input;
    public Rigidbody rb;
    public float _Speed;
    public float _RotaSpeed;
    private bool _Grounded;
    public Animator anim;
    public bool _detected;
    private float _detection;
    private bool _dead;
    public Material mat;
    public float _DetectionRate;
    public GameObject eye;
    public GameObject exclamation;
    private bool once;
    public Transform respawn;
    public Animator fade;
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
        if (!_dead)
        {
            Move();

            GatherInputs();

            Look();

            GroundDetection();

            if (_input.magnitude > 0.35f)
            {
                anim.SetBool("Walking", true);
                anim.speed = _input.magnitude -0.1f ;
            }
            else anim.SetBool("Walking", false);

            Detection();

            if (_detection <=0) eye.SetActive(false);
        }
        if (_dead)
        {
            Death();
        }
    }

    void GatherInputs()
    {
         _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Move()
    {
        if (_input.magnitude > 0.35f) rb.MovePosition(transform.position + (transform.forward * _input.magnitude) * _Speed * Time.deltaTime);
    }

    void Look()
    {
        if (_input.magnitude > 0.35f)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

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
            _Grounded = true;
        }
        else _Grounded = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position - new Vector3(0, 0.9f, 0), Vector3.down * 0.3f);
    }

    public void Detection()
    {
        if (_detected)
        {
            if (_detection < 1) _detection += Time.fixedDeltaTime * _DetectionRate;
            mat.SetFloat("Vector1_1c216f01fd9943e3b33153be3734fd4d", _detection);
            eye.SetActive(true);
        }

        if (!_detected)
        {
            if (_detection > 0) _detection -= Time.fixedDeltaTime/4;
            mat.SetFloat("Vector1_1c216f01fd9943e3b33153be3734fd4d", _detection);
        }

        if (_detection >= 1)
        {
            _dead = true;
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(2f);
        transform.position = respawn.position;
        once = false;
        _dead = false;
        _detection = 0;
        exclamation.SetActive(false);
    }

    public void Detected()
    {
        _detected = true;
    }

    public void UnDetected()
    {
        _detected = false;
    }

    void Death()
    {
        anim.SetBool("Walking", false);
        eye.SetActive(false);
        exclamation.SetActive(true);

        if (!once)
        {
            StartCoroutine(DeathDelay());
            fade.SetTrigger("Death");
        }
        once = true;
    }
}
