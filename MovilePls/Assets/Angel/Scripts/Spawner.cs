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
    public List<int> toSpawn;
    public List<int> Location;

    public bool emptyList;
    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            timer = 0;
            createObject();
            
        }
    }
    void createObject() 
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
}
