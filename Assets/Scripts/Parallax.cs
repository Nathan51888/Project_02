using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class Parallax : MonoBehaviour
    {
        private float length, startPos;
        public GameObject cam;
        public float parallaxEffect;

        private void Start()
        {
            startPos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
            //cam = FindObjectOfType<Camera>().gameObject;
        }

        private void FixedUpdate()
        {
            float temp = cam.transform.position.x * (1 - parallaxEffect);
            float distance = cam.transform.position.x * parallaxEffect;

            transform.position = 
                new Vector3(
                    startPos + distance, 
                    transform.position.y, 
                    transform.position.z);

            if (temp > startPos + length)
                startPos += length;
            else if (temp < startPos + length)
                startPos -= length;
        }
    }
}