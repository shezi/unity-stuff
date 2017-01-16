using UnityEngine;
using System.Collections;

// some inspirations by: http://answers.unity3d.com/questions/404420/rigidbody-constraints-in-local-space.html

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyLocalSpace : MonoBehaviour
{
    [Header("Freeze Position")]
    public bool FreezePositionX = false;
    public bool FreezePositionY = false;
    public bool FreezePositionZ = false;
  
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Vector3 _originalLocation;

    public void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        _originalLocation = transform.position;
    }

    public void Update()
    {
        if (!FreezePositionX && !FreezePositionY && !FreezePositionZ)
        {
            return;
        }

        float _x = transform.position.x;
        float _y = transform.position.y;
        float _z = transform.position.z;

        Vector3 localVelocity = transform.InverseTransformDirection(_rigidbody.velocity);
        if (FreezePositionX)
        {
            localVelocity.x = 0;
            _x = _originalLocation.x;
        }
        if (FreezePositionY)
        {
            localVelocity.y = 0;
            _y = _originalLocation.y;
        }
        if (FreezePositionZ)
        {
            localVelocity.z = 0;
            _z = _originalLocation.z;
        }

        _rigidbody.velocity = transform.TransformDirection(localVelocity);
        transform.position = new Vector3(_x, _y, _z);
    }
}
