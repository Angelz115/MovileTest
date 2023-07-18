using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV2 : MonoBehaviour
{
    
    [Header("Predefined Elements ")]
    public List<GameObject> Asteroids = new List<GameObject>();
    public List<GameObject> Points = new List<GameObject>();
    public List<StructElemnt.StructElementI> Elements = new List<StructElemnt.StructElementI>();
    public GameObject player;
    public float force;
    public GameObject asteroidParticles;
    [Space]
    [Header("Entity")]
    public GameObject currentEntity;
    public int travelList;

    public Entity thisEntity;
    public Vector2 thisPosition;
    public int thisValue;
    [Space]
    [Header("Timer")]
    public float timer;
    public float maxTimer;
    [Space]
    [Header("Comodity")]
    public int listLength;
    public float xAlter;
    public float yAlter;
    public Vector2 xpos;
    public Vector2 ypos;

    // Start is called before the first frame update
    void Start()
    {
        listLength = Elements.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (listLength <= travelList)
        {
            GameManager2.Instance.currentState = playState.Ended;
            return;
        }
        timer += Time.deltaTime;
        if (timer>= maxTimer)
        {
            createObject();
            timer = 0;
        }
    }
    public void createObject()
    {
        
        thisEntity = Elements[travelList].entity;
        thisPosition = Elements[travelList].position;
        thisValue = Elements[travelList].value;
        switch (thisEntity)
        {
            case Entity.Point:
                currentEntity = Instantiate(Points[thisValue],thisPosition,Quaternion.identity);
                break;
            case Entity.Asteroid:
                currentEntity = Instantiate(Asteroids[thisValue], thisPosition, Quaternion.identity);
                break;
            
        }
        currentEntity.GetComponent<BehaviorV2>().player = player;
        currentEntity.GetComponent<BehaviorV2>().force = force;
        currentEntity.GetComponent<BehaviorV2>().Entity = thisEntity;
        currentEntity.GetComponent<BehaviorV2>().value = thisValue;
        currentEntity.GetComponent<BehaviorV2>().asteroidParticles = asteroidParticles;
        travelList++;
    }
    
}
