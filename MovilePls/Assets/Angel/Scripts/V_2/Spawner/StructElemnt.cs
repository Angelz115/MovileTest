using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Entity { Point, Element }
public class StructElemnt : MonoBehaviour
{
    [System.Serializable]
    public struct StructElementI
    {
        public Entity entity;
        public Vector2 position;
        public Vector2 target;
        public int value;

    }
}
