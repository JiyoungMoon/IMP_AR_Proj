using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    // fields related to throwing the projectile
    private bool _isThrowProjectileRunning = false;
    private Vector3 _throwVector;
    private Vector3 _normalVector;
    private Vector3 _unitDirection;
    [SerializeField] private float Power = 0.03f;


    // fields related to moving the projectile and throw it
    private Vector3 _startVector;
    private Vector3 _finishVector;

    private Rigidbody _stoneRB;
    private Camera _camera;
    private Vector3 _offset;
    private bool _isMouseClick = false;
    private Vector3 _mouseMovement;


    // Start is called before the first frame update
    void Start()
    {
        _stoneRB = GetComponent<Rigidbody>();
        _camera = Camera.main;
        _offset = transform.position - _camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        // when this projectile falls down near ground
        if (transform.position.y < 0.1){
            _isThrowProjectileRunning = false;
            Destroy(this.gameObject);
        }

        // when the tab button clicks destroy (For test)
        if (Input.GetKeyDown(KeyCode.Tab)){
            _isThrowProjectileRunning = false;
            Destroy(this.gameObject);
        }

        // check the mouse clicking, get the mouse position
        if (Input.GetMouseButtonDown(0)){
            _isMouseClick = true;
            _startVector = Input.mousePosition;
        }
        if (Input.GetMouseButton(0)){
            _finishVector = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0)){
            _isMouseClick = false;
            _finishVector = Input.mousePosition;
            ThrowProjectile(_startVector, _finishVector);
        }
    }

    private void FixedUpdate() {

        // when the player unclick the mouse, it will throw projectile by adding force
        if (_isThrowProjectileRunning == true){
            _stoneRB.AddForce(_throwVector * Time.deltaTime, ForceMode.Force);
        }

    }

    private void LateUpdate() {
        // when the projectile is not throwing, needs to be shown in front of the camera continuously
        if (_isThrowProjectileRunning == false) {
            if (_isMouseClick == false){
                transform.position = _camera.transform.position + _camera.transform.forward * Vector3.SqrMagnitude(_offset);
            }
            if (_isMouseClick == true){
                _mouseMovement = _finishVector - _startVector;
                transform.position = _camera.transform.position + _camera.transform.forward * Vector3.SqrMagnitude(_offset) + _mouseMovement / 600;
            }
        }
    }

    // set the basic vectors needs for throwing projectile
    private void ThrowProjectile(Vector3 firstPoint, Vector3 lastPoint){
        _isThrowProjectileRunning = true;

        // The formula for calculating the throwing vector should be changed
        _normalVector = Vector3.Normalize(Camera.main.transform.forward);
        _unitDirection = Vector3.Normalize(firstPoint - lastPoint);
        _throwVector = (_unitDirection + _normalVector) * Power * Vector3.Magnitude(firstPoint - lastPoint);
        ////////

        _stoneRB.useGravity = true;
    }
}
