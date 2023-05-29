using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pspsps : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce=10.0f;
    public bool bJump = false;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(hAxis,0,vAxis).normalized;
        body.velocity = inputDir * moveSpeed;
        transform.LookAt(transform.position + inputDir);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !bJump)
        {
            
            
                Rigidbody body = this.gameObject.GetComponent<Rigidbody>();
                body.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);

                bJump = true;
            
          
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            bJump = false;
        }
    }


}
