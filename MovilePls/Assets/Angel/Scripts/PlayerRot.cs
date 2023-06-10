using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRot : MonoBehaviour
{
    public GameObject handle;
    public float speed = 5;
    public Vector2 rotHandle;
    public Vector2 compare = new Vector2(127,0); 
    public Rigidbody2D rb;
    

    // Update is called once per frame
    void Update()
    {
        
        //rb.MoveRotation();
        rotHandle = new Vector2(handle.GetComponent<RectTransform>().anchoredPosition.x, handle.GetComponent<RectTransform>().anchoredPosition.y);
        float Up = rotHandle.x * rotHandle.y;
        float Udown = Mathf.Sqrt(Mathf.Pow(127, 2) + Mathf.Sqrt(Mathf.Pow(0, 2)));
        float Vdown = Mathf.Sqrt(Mathf.Pow(rotHandle.y, 2) + Mathf.Pow(rotHandle.y, 2));
        float Down = Udown * Vdown;
        float angle =Mathf.Pow( Mathf.Cos(Up / Down),-1 );
        
        if (Up >= 1300)
        {
            Debug.Log(Down);
            Debug.Log("Ver si : " + Mathf.Sqrt(Mathf.Pow(0, 2)));
            //Debug.Log(Mathf.Pow(speed,2));

        }
        //transform.Rotate(handle.transform.position * speed);
    }
}
