using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour {

    public int num { get; set; }
    public GameObject system;
    public MeshRenderer apple;
    private GameMaster gm;
    public float rotTimer;
    public float spawnSize = 2;
    private float rot;
    private Color freshColor = new Color(255,255,255);
    private Color deadColor = new Color(0, 255, 172);

    [Header("Unity Stuff")]
    public Image rotBar;
    public Canvas can;

    // Use this for initialization
    void Start () {
        gm = GameMaster.gm;
        rotTimer = gm.currentRotTime;
        if(rotTimer > 0)
        {
            Debug.Log("Enable Rot!!");
            can.enabled = true;
            can.gameObject.SetActive(true);
        }

        rot = 1f;
        Debug.Log("RotTime: " + rotTimer);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(Map(transform.position.y, 10, 0.6f, spawnSize, 1.5f), transform.localScale.y, Map(transform.position.y, 10, 0.6f, spawnSize, 1.5f));

        rot -= rotTimer;
        rotBar.fillAmount = rot;
        if(rot > 0.66f)
        {
            rotBar.color = Color.green;

        }
        else if(rot > 0.33f)
        {
            rotBar.color = new Color(255, 240, 0);
        }
        else
        {
            rotBar.color = Color.red;
        }
        if (rot < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        gm.startAppleDestroy(transform);
    }

    private float Map(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
