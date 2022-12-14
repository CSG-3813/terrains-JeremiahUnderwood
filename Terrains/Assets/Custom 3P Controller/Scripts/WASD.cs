using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public Camera cam;
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    private float horiMov = 0;
    private float vertMov = 0;
    private bool isGrounded = false;
    public Transform foot;
    public Transform arm;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        bool tempGrounded = false;
        //Ray ray = new Ray(i.position, new Vector3(0, -1, 0));
        //if (Physics.Raycast(foot.position, Vector3.down, out hit, 1f, 1 << 10))// transform.rotation, 1f, 1 << 10))
        if (Physics.BoxCast(transform.position, transform.lossyScale/2.4f, Vector3.down, out hit, transform.rotation, 1.1f, 1 << 10))
        {
            tempGrounded = true;
        }
        
        isGrounded = tempGrounded;


        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            isGrounded = false;
        }
        vertMov = 0;
        horiMov = 0;
        if (Input.GetKey("w"))
        {
            vertMov += 1;
        }
        if (Input.GetKey("s"))
        {
            vertMov -= 1;
        }
        if (Input.GetKey("a"))
        {
            horiMov += 1;
        }
        if (Input.GetKey("d"))
        {
            horiMov -= 1;
        }

        float raycastDist = 1.5f;
        if (vertMov == 0 || horiMov == 0) raycastDist = 1.1f;

        bool armCheck = Physics.Raycast(arm.position, transform.forward * vertMov + transform.right * -horiMov, raycastDist, 1 << 10);

        Vector3 camRotation = transform.localEulerAngles;
        if (!armCheck)
        {
            rb.velocity = new Vector3((vertMov * speed * Mathf.Sin(camRotation.y * (Mathf.PI / 180))), rb.velocity.y, (vertMov * speed * Mathf.Cos(camRotation.y * (Mathf.PI / 180))));
            rb.velocity += new Vector3((horiMov * speed * -Mathf.Cos(camRotation.y * (Mathf.PI / 180))), 0, (horiMov * speed * Mathf.Sin(camRotation.y * (Mathf.PI / 180))));
        }
        if (isGrounded && !armCheck && rb.velocity.y > speed/2) rb.velocity = new Vector3(rb.velocity.x, speed/2, rb.velocity.z);
    }

}
