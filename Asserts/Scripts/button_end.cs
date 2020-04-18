using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class button_end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toHone()
    {
        SceneManager.LoadScene("Scene1");//홈으로
    }
    public void goBack()
    {
        File.Delete("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime2.csv");
        File.Delete("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime2.csv.meta");
        File.Delete("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\correctPassword.txt");
        File.Delete("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\correctPassword.txt.meta");

        SceneManager.LoadScene("Scene3-2");//인증-비번입력부터
        
    }
}
