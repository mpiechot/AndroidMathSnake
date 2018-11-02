using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 2f;


	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("hit: " + col.name);
    }
}
