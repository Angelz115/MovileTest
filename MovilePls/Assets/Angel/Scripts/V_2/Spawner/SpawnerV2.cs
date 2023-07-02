using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV2 : MonoBehaviour
{
    //public List<NodeElement> Elements = new List<NodeElement>();
    public StructElemnt StructElemnt;
    public List<GameObject> Asteroids = new List<GameObject>();
    public List<GameObject> Points = new List<GameObject>();
    public List<StructElemnt.StructElementI> Elements = new List<StructElemnt.StructElementI>();
    public GameObject currentEntity;
    public int toSpawn;

    public Entity thisEntity;
    public Vector2 thisPosition;
    public Vector2 thisTarget;
    public int thisValue;

    public int pointRepetition;
    public int asteroidRepetition;
    public int maxRepetition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createObject()
    {

        manageValues();


    }
    public void manageValues()
    {
        //decidir la entidad del elemento
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


    }
}
