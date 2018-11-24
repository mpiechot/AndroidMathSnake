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

        rot -= rotTimer;
        rotBar.fillAmount = rot;
        if (rot < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        gm.startAppleDestroy(transform);
    }
}
