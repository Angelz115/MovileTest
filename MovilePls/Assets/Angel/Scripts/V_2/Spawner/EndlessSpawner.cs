using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState {Normal,MeteorShower, Buy}
public class EndlessSpawner : MonoBehaviour
{
    [Header("Predefined Elements")]
    public GameState gameState;
    public List<GameObject> asteroids = new List<GameObject>();
    public List<GameObject> points = new List<GameObject>();
    public List<Transform> positions = new List<Transform>();
    public GameObject player;
    public float force;

    [Space]
    [Header("Predefined Elements")]

    public GameObject currentEntity;
    private Vector2 playerPosition = new Vector2(0,0);

    [Space]
    [Header("Element identity ")]

    public int entity;
    public int maxRepetition;
    public int pointRepetition;
    public int asteroidRepetition;

    [Space]
    [Header("Index of the list ")]

    public int currentValue;
    public int lastValue;
    public int valueCount;

    [Space]
    [Header("Element Position")]

    public Vector3 currentPosition;
    public int lastPos;
    public int choosePos;
    private Vector2 target;
    public float xAlter, yAlter;

    [Space]
    [Header("Timer ")]

    public float timer;
    public float maxTime;
   
    private Transform currentPosition2;
    

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Normal;
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
        switch (gameState)
        {
            case GameState.Normal:

                if (entity == 0)
                {
                    currentEntity = Instantiate(points[currentValue], currentPosition, transform.rotation);
                }
                else
                {
                    currentEntity = Instantiate(asteroids[currentValue], currentPosition, transform.rotation);
                }
                break;

            case GameState.MeteorShower:

                currentEntity = Instantiate(asteroids[currentValue], currentPosition, transform.rotation);

                break;

            case GameState.Buy:
                return;
                
            
        }
        
        currentEntity.GetComponent<BehaviorV2>().player = player;
        currentEntity.GetComponent<BehaviorV2>().force = force;


    }
    void manageValues() 
    {
        //Asignar el valor de la entidad, si es 1 es un asteroide, si es 0 es un punto.
        entity = Random.Range(0,2);
        switch (entity)
        {
            case 1:

                asteroidRepetition++;

                if (asteroidRepetition >= maxRepetition)
                    entity = 0;
                
                break;
            case 0:

                pointRepetition++;

                if (pointRepetition >= maxRepetition)
                    entity = 1;

                break;
        }

        //Asignar al elemento el indice en la lista
        currentValue = randomListVal();
        if (lastValue == currentValue)
        {
            valueCount++;
            if (valueCount >= 3)
            {
                currentValue = randomListVal();
            }
        }
        lastValue = currentValue;

        //Asignar al elemento la posicion en la que se creara
        choosePos = randomListVal();
        if (lastPos == choosePos)
        {
            choosePos = randomListVal();
        }
        if (choosePos %2 == 0)
        {
            float xAlt = Random.Range(-xAlter,xAlter+0.01f);
            currentPosition = new Vector3(positions[choosePos].position.x + xAlt,positions[choosePos].position.y,0);
            
        }
        else
        {
            float yAlt = Random.Range(-yAlter, yAlter + 0.01f);
            currentPosition = new Vector3(positions[choosePos].position.x, positions[choosePos].position.y + yAlt, 0);
        }
        lastPos = choosePos;
        


        int randomListVal() 
        {
            int val = Random.Range(0, 4);
            return val;
        }
    }

   
}
