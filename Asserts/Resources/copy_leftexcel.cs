using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class copy_leftexcel : MonoBehaviour
{
    public GameObject cubeTest;
    public TextAsset csvFile;
    int cnt = 0;

    // Update is called once per frame
    void Update()
    {
       // transform.localEulerAngles = new Vector3((float)3.836,(float)164.928,(float)0.24);

        readCSV();
        cnt++;
    }

    void readCSV()
    {
        string[] records = csvFile.text.Split('\n');
        
        for (int i = 1; i < records.Length; i++)
        {
            string[] fields = records[cnt%9+1].Split(',');
            Debug.Log("test1:  " + fields[3] + "test2:  " + fields[4] + "test3:  " + fields[5]);
            // cubeTest.transform.Rotate(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));

            //cubeTest.transform.rotation = Quaternion.Euler(new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5])));
            //transform.localEulerAngles = new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));
            transform.localEulerAngles = new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));
        }
    }
}




/*
public class left_excel : MonoBehaviour
  
{
    public int a;
    void Start()
    {
      //  Csv();
      a=0;
    }
    
    // Update is called once per frame

    void Update()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("LEFT");

        //    Position
        //transform.position = new Vector3((float)data[1]["LXP"], (float)data[1]["LYP"], (float)data[1]["LZP"]);

        //  Rotation
        transform.localEulerAngles = new Vector3(LXR(), LYR(), LZR());

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    a++;
        //}


    }

    float LXR()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("LEFT");

        return (float)data[a]["LXR"];
    }
    float LYR()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("LEFT");

        return (float)data[a]["LYR"];
    }
    float LZR()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("LEFT");

        return (float)data[a]["LZR"];
    }

    
}
*/