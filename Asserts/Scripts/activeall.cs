using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class activeall : MonoBehaviour {

	float fTime=0f;

	public GameObject _1;
	public GameObject _2;
	public GameObject _3;
	public GameObject _4;
	public GameObject _5;
	public GameObject _6;
	public GameObject _7;
	public GameObject Text;
    


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        if (fTime >= 2)
        {
            Text.SetActive(false);
            _1.SetActive(true);
            _2.SetActive(true);
            _3.SetActive(true);
            _4.SetActive(true);
            _5.SetActive(true);
            _6.SetActive(true);
            _7.SetActive(true);

        //    SceneManager.LoadScene("Scene2-2");
        }
        string file = @"C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\password.txt";
        if (File.Exists(file))
        {
            SceneManager.LoadScene("Scene2-2");
        }
    }
}
