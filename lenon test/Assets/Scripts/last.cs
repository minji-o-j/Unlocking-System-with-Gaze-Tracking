using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class last : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void recon()
	{
		SceneManager.LoadScene("Scene3");
	}

	public void home()
	{
		SceneManager.LoadScene("Scene1");
	}
}
