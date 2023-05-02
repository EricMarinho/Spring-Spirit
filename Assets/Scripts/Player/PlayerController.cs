using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Rigidbody rigidbodyRb;
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 15f;
    [SerializeField] float flySpeed = 15f;

    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        rigidbodyRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbodyRb.transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rigidbodyRb.transform.Translate(Vector3.down * flySpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }

        else
        {
            currentSpeed = walkSpeed;
        }


        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        rigidbodyRb.transform.Translate(Vector3.forward * vertical * Time.deltaTime * currentSpeed);
        rigidbodyRb.transform.Translate(Vector3.right * horizontal * Time.deltaTime * currentSpeed);

        float mouseX = Input.GetAxis("Mouse X");

        rigidbodyRb.transform.Rotate(Vector3.up * mouseX * Time.deltaTime * 120);

    }

    private void OnCollisionExit(Collision collision)
    {;
        runSpeed *= 2;
        flySpeed *= 2;
        if(rigidbodyRb != null)
        {
            rigidbodyRb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        runSpeed /= 2;
        flySpeed /= 2;
    }

}
