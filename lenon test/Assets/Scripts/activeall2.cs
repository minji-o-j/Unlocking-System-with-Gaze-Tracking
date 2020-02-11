using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class activeall2 : MonoBehaviour
{

    float fTime = 0f;

    public GameObject _1;
    public GameObject _2;
    public GameObject _3;
    public GameObject _4;
    public GameObject _5;
    public GameObject _6;
    public GameObject _7;

    public GameObject l1, l2, l3, l4, l5;
    public GameObject c1, c2, c3, c4, c5;

    //public GameObject _1_;
    //public GameObject _2_;
    //public GameObject _3_;
    //public GameObject _4_;
    //public GameObject _5_;
    //public GameObject _6_;
    //public GameObject _7_;
    public Text mytext;
    public GameObject button1;
    public GameObject button2;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        fTime += Time.deltaTime;
        if (fTime >= 2)
        {
            mytext.GetComponent<Text>().text = "패턴을 인증해주세요";
            //Text.SetActive(false);
            _1.SetActive(true);
            _2.SetActive(true);
            _3.SetActive(true);
            _4.SetActive(true);
            _5.SetActive(true);
            _6.SetActive(true);
            _7.SetActive(true);
            l1.SetActive(true);
            l2.SetActive(true);
            l3.SetActive(true);
            l4.SetActive(true);
            l5.SetActive(true); 

            //    SceneManager.LoadScene("Scene2-2");
        }
        string file = @"C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\correctPassword.txt";
        if (File.Exists(file))
        {
            if("1"==File.ReadAllText(@"C:\Users\minji\Desktop\unity_practice\lenon test\Assets\Resources\correctPassword.txt"))
            {
                _1.SetActive(false);
                _2.SetActive(false);
                _3.SetActive(false);
                _4.SetActive(false);
                _5.SetActive(false);
                _6.SetActive(false);
                _7.SetActive(false);

                l1.SetActive(false);
                l2.SetActive(false);
                l3.SetActive(false);
                l4.SetActive(false);
                l5.SetActive(false);

                c1.SetActive(false);
                c2.SetActive(false);
                c3.SetActive(false);
                c4.SetActive(false);
                c5.SetActive(false);

                //_1_.SetActive(false);
                //_2_.SetActive(false);
                //_3_.SetActive(false);
                //_4_.SetActive(false);
                //_5_.SetActive(false);
                //_6_.SetActive(false);
                //_7_.SetActive(false);
                mytext.GetComponent<Text>().text = "인증에 성공하였습니다.";
                button1.SetActive(true);//홈으로  
                button2.SetActive(true);//다시하기
                
            }
            else if("0"== File.ReadAllText(@"C:\Users\minji\Desktop\unity_practice\lenon test\Assets\Resources\correctPassword.txt"))
            {
                _1.SetActive(false);
                _2.SetActive(false);
                _3.SetActive(false);
                _4.SetActive(false);
                _5.SetActive(false);
                _6.SetActive(false);
                _7.SetActive(false);

                l1.SetActive(false);
                l2.SetActive(false);
                l3.SetActive(false);
                l4.SetActive(false);
                l5.SetActive(false);

                c1.SetActive(false);
                c2.SetActive(false);
                c3.SetActive(false);
                c4.SetActive(false);
                c5.SetActive(false);

                //_1_.SetActive(false);
                //_2_.SetActive(false);
                //_3_.SetActive(false);
                //_4_.SetActive(false);
                //_5_.SetActive(false);
                //_6_.SetActive(false);
                //_7_.SetActive(false);
                mytext.GetComponent<Text>().text = "인증에 실패하였습니다.";
                button1.SetActive(true);//홈으로
                button2.SetActive(true);//다시하기
            }
        }

        
    }
}
