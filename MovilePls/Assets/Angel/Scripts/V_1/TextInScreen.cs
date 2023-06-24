using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInScreen : MonoBehaviour
{
    public float timer, maxTime;
    public bool isActive;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (isActive)
            timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            isActive = false;
            timer = 0;
            gameObject.SetActive(false);
        }
    }
}
