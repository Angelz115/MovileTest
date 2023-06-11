using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRot : MonoBehaviour
{
    public GameObject handle;
    public Vector2 rotHandle;

    // Update is called once per frame
    void Update()
    {
        
        rotHandle = new Vector2(handle.GetComponent<RectTransform>().anchoredPosition.x, handle.GetComponent<RectTransform>().anchoredPosition.y);
        if (rotHandle.x != 0 || rotHandle .y != 0)
        {
            Vector2 direction = new Vector2(rotHandle.x - transform.position.x, rotHandle.y - transform.position.y);
            transform.up = direction;
        }
        
        
    }
}
