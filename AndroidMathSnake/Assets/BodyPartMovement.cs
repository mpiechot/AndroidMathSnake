using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartMovement : MonoBehaviour {

    public Transform target { get; set; }
    public float speed { get; set; }
    public float minDistance { get; set; }
    public TextMesh text { get; set; }

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitSomeTime());

        rb = GetComponent<Rigidbody>();
        text = GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(target == null)
        {
            //Debug.LogError("Target is null!");
            return;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > minDistance)
        {
           // rb.velocity = (target.position - transform.position) * speed * distance;
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            transform.LookAt(target);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
	}

    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(1f);

        Debug.Log("Enabled!");
        GetComponent<SphereCollider>().enabled = true;
    }
}
