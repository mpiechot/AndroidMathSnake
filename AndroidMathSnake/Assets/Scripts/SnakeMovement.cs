using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public float speed { get; set; }
    public float rotationSpeed { get; set; }

    private bool leftClicked = false;
    private bool rightClicked = false;

    private static float horizontal;

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
        //horizontal = Input.GetAxis("Horizontal");
 
        if(!(leftClicked ^ rightClicked))
        {
            horizontal = 0;
            return;
        }
        if (leftClicked)
        {
            horizontal = -1;
        }
        if (rightClicked)
        {
            horizontal = 1;
        }
    }

    void Move()
    {
        if(horizontal != 0)
        {
            transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    public void moveLeftDown()
    {
        Debug.Log("Left Down called!");
        leftClicked = true;
    }
    public void moveLeftUp()
    {
        Debug.Log("Left Up called!");
        leftClicked = false;
    }
    public void moveRightDown()
    {
        rightClicked = true;
    }
    public void moveRighUp()
    {
        rightClicked = false;
    }
}
