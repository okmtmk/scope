using System.Collections;
using src.positions;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

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
    private MovablePosition2 _position2;

    [SerializeField] private float moveSpeed = 15;

    private void Start()
    {
        _position2 = new MovablePosition2(gameObject.transform.position, 15);
        _stopwatch = new Stopwatch();
    }

    private void Update()
    {
        var direction = MovingKey.GetMovingDirection();

        if (!(direction.x == 0 && direction.y == 0))
        {
            _position2.Move(direction, moveSpeed, _stopwatch.ElapsedMilliseconds);
            _stopwatch.Restart();

            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Input.GetAxis("Horizontal"), gameObject.transform.position.y + Input.GetAxis("Vertical"), 0);
        }
        else
        {
            _stopwatch.Stop();
            _stopwatch.Reset();
        }
        _position2.FitMovableArea();
    }
}
