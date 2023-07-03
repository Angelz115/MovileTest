using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public List<GameObject> Asteroids = new List<GameObject>();
    public List<GameObject> Points = new List<GameObject>();
    public List<Transform> positions = new List<Transform>();
    public GameObject baseEntity;
    public GameObject currentEntity;
    public Vector2 playerPosition;

    
    public Transform thisPosition;
    public Vector2 target;
    public int thisValue;

    public int entity;
    public int pointRepetition;
    public int asteroidRepetition;
    public int maxRepetition;

    public int lastValue;
    public int valueCount;

    public int lastPos;
    public int choosePos;

    public float timer;
    public float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            createObject();
            timer = 0;
        }
    }
    
    void createObject() 
    {
        manageValues();
        if (entity == 0)
        {
            currentEntity = Instantiate(Points[thisValue], thisPosition.position, transform.rotation);
        }
        else
        {
            currentEntity = Instantiate(Asteroids[thisValue], thisPosition.position, transform.rotation);
        }
        //currentEntity
        
    }

    public void manageValues()
    {
        //asignar al elemento su entidad 

        entity = Random.Range(0, 2);
        if (entity == 0)
        {
            
            pointRepetition++;

            if (pointRepetition == maxRepetition)
            {
                entity = 1;
                pointRepetition = 0;

            }
        }
        else if (entity == 1)
        {
            
            asteroidRepetition++;

            if (asteroidRepetition == maxRepetition)
            {
                entity = 0;
                asteroidRepetition = 0;

            }
        }

        //asignar al elemento su valor

        thisValue = Random.Range(0, 4);
        if (lastValue == thisValue)
        {
            valueCount++;
            if (valueCount >= 3)
                thisValue = Random.Range(0, 4);
        }
        else
            valueCount = 0;

        lastValue = thisValue;

        //asignar al elemento su posicion
        choosePos = Random.Range(0, 4);

        if (lastPos == choosePos)
        {
            choosePos = Random.Range(0, 4);
        }
        thisPosition = positions[choosePos];

        target = playerPosition;
    }
}
