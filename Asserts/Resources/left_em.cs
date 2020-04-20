using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_em : MonoBehaviour
  
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
            transform.localEulerAngles = new Vector3((float)1.922, (float)179.993, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3((float)0.008, (float)179.993, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3((float)-29.437, (float)179.993, 0);
        }
    }
}
