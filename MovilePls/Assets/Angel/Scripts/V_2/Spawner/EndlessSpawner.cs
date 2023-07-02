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

    public Entity thisEntity;
    public Transform thisPosition;
    public Vector2 target;
    public int thisValue;


    public int pointRepetition;
    public int asteroidRepetition;
    public int maxRepetition;

    public int lastValue;
    public int valueCount;

    public int lastPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void createObject() 
    {
        manageValues();
        currentEntity = Instantiate(baseEntity, thisPosition.position, transform.rotation);
        
    }

    public void manageValues()
    {
        //asignar al elemento su entidad 

        int entity = Random.Range(0, 2);
        if (entity == 0)
        {
            thisEntity = Entity.Point;
            pointRepetition++;

            if (pointRepetition == maxRepetition)
            {
                thisEntity = Entity.Element;
                pointRepetition = 0;

            }
        }
        else if (entity == 1)
        {
            thisEntity = Entity.Element;
            asteroidRepetition++;

            if (asteroidRepetition == maxRepetition)
            {
                thisEntity = Entity.Element;
                asteroidRepetition = 0;

            }
        }

        //asignar al elemento su valor

        thisValue = Random.Range(0, 5);
        if (lastValue == thisValue)
        {
            valueCount++;
            if (valueCount >= 3)
                thisValue = Random.Range(0, 5);
        }
        else
            valueCount = 0;

        lastValue = thisValue;

        //asignar al elemento su posicion
        int choosePos = Random.Range(0, 5);

        if (lastPos == choosePos)
        {
            choosePos = Random.Range(0, 5);
        }
        thisPosition = positions[choosePos];

        target = playerPosition;
    }
}
