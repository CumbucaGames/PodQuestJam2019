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
        transform.Rotate(90f, 0, 0, Space.World);
//        StartCoroutine(Rotate(transform.position, Vector3.left, -90));
    }
    
    public void RotateDown()
    {
        transform.Rotate(-90f, 0, 0, Space.World);
//        StartCoroutine(Rotate(transform.position, Vector3.left, 90));
    }
    
    public void RotateLeft()
    {
        transform.Rotate(0, 0, 90f, Space.World);
        //        StartCoroutine(Rotate(transform.position, Vector3.forward, 90));
    }
    
    public void RotateRight()
    {
        transform.Rotate(0, 0, -90f, Space.World);
        //        StartCoroutine(Rotate(transform.position, Vector3.forward, -90));
    }

//    private IEnumerator Rotate(Vector3 point, Vector3 axis, float angle)
//    {
//        // TODO: calculate the rotate pivot point
//        
//        var indexLastFrame = rotateCurve.length - 1;
//        var duration = rotateCurve.keys[indexLastFrame].time;
//        var finalValue = rotateCurve[indexLastFrame].value;
//
//        var t = 0f;
//        while (t < duration)
//        {
//            var value = rotateCurve.Evaluate(t);
//            
//            var angleStep = Mathf.Lerp(0, angle, (float) value/finalValue);
//            transform.RotateAround(transform.localPosition, axis, angleStep);
//            //transform.Rotate(Quaternion.Euler());
//            t += Time.fixedDeltaTime;
//            yield return new WaitForFixedUpdate();
//        }
//        yield return null;
//    }
}
