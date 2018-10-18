using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public float speed = 1f;
    public float rotationSpeed = 50f;

    private float horizontal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetInput();
	}

    void FixedUpdate()
    {
        Move();
    }

    void GetInput()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        if(horizontal != 0)
        {
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
