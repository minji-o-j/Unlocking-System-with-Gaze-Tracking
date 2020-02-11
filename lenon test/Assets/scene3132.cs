using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene3132 : MonoBehaviour
{
    public GameObject Left_Up;
    public GameObject Right_Down;
    public Text mytext;
    bool state = true;
    float fTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mytext.GetComponent<Text>().text = "왼쪽 위 레몬을 바라봐주세요";
        if (state == true)
        {
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1.txt", true))
            {
                outputFile.WriteLine("1");
                state = false;
            }
            Debug.Log(state);
            Debug.Log("Finish make start1");
        }
        Left_Up.SetActive(true);
        if (File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1-startcali2.txt") == "1") 
        {
            Left_Up.SetActive(false);
            mytext.GetComponent<Text>().text = "오른쪽 아래 레몬을 바라봐주세요";
            Right_Down.SetActive(true);
        }
        if (File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-1-tonextScene.txt") == "1")
        {
            Right_Down.SetActive(false);
            mytext.GetComponent<Text>().text = "";
            fTime += Time.deltaTime;
        }
        if (fTime >= 1)
        {
            SceneManager.LoadScene("Scene3-2");
        }
    }
}
