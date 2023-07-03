using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorV2 : MonoBehaviour
{
    public float maxtimer, timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxtimer)
        {
            Destroy(gameObject);
        }
    }
}
