using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject controller;
    public GameObject ShieldObj;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("X rot : "+ controller.transform.position.x + " Y rot : " + controller.transform.position.y);
        //rotation = new Vector3(controller.)
        //ShieldObj.transform.RotateAround(transform.position);
    }
}
