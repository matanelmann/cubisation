using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClass : MonoBehaviour
{
    
    public class Cube
    {
        public static CubeClass.Cube instance;
        private void Awake()
        {
            instance = this;
        }
        public Transform cubeTransform;
        public float length;
        public float scale;
        public Rigidbody2D rb;
        public Cube(Transform cubeTransform)
        {
            this.cubeTransform = cubeTransform;
            this.length = cubeTransform.localScale.x * 5.12f;
            this.scale = cubeTransform.localScale.x;
            this.rb = cubeTransform.gameObject.GetComponent<Rigidbody2D>();
        }
    }

}
