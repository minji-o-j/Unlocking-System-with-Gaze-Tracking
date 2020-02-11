using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

//==========================================================================================================
public class certificate : MonoBehaviour
{

    float x1, x2, y1, y2;
    float[,] nineAxis = new float[9, 2];
    float[,] eyeAxis = { { (float)3.836, (float)164.928, 0, (float)-29.072, (float)-14.092, 0 },{ (float)-8.614, (float)161.133, 0, (float)-10.016, (float)-18.795, 0 },
        {(float)-25.344,(float)164.557,0,(float)3.783,(float)-13.877,0 },{(float)3.972,(float)179.993,0,(float)-29.164,(float)-0.007,0 },
        {(float)-7.274,(float)179.993,0,(float)-9.145,(float)-0.007,0 },{ (float)-27.85,(float)175.234,0,(float)4.312,(float)-4.332,0},
        { (float)-0.373,(float)192.871,0,(float)-23.413,(float)14.943,0},{(float)-7.706,(float)197.365,0,(float)-12.539,(float)19.679,0 },
        { (float)-26.831,(float)194.006,0,(float)3.065,(float)11.676,0} };

    bool state1 = true;
    int portion;
    int cnt1;
    int[] password = { 0, 0, 0, 0, 0 };
    int pass_num = 0;
    int count_1, count_2, count_3, count_4, count_5_8, count_6, count_7, count_9 = 0;
    public GameObject ob;
    float xpos1, xpos2, ypos1, ypos2;//영역 나누는 기준이 되는 네 점
    int c1, c2, c3, c4, c5, c6, c7, c8, c9 = 0;
    //public GameObject off1, off2, off3, off4, off6, off7, off9;
    //public GameObject on1, on2, on3, on4, on6, on7, on9;
    public GameObject leftEye;
    public GameObject rightEye;
    //int countAllLength;     //
    int countRealLength;    //실제 배열의 길이 저장(0 제외)
    int countZero;          //0의 개수 저장
    string readPW;
    char []password_arr;
    int count = 0;          //길이 저장
    public GameObject pc1, pc2, pc3, pc4, pc5;//password circle
    //==========================================================================================================
    // Start is called before the first frame update
    void Start()
    {
        while (state1 == true)
        {
            makeAxis();      //x1,x2,y1,y2값이 들어감
        }
        makeNine();         //9x2 배열이 생김, 1~9 점의 x,y좌표가 들어있음
    }
    //==========================================================================================================
    // Update is called once per frame
    void Update()
    {
        if (File.Exists("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime2.csv"))
        {
            if (File.Exists(@"C:\Users\minji\Desktop\unity_practice\lenon test\Assets\Resources\password.txt"))
            {
                readPW = File.ReadAllText(@"C:\Users\minji\Desktop\unity_practice\lenon test\Assets\Resources\password.txt");
                password_arr = readPW.ToCharArray();
                //System.Text.RegularExpressions.Regex cntStr = new System.Text.RegularExpressions.Regex("Count");
                //returnStr = int.Parse(cntStr.Matches(insertStr, 0).Count.ToString());
                countZero = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (password_arr[i] == '0')
                    {
                        countZero++;
                    }
                    //Debug.Log("countZero:  " + countZero);
                }
                //Debug.Log("countZero2  :  " + countZero);

                if (pass_num < 5 - countZero)
                {
                    makeEyeExcel();
                    makeCircles();
                }
                else
                {
                    checkPass();
                }
            }
            else
            {
                Debug.Log("password file is not exist. Please enroll your password!");
            }
        }
        
    }
    //==========================================================================================================
    void checkPass()
    {
        //Debug.Log("input readPW: " + readPW[0].ToString() + readPW[1].ToString() + readPW[2].ToString() + readPW[3].ToString() + readPW[4].ToString());
        Debug.Log("0  " + Convert.ToInt32(password_arr[0]));
        Debug.Log("1  " + password[1]);
        Debug.Log("2  " + password[2]);
        Debug.Log("3  " + password[3]);
        Debug.Log("4  " + password[4]);

        if (password[0]== Convert.ToInt32(password_arr[0])-48&password[1] == Convert.ToInt32(password_arr[1])-48&& password[2] == Convert.ToInt32(password_arr[2])-48&&password[3] == Convert.ToInt32(password_arr[3])-48&& password[4] == Convert.ToInt32(password_arr[4])-48)
        {
            string savePath = @"C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\correctPassword.txt";
            string textValue = "1";
            File.WriteAllText(savePath, textValue);
        }
        else
        {
            string savePath = @"C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\correctPassword.txt";
            string textValue = "0";
            File.WriteAllText(savePath, textValue);
        }
    }
    //==========================================================================================================
    void makeEyeExcel()
    {
        FileStream realTimeAxis = new FileStream("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\realTime2.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        StreamReader sr = new StreamReader(realTimeAxis);
        string realTimeData = sr.ReadToEnd();
        string[] records = realTimeData.Split('\n');

        portion = cnt1 / (records.Length - 1);      //records.Length가 아마 엔터가 쳐진 행까지 +1개일거임 그래서 -1했음
                                                    // Debug.Log("right"+records.Length);
        if (portion == 0)
        {
            string[] fields = records[cnt1 % (records.Length - 1) + 1].Split(',');
            //Debug.Log("fields test" + fields.Length);


            Debug.Log("xpos1:  " + xpos1 + "xpos2:  " + xpos2 + "ypos1:  " + ypos1 + "ypos2   " + ypos2);

            if ((float.Parse(fields[0])) < xpos1 && float.Parse(fields[1]) < ypos1)//cnt는 일단 그냥 놔둠. 아마 맞을듯? 첫번째 영역안에 들어오면
            {
                Debug.Log("r1");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[0, 0], eyeAxis[0, 1], eyeAxis[0, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[0, 3], eyeAxis[0, 4], eyeAxis[0, 5]);
                count_2 = 0; count_3 = 0; count_4 = 0; count_5_8 = 0; count_6 = 0; count_7 = 0; count_9 = 0;
                count_1++;
                if (count_1 == 18 && c1 == 1)
                {
                    Debug.Log("number 1 already exists!!");
                }
                else if (count_1 == 18)
                {
                    //off1.SetActive(false);
                    //on1.SetActive(true);
                    count++;
                    password[pass_num] = 1;
                    c1 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) >= xpos1 && float.Parse(fields[0]) <= xpos2 && float.Parse(fields[1]) < ypos1)//2번영역
            {
                Debug.Log("r2");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[1, 0], eyeAxis[1, 1], eyeAxis[1, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[1, 3], eyeAxis[1, 4], eyeAxis[1, 5]);
                count_1 = 0; count_3 = 0; count_4 = 0; count_5_8 = 0; count_6 = 0; count_7 = 0; count_9 = 0;
                count_2++;
                if (count_2 == 18 && c2 == 1)
                {
                    Debug.Log("number 2 already exists!!");
                }
                else if (count_2 == 18)
                {
                    //off2.SetActive(false);
                    //on2.SetActive(true);
                    count++;
                    password[pass_num] = 2;
                    c2 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) > xpos2 && float.Parse(fields[1]) < ypos1)//3번영역
            {
                Debug.Log("r3");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[2, 0], eyeAxis[2, 1], eyeAxis[2, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[2, 3], eyeAxis[2, 4], eyeAxis[2, 5]);
                count_1 = 0; count_2 = 0; count_4 = 0; count_5_8 = 0; count_6 = 0; count_7 = 0; count_9 = 0;
                count_3++;
                if (count_3 == 18 && c3 == 1)
                {
                    Debug.Log("number 3 already exists!!");
                }
                else if (count_3 == 18)
                {
                    //off3.SetActive(false);
                    //on3.SetActive(true);
                    count++;
                    password[pass_num] = 3;
                    c3 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) < xpos1 && float.Parse(fields[1]) >= ypos1 && float.Parse(fields[1]) <= ypos2)//4번영역
            {
                Debug.Log("r4");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[3, 0], eyeAxis[3, 1], eyeAxis[3, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[3, 3], eyeAxis[3, 4], eyeAxis[3, 5]);
                count_1 = 0; count_2 = 0; count_3 = 0; count_5_8 = 0; count_6 = 0; count_7 = 0; count_9 = 0;
                count_4++;
                if (count_4 == 18 && c4 == 1)
                {
                    Debug.Log("number 4 already exists!!");
                }
                else if (count_4 == 18)
                {
                    //off4.SetActive(false);
                    //on4.SetActive(true);
                    count++;
                    password[pass_num] = 4;
                    c4 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) >= xpos1 && float.Parse(fields[0]) <= xpos2 && float.Parse(fields[1]) >= ypos1)//5+8번 영역(마지막 확인용)​
            {
                Debug.Log("r5,8");
                if (float.Parse(fields[0]) >= xpos1 && float.Parse(fields[0]) <= xpos2 && float.Parse(fields[1]) >= ypos1 && float.Parse(fields[1]) <= ypos2)//5번영역(동공 이동 확인용)​
                {
                    Debug.Log("r5");
                    leftEye.transform.localEulerAngles = new Vector3(eyeAxis[4, 0], eyeAxis[4, 1], eyeAxis[4, 2]);
                    rightEye.transform.localEulerAngles = new Vector3(eyeAxis[4, 3], eyeAxis[4, 4], eyeAxis[4, 5]);
                }
                else if (float.Parse(fields[0]) >= xpos1 && float.Parse(fields[0]) <= xpos2 && float.Parse(fields[1]) > ypos2)//8번영역(동공 이동 확인용)​
                {
                    Debug.Log("r8");
                    leftEye.transform.localEulerAngles = new Vector3(eyeAxis[7, 0], eyeAxis[7, 1], eyeAxis[7, 2]);
                    rightEye.transform.localEulerAngles = new Vector3(eyeAxis[7, 3], eyeAxis[7, 4], eyeAxis[7, 5]);
                }
                count_1 = 0; count_2 = 0; count_3 = 0; count_4 = 0; count_6 = 0; count_7 = 0; count_9 = 0;

            }

            else if (float.Parse(fields[0]) > xpos2 && float.Parse(fields[1]) >= ypos1 && float.Parse(fields[1]) <= ypos2)//6번영역​
            {
                Debug.Log("r6");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[5, 0], eyeAxis[5, 1], eyeAxis[5, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[5, 3], eyeAxis[5, 4], eyeAxis[5, 5]);
                count_1 = 0; count_2 = 0; count_3 = 0; count_4 = 0; count_5_8 = 0; count_7 = 0; count_9 = 0;
                count_6++;
                if (count_6 == 18 && c6 == 1)
                {
                    Debug.Log("number 6 already exists!!");
                }
                else if (count_6 == 18)
                {
                    //off6.SetActive(false);
                    //on6.SetActive(true);
                    count++;
                    password[pass_num] = 5;
                    c6 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) < xpos1 && float.Parse(fields[1]) > ypos2)//7번영역​
            {
                Debug.Log("r7");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[6, 0], eyeAxis[6, 1], eyeAxis[6, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[6, 3], eyeAxis[6, 4], eyeAxis[6, 5]);
                count_1 = 0; count_2 = 0; count_3 = 0; count_4 = 0; count_5_8 = 0; count_6 = 0; count_9 = 0;
                count_7++;
                if (count_7 == 18 && c7 == 1)
                {
                    Debug.Log("number 7 already exists!!");
                }
                else if (count_7 == 18)
                {
                    //off7.SetActive(false);
                    //on7.SetActive(true);
                    count++;
                    password[pass_num] = 6;
                    c7 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }

            else if (float.Parse(fields[0]) > xpos2 && float.Parse(fields[1]) > ypos2)//9번영역​
            {
                Debug.Log("r9");
                leftEye.transform.localEulerAngles = new Vector3(eyeAxis[8, 0], eyeAxis[8, 1], eyeAxis[8, 2]);
                rightEye.transform.localEulerAngles = new Vector3(eyeAxis[8, 3], eyeAxis[8, 4], eyeAxis[8, 5]);
                count_1 = 0; count_2 = 0; count_3 = 0; count_4 = 0; count_5_8 = 0; count_6 = 0; count_7 = 0;
                count_9++;
                if (count_9 == 18 && c9 == 1)
                {
                    Debug.Log("number 9 already exists!!");
                }
                else if (count_9 == 18)
                {
                    //off9.SetActive(false);
                    //on9.SetActive(true);
                    count++;
                    password[pass_num] = 7;
                    c9 = 1;
                    pass_num++;
                    if (pass_num == 5)
                    {
                        checkPass();
                    }
                }
            }//중간이 5,8번인데 여기를 합쳐서 48프레임?정도 보면 비밀번호 끝나는걸로 or 배열이 다 차거나

            cnt1++;
        }
        else  //몫이 1이 아님(한번 반복 후 더이상 값이 없는 상태)
        {
            Debug.Log("동공이 인식되지 않았습니다!");
            portion = cnt1 / (records.Length - 1);  //다시 해줌(값이 생기면 portion==0으로 돌아가기 위함)
        }
    }
    //============================================================================================
    void makeNine()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i % 3 == 0)
            {
                nineAxis[i, 0] = x1;
            }
            else if (i % 3 == 1)
            {
                nineAxis[i, 0] = (float)((x1 + x2) / 2);
            }
            else
            {
                nineAxis[i, 0] = x2;
            }

            if (i / 3 == 0)
            {
                nineAxis[i, 1] = y1;
            }
            else if (i / 3 == 1)
            {
                nineAxis[i, 1] = (float)((y1 + y2) / 2);
            }
            else
                nineAxis[i, 1] = y2;
        }

        xpos1 = (nineAxis[0, 0] + nineAxis[1, 0] + nineAxis[3, 0] + nineAxis[4, 0]) / 4;
        ypos1 = (nineAxis[0, 1] + nineAxis[1, 1] + nineAxis[3, 1] + nineAxis[4, 1]) / 4;
        xpos2 = (nineAxis[1, 0] + nineAxis[2, 0] + nineAxis[4, 0] + nineAxis[5, 0]) / 4;
        ypos2 = (nineAxis[3, 1] + nineAxis[4, 1] + nineAxis[6, 1] + nineAxis[7, 1]) / 4;
    }
    //===============================================================================================
    void makeAxis()
    {
        if (File.Exists("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_1.csv"))
        {
            FileStream mainAxis1 = new FileStream("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_1.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader masr1 = new StreamReader(mainAxis1);
            string axis1 = masr1.ReadLine();
            string[] ax1 = axis1.Split(',');
            x1 = float.Parse(ax1[0]);
            y1 = float.Parse(ax1[1]);
        }
        if (File.Exists("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_2.csv"))
        {
            FileStream mainAxis2 = new FileStream("C:\\Users\\minji\\Desktop\\unity_practice\\lenon test\\Assets\\Resources\\scene3-cal_2.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader masr2 = new StreamReader(mainAxis2);
            string axis2 = masr2.ReadLine();
            string[] ax2 = axis2.Split(',');
            x2 = float.Parse(ax2[0]);
            y2 = float.Parse(ax2[1]);
            state1 = false;
        }
    }
    //======================================
    void makeCircles()
    {
        if (count==1)
        {
            pc1.SetActive(true);
        }
        else if(count==2)
        {
            pc2.SetActive(true);
        }
        else if (count == 3)
        {
            pc3.SetActive(true);
        }
        else if (count == 4)
        {
            pc4.SetActive(true);
        }
        else if (count == 5)
        {
            pc5.SetActive(true);
        }
    }
}

//==========================================================================================================
