using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject Whale;
    public GameObject text;
    public bool funny;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        funny = (player.position - transform.position).magnitude < 20f;
        Debug.Log("gottem");
        if ((player.position - transform.position).magnitude < 20f) {
            text.SetActive(true);
            if (Input.GetKey("e"))
            {
                Whale.SetActive(true);
                text.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
        else text.SetActive(false);
    }
}
