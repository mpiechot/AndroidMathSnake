using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour {
	public GameObject sceneWorld;
	public GameObject plane = null;
	private int actualParticle = 0;
	public List<GameObject> particles = new List<GameObject> ();
	private GameObject particle = null;

	public bool GUI_ON = true;

	// Use this for initialization
	void Start () {
		createParticle ();
	}

	private bool isChange = false;
	private string[] particleNames = {
		"EFFECT FOR BUTTERFLY",
		"EGG EXPLODE",
		"PICK UP EFFECT",
		"HIT",
		"SMOKE - 1",
		"SMOKE - 2",
		"TRUCK SMOKE",
		"WALL CRUSH"
	};

	void OnGUI()
	{
		if (!GUI_ON)
			return;

		GUIStyle st = new GUIStyle ();
		st.fontSize = 30;
		st.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect(Screen.width * 0.4f, 50, 150, 30), particleNames[actualParticle], st);

		if (GUI.Button(new Rect(10, 175, 150, 30), "PREV") && !isChange)
		{
			actualParticle--;
			if (actualParticle < 0)
				actualParticle = particles.Count - 1;
			createParticle ();
		}

		if (GUI.Button(new Rect(Screen.width-160, 175, 150, 30), "NEXT")&& !isChange)
		{
			actualParticle++;
			if (actualParticle >= particles.Count)
				actualParticle = 0;
			createParticle ();
		}

	}

	private void createParticle()
	{
		isChange = true;
		StartCoroutine (_createParticle ());
	}

	IEnumerator _createParticle()
	{
		if (particle != null)
			GameObject.Destroy (particle);
		
		yield return null;

		particle = GameObject.Instantiate(particles[actualParticle]);
		particle.transform.parent = sceneWorld.transform;
		particle.transform.localPosition = new Vector3(0,0,0);

		ParticleSystem[] emitters= particle.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < emitters.Length; i++) 
		{
			ParticleSystem.MainModule m = emitters [i].main;
			m.loop = true;

			ParticleSystem.CollisionModule cm = emitters [i].collision; 
			if(cm.enabled)
				cm.SetPlane(0, plane.transform);
		}

		yield return null;
		isChange = false;
	}
}
