using UnityEngine;

namespace DefaultNamespace
{
    public class Parallax : MonoBehaviour
    {
        public GameObject cam;
        public float parallaxEffect;
        private float length, startPos;

        private void Start()
        {
            startPos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
            //cam = FindObjectOfType<Camera>().gameObject;
        }

        private void FixedUpdate()
        {
            var temp = cam.transform.position.x * (1 - parallaxEffect);
            var distance = cam.transform.position.x * parallaxEffect;

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