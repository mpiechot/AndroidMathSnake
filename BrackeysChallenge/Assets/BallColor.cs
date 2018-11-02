using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour {

    public MeshRenderer renderer;

    // Use this for initialization
    void Start()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        renderer.material.color = newColor;
    }

    // Update is called once per frame
    void Update () {
		if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
	}
}
