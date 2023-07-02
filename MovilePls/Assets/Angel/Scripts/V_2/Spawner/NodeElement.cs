using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum Entity {Point, Element}
public class NodeElement : MonoBehaviour
{
    public Entity entity;
    public Vector2 position;
    public Vector2 target;
    public int value;

    public NodeElement(Entity ent, Vector2 pos, Vector2 tar, int val) 
    {
        this.entity = ent;
        this.position = pos;
        this.target = tar;
        this.value = val;

        
    }
}
