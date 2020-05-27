using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_em : MonoBehaviour
{
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles=new Vector3((float)-30.696, (float)-0.007, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3((float)0.022, (float)-0.007, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3((float)0.137, (float)-0.007, 0);
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 pos = Input.mousePosition;
        //    pos.z = 10;
        //    Vector3 target = Camera.main.ScreenToWorldPoint(pos);
        //    print("target" + target);

        //    transform.LookAt(target);
    }
    
}
