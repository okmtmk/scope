using System.Diagnostics;
using src.positions;
using UnityEngine;

namespace Components.GamepadInputs
{
    public class GamepadInput : MonoBehaviour
    {
        // Start is called before the first frame update
        /*void Start()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
           
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + Input.GetAxis("Horizontal"), gameObject.transform.position.y + Input.GetAxis("Vertical"), 0);
    }*/

        private Stopwatch _stopwatch;

        [SerializeField] private float moveSpeed = 15;

        private void Start()
        {
            _stopwatch = new Stopwatch();
        }

        private void Update()
        {
            var direction = MovingKey.GetMovingDirection();

            if (!(direction.x == 0 && direction.y == 0))
            {
                _stopwatch.Restart();

                gameObject.transform.position
                    = new Vector3(gameObject.transform.position.x + Input.GetAxis("Horizontal"),
                        gameObject.transform.position.y + Input.GetAxis("Vertical"), 0);
            }
            else
            {
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }
    }
}