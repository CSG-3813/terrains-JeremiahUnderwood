using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    private Rigidbody rb;
    public float rollforce = 200;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        Invoke("bigRoll", 3.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bigRoll()
    {
        rb.AddForce(new Vector3(Mathf.Cos(Random.Range(0f, 2f * Mathf.PI)) * rollforce, 0, Mathf.Sin(Random.Range(0f, 2f * Mathf.PI)) * rollforce), ForceMode.Force);
        Invoke("bigRoll", 3.3f);
    }
}
