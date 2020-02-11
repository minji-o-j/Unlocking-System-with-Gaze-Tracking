using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class scene2_text : MonoBehaviour
{
    public GameObject Left_Up;
    public GameObject Right_Down;
    public Text mytext;
    bool state = true;
    float fTime = 0f;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {//fTime없애고 다 텍스트 읽기로 고치기 - 완료
        mytext.GetComponent<Text>().text = "왼쪽 위 레몬을 바라봐주세요";
        if (state == true)
        {
            using (StreamWriter outputFile = new StreamWriter("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\start.txt", true))
            {
                outputFile.WriteLine("1");
                state = false;
            }
            Debug.Log(state);
            Debug.Log("Finish make start1");
        }

        Left_Up.SetActive(true);
        //string cal2 = File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\startcali2.txt");
        //if (cal2 == "1")
        //{
        //    Left_Up.SetActive(false);
        //    mytext.GetComponent<Text>().text = "오른쪽 아래 레몬을 바라봐주세요";
        //    Right_Down.SetActive(true);
        //}
        if (File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\startcali2.txt") == "1")
        {
            Left_Up.SetActive(false);
            mytext.GetComponent<Text>().text = "오른쪽 아래 레몬을 바라봐주세요";
            Right_Down.SetActive(true);
        }
        if (File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\startnextScene.txt") == "1")
        {
            Right_Down.SetActive(false);
            mytext.GetComponent<Text>().text = "";
            fTime += Time.deltaTime;
        }
        if (fTime >= 1)
        {
            SceneManager.LoadScene("Scene2-1");
        }
    }
}