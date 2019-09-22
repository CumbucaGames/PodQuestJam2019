using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Cube : MonoBehaviour
{
    private Transform _transform;
    //[SerializeField] private AnimationCurve rotateCurve;
    
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void RotateUp()
    {
        transform.RotateAround(transform.position, Vector3.left, -90);
        //StartCoroutine(Rotate(transform.position, Vector3.left, -90));
    }
    
    public void RotateDown()
    {
        transform.RotateAround(transform.position, Vector3.left, 90);
        //StartCoroutine(Rotate(transform.position, Vector3.left, 90));
    }
    
    public void RotateLeft()
    {
        transform.RotateAround(transform.position, Vector3.forward, 90);
        //StartCoroutine(Rotate(transform.position, Vector3.forward, 90));
    }
    
    public void RotateRight()
    { 
        transform.RotateAround(transform.position, Vector3.forward, -90);
        //StartCoroutine(Rotate(transform.position, Vector3.forward, -90));
    }

//    private IEnumerator Rotate(Vector3 point, Vector3 axis, float angle)
//    {
//        var length = rotateCurve.length;
//
//        for (int i = 0; i < length; i++)
//        {
//            var angleStep = Mathf.Lerp(0, angle, (float) i / length);
//            transform.RotateAround(transform.position, Vector3.forward, angleStep);
//            yield return new WaitForFixedUpdate();
//        }
//        yield return null;
//    }
}
