using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


public class filesharetest : MonoBehaviour
{
    public GameObject ojLeft;
    public float damp;
    int cnt_l;
    int portion;        //몫
    //Quaternion newRotation= Quaternion.Euler((float)3.836,(float)164.928,0);

    //=======================================================================================================================
    // Update is called once per frame
    void Update()
    {
        readCSV_l();
        //cnt_l++;
    }

    //=======================================================================================================================

    void readCSV_l()
    {
        //string filename = "C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\testleft.csv";
        //string str = string.Empty;
        FileStream file = new FileStream("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\testleft.csv", FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
        StreamReader sr = new StreamReader(file);

        string data = sr.ReadToEnd();

        string[] records = data.Split('\n');

        portion = cnt_l / (records.Length - 2);
        if (portion == 0)
        {
            //for (int i = 1; i <  1000; i++)    //include index, 10-->records.Length: 11           i:시간과 비슷
            //{
                //Debug.Log("end: " + records[records.Length-2]); //

                string[] fields = records[cnt_l % (records.Length - 2) + 1].Split(',');
                //string[] fields = records[i].Split(',');
                //Quaternion newRotation = Quaternion.Euler(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));
                //Debug.Log("new:"+ newRotation);
                //  Debug.Log("t2:   " + Quaternion.Euler(newRotation)); 

               // Debug.Log("test_transform:" +transform.rotation);
                //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 1);

                //transform.localEulerAngles = new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));

                //Debug.Log("length: " + records.Length); //

                //----------------------------------------------------------------------------------------------------------------
                //Delay


                //----------------------------------------------------------------------------------------------------------------
                //test
                //Debug.Log("test1:  " + fields[0] + "test2:  " + fields[1] + "test3:  " + fields[2]);
                Debug.Log("test1:  " + fields[3] + "test2:  " + fields[4] + "test3:  " + fields[5]);
                //Debug.Log("testNull: " + fields.Length);    //6-->0 to 5
                //----------------------------------------------------------------------------------------------------------------
                //Rotate

                //transform.rotation
                
                transform.localEulerAngles = new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));
                //----------------------------------------------------------------------------------------------------------------
                //Transform
                //    transform.position = new Vector3(float.Parse(fields[0]), float.Parse(fields[1]), float.Parse(fields[2]));

               // }
            //for문 끝
            cnt_l++;
        }
        //조건문 끝
        else  //몫이 1이 아님(한번 반복 후 더이상 값이 없는 상태)
        {
            Debug.Log("동공이 인식되지 않습니다!");
            portion = cnt_l / (records.Length - 2);
        }

    }

}

