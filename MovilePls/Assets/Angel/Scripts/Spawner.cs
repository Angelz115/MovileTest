using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public float timeToSpawn = 2;
    public Vector2 target;

    public List<GameObject> Positions;
    public List<GameObject> Enemy;
    public List<GameObject> Point;

    public List<int> ObjectValue;
    public int ObjectValueInt;
    public List<int> toSpawn;
    public int toSpawnInt;

    public List<int> Location;
    public int currentLocation;

    public bool emptyList;
    public float force = 10;

    public int totalEnemies;
    public int totalPoints;
    public int totalValPoints;
    public PlayerLife playerLife;

    private void Awake()
    {
        for (int i = 0; i < toSpawn.Count; i++)
        {
            if (toSpawn[i] == 0) 
            { 
                totalPoints++;
                totalValPoints += ObjectValue[i] + 1;
            }
                
            if (toSpawn[i] == 1)
                totalEnemies++;

        }
        Debug.Log(totalValPoints);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (playerLife.isDead)
        {
            return;
        }
        if (emptyList)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0;
            createObject2();
            //createObject();
        }
    }
    void createObject2() 
    {

        if (toSpawn.Count == toSpawnInt)
        {
            emptyList = true;
            Debug.Log(emptyList);
            return;

        }

        ObjectValueInt = ObjectValue[toSpawnInt];
        currentLocation = Location[toSpawnInt];
        if (toSpawn[toSpawnInt] == 0)                       //si el valor en la lista es 0 crea puntos
        {
            //Debug.Log(ObjectValueInt + " - " + currentLocation);
            InstaObj(Point[ObjectValueInt]);
            //return;
        }
        if (toSpawn[toSpawnInt] == 1)                       //si el valor en la lista es 1 crea enemigo
        {
            //Debug.Log(ObjectValueInt + " - " + currentLocation);
            InstaObj(Enemy[ObjectValueInt]);
            //return;
        }

        toSpawnInt++;
        void InstaObj(GameObject whatTo)
        {
            GameObject thisGM;
            
            switch (ObjectValue[toSpawnInt])
            {
                case 3:
                    thisGM = Instantiate(whatTo, Positions[currentLocation].transform.position, transform.rotation);
                    //Debug.Log("Se creo el objeto: " + toSpawn[toSpawnInt] + " con valor: " + ObjectValue[toSpawnInt] + " en la posicion: " + Location[toSpawnInt]);
                    break;
                case 2:
                    thisGM = Instantiate(whatTo, Positions[currentLocation].transform.position, transform.rotation);
                    //Debug.Log("Se creo el objeto: " + toSpawn[toSpawnInt] + " con valor: " + ObjectValue[toSpawnInt] + " en la posicion: " + Location[toSpawnInt]);
                    break;
                case 1:
                    thisGM = Instantiate(whatTo, Positions[currentLocation].transform.position, transform.rotation);
                    //Debug.Log("Se creo el objeto: " + toSpawn[toSpawnInt] + " con valor: " + ObjectValue[toSpawnInt] + " en la posicion: " + Location[toSpawnInt]);
                    break;
                default:
                    thisGM = Instantiate(whatTo, Positions[currentLocation].transform.position, transform.rotation);
                    //Debug.Log("Se creo el objeto: " + toSpawn[toSpawnInt] + " con valor: " + ObjectValue[toSpawnInt] + " en la posicion: " + Location[toSpawnInt]);
                    break;
            }
            thisGM.GetComponent<Behavior>().target = target;
            thisGM.GetComponent<Behavior>().force = force;
            thisGM.GetComponent<Behavior>().identity = toSpawn[toSpawnInt];
        }


        
    }
    /*
    void createObject() //guardar el codigo porsiacaso
    {
        if (toSpawn.Count == 0)
        {
            //Debug.Log("Perdiste");
            return;
        }
        
        if (toSpawn[0] == 0)                        //si es 0 crea puntos
        {
            InstObject(Point[ObjectValue[0]]);
        }
        if (toSpawn[0] == 1)
        {                                           //si es 1 es basura 
            InstObject(Enemy[ObjectValue[0]]);
        }
        
        RemoveFirst();

        void InstObject(GameObject toGenerate) 
        {
            GameObject thisObject;
            switch (Location[0])
            {
                case 3:
                    thisObject = Instantiate(toGenerate, Positions[Location[0]].transform.position, transform.rotation);
                    break;

                case 2:
                    thisObject = Instantiate(toGenerate, Positions[Location[0]].transform.position, transform.rotation);
                    break;

                case 1:
                    thisObject = Instantiate(toGenerate, Positions[Location[0]].transform.position, transform.rotation);
                    break;

                default:
                    thisObject = Instantiate(toGenerate, Positions[Location[0]].transform.position, transform.rotation);
                    break;
            }
            thisObject.GetComponent<Behavior>().target = target;
            thisObject.GetComponent<Behavior>().force = force;
        }
        void RemoveFirst() 
        {
        
            ObjectValue.RemoveAt(0);
            toSpawn.RemoveAt(0);
            Location.RemoveAt(0);
        }
        
        
    }
    */
}
