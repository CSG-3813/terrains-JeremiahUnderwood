using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    private Rigidbody rb;
    private Collider cl;
    public float rollforce = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cl = this.GetComponent<Collider>();
        Invoke("bigRoll", 3.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rb.velocity), 360f * Time.deltaTime);
    }

    public void bigRoll()
    {
        Vector3 randomdir = new Vector3(Mathf.Cos(Random.Range(0f, 2f * Mathf.PI)), 0, Mathf.Sin(Random.Range(0f, 2f * Mathf.PI)));
        rb.AddForce(randomdir * rollforce, ForceMode.Force);
        Invoke("bigRoll", 3.3f);
    }
}
