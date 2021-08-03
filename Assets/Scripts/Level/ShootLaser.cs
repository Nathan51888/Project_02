using UnityEngine;
using UnityEngine.U2D;

namespace Level
{
    public class ShootLaser : MonoBehaviour
    {
        private const int MAXBounces = 4;
        public Transform firePoint;
        public Material material;
        public Color laserColour;
        private LineRenderer laser;
        private Vector3 position, direction;
        private SpriteShapeRenderer sprite;


        private void Start()
        {
            sprite = GetComponent<SpriteShapeRenderer>();
            laser = GetComponent<LineRenderer>();
            laser.SetPosition(0, firePoint.position);
            sprite.color = laserColour;
            laser.startWidth = 0.1f;
            laser.endWidth = 0.1f;
            laser.material = material;
            laser.startColor = laserColour;
            laser.endColor = laserColour;
        }

        private void Update()
        {
            CastLaser(firePoint.position, firePoint.right);
        }

        private void CastLaser(Vector3 pos, Vector3 dir)
        {
            Transform startPoint = firePoint;
            direction = startPoint.right;
            position = startPoint.position;
            laser.SetPosition(0, position);

            for (var i = 0; i < MAXBounces; i++)
            {
                var ray = new Ray2D(position, direction);
                var hit = Physics2D.Raycast(position, direction, 150);

                if (hit == true)
                {
                    position = hit.point;
                    direction = Vector2.Reflect(direction, hit.normal);
                    laser.SetPosition(i + 1, position);

                    switch (hit.collider.tag)
                    {
                        case "Player":
                            Debug.Log("Hit Player");
                            GameManager.Instance.Respawn(); 
                            break;

                        case "Switch":
                            if (hit.collider.GetComponent<LaserSwitch>().switchColour == laser.startColor)
                            {
                                Debug.Log("Laser Switch Activate");
                                hit.collider.GetComponent<Switch>().TurnOn();
                            }

                            Debug.Log("Laser Switch Disable");
                            break;
                    }
                    
                    if (!hit.collider.CompareTag("Mirror"))
                    {
                        for (var j = i + 1; j <= MAXBounces; j++)
                        {
                            laser.SetPosition(j, hit.point);
                        }

                        break;
                    }
                }
                else
                {
                    laser.SetPosition(i + 1, ray.GetPoint(150));
                    break;
                }
            }
        }
    }
}