using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Entity { Point, Asteroid }
public class StructElemnt : MonoBehaviour
{
    [System.Serializable]
    public struct StructElementI
    {
        public Entity entity;
        public Vector2 position;
        public int value;

    }
}
