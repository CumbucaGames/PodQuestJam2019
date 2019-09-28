using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Cube : MonoBehaviour
{
    private Transform _transform;
    [SerializeField] private AnimationCurve rotateCurve;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void RotateUp()
    {
        //transform.RotateAround(transform.position, Vector3.left, -90);
        StartCoroutine(RotateAround(transform.position, Vector3.left, -90));
    }
    
    public void RotateDown()
    {
        //transform.RotateAround(transform.position, Vector3.left, 90);
        StartCoroutine(RotateAround(transform.position, Vector3.left, 90));
    }
    
    public void RotateLeft()
    {
        //transform.RotateAround(transform.position, Vector3.forward, 90);
        StartCoroutine(RotateAround(transform.position, Vector3.forward, 90));
    }
    
    public void RotateRight()
    { 
        //transform.RotateAround(transform.position, Vector3.forward, -90);
        StartCoroutine(RotateAround(transform.position, Vector3.forward, -90));
    }

    private IEnumerator RotateAround(Vector3 point, Vector3 axis, float angle)
    {
        //TODO: improve this function, to account for the pivot when rotating
        var lastKey = rotateCurve[rotateCurve.length - 1];
        var finalDuration = lastKey.time;

        var currentTime = 0f;

        while (currentTime < finalDuration)
        {
            yield return null;
            var angleStep = rotateCurve.Evaluate(currentTime) * angle * 2 * Time.deltaTime;
            transform.RotateAround(transform.position, axis, angleStep);
            currentTime += Time.deltaTime;
        }
    }
}
