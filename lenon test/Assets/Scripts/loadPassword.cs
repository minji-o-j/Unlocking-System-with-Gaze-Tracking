using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class loadPassword : MonoBehaviour
{
    public Text n1;
    public Text n2;
    public Text n3;
    public Text n4;
    public Text n5;
    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {
        string password = File.ReadAllText("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\password.txt");
        char[] password_arr = password.ToCharArray();
        n1.GetComponent<Text>().text = password_arr[0].ToString();
        n2.GetComponent<Text>().text = password_arr[1].ToString();
        n3.GetComponent<Text>().text = password_arr[2].ToString();
        if (password_arr[3] != 0)
        {
            n4.GetComponent<Text>().text = password_arr[3].ToString();
        }
        else n4.GetComponent<Text>().text = "";
        if (password_arr[4] != 0)
        {
            n5.GetComponent<Text>().text = password_arr[4].ToString();
        }
        else n5.GetComponent<Text>().text = "";
    }
}