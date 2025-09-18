using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    private Vector3 target;
    private Vector3 initialPosition;
    private bool _goingToA = true;
    private bool _goingToB = false;
    private bool _goingToC = false;
    private bool _goingToOrigin = false;


    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (_goingToA)
        {
            target = pointA.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
            {
                _goingToA = false;
                _goingToB = true;
            }
        }
        else if (_goingToB)
        {
            target = pointB.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
            {
                _goingToB = false;
                _goingToC = true;
            }
        }
        else if (_goingToC)
        {
            target = pointC.position;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, pointC.position) < 0.1f)
            {
                _goingToC = false;
                _goingToOrigin = true;
            }
        }
        else if (_goingToOrigin)
        {
            target = initialPosition;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
            {
                _goingToOrigin = false;
                _goingToA = true;
            }
        }
    }
}