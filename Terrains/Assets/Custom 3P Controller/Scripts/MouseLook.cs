using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
	Vector3 rotation = Vector3.zero;
	public float speed = 3;
	public Transform bodyTrans;

    private void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
	{
		rotation.y += Input.GetAxis("Mouse X") * speed;
		if (Math.Abs(rotation.x + -Input.GetAxis("Mouse Y") * speed) < 90f)
		{
			rotation.x += -Input.GetAxis("Mouse Y") * speed;
		}
        else
        {
			if ((rotation.x + -Input.GetAxis("Mouse Y")) > 0) rotation.x = 90;
			else rotation.x = -90;
		}
	}
    private void LateUpdate()
    {
		transform.eulerAngles = new Vector3(rotation.x, rotation.y, 0) ;
		bodyTrans.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
	}
}