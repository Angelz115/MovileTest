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
    public int allPoints;
    public float cullDown;

    // Start is called before the first frame update
    void Start()
    {
        listLength = Elements.Count;
        GameManager2.Instance.type = gameType.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager2.Instance.currentState == playState.Victory)
        {
            /*
            timer += Time.deltaTime;
            if (timer >= 2.2f)
            {
                GameManager2.Instance.Victory();
            }
            */
            return;
        }
        if (GameManager2.Instance.currentState != playState.Playing)
        {
            return;
        }
        if (travelList == 0)
        {
            GameManager2.Instance.text("Los proximos 4 objetos son puntos, debes agarrarlos");
        }
        if (travelList == 2)
        {
            GameManager2.Instance.turnDownText();
        }
        if (travelList == 5)
        {
            GameManager2.Instance.text("Los proximos 4 objetos son asteroides, evita que te toquen");
            GameManager2.Instance.activateShield();
        }
        if (travelList ==7)
        {
            GameManager2.Instance.turnDownText();
        }
        if (travelList == 9)
        {
            GameManager2.Instance.text("Usa los proyectiles para destruir a los Asteroides");
            GameManager2.Instance.activateProyectiles();
        }
        if (travelList == 11)
        {
            GameManager2.Instance.turnDownText();
        }
        if (travelList == 13)
        {
            GameManager2.Instance.text("Puedes usar el escudo para defenderte de los asteroides");
            GameManager2.Instance.ativateshieldButton();
        }

        if (travelList == 15)
        {
            GameManager2.Instance.turnDownText();
        }

        if (listLength <= travelList)
        {
            Invoke(nameof(callVictory), cullDown);
            return;
        }
        timer += Time.deltaTime;
        if (timer>= maxTimer)
        {
            createObject();
            timer = 0;
        }
    }
    public void callVictory() 
    {
        GameManager2.Instance.Victory();
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
                allPoints++;
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
    public int getAllPoints() 
    {
        return allPoints;
    }
}
