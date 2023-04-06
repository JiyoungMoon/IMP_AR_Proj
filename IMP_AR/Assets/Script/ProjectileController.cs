using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    // fields related to moving and throwing the projectile
    private Rigidbody _stoneRB;

    private bool _isThrowProjectileRunning = false;
    private bool _isMouseClick = false;


    private Vector3 _startVector;
    private Vector3 _finishVector;
    private Camera _camera;
    private Vector3 _mouseMovement;

    private Vector3 _offset;
    private Vector3 _throwVector;


    // fields related to draw projectile's trajectory
    private LineRenderer _lineRender;
    private int _lineRenderIndex = 0;
    [SerializeField] private int _maxNumRenderPoints = 20000;
    private float _renderTimeGap = 1/60f;

    // Start is called before the first frame update
    void Start()
    {   
        // init basic fields for projectile movement
        _stoneRB = GetComponent<Rigidbody>();
        _camera = Camera.main;
        _offset = transform.position - _camera.transform.position;

        // init basic fields for drawing projectile's trajectory line
        _lineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        // when this projectile falls down near ground
        if (transform.position.y < -100){
            _isThrowProjectileRunning = false;
            Destroy(this.gameObject);
        }

        // check the mouse clicking, get the mouse position
        if (Input.GetMouseButtonDown(0)){
            _isMouseClick = true;
            _startVector = Input.mousePosition;
            _finishVector = Input.mousePosition;

        }
        if (Input.GetMouseButton(0)){
            _finishVector = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(0)){
            _isMouseClick = false;
            _finishVector = Input.mousePosition;
            _lineRender.enabled = false;
            ThrowProjectile();
        }
    }
    private bool _firstthrow = false;
    private void FixedUpdate() {
        // when the player unclick the mouse, it will throw projectile by adding force
        if (_isThrowProjectileRunning == true){
            
            if (_firstthrow == false){
                _stoneRB.AddForce((Vector3.SqrMagnitude(_mouseMovement) / 100 * _camera.transform.forward * 0.01f - _camera.transform.right*_mouseMovement.x * 0.01f - _camera.transform.up*_mouseMovement.y * 0.02f)/_stoneRB.mass, ForceMode.Impulse);
                _firstthrow = true;
                _lineRender.enabled = false;
            }
        }

    }

    private void LateUpdate() {


        // when the projectile is not throwing, needs to be shown in front of the camera continuously
        if (_isThrowProjectileRunning == false) {
            if (_isMouseClick == false){
                transform.position = _camera.transform.position - _camera.transform.up * 0.3f  + _camera.transform.forward;
            }
            if (_isMouseClick == true){

                _mouseMovement = _finishVector - _startVector;
                Vector3 convertedMouseMovement = _camera.transform.right*_mouseMovement.x + _camera.transform.up*_mouseMovement.y;
                transform.position = _camera.transform.position - _camera.transform.up * 0.3f  + _camera.transform.forward + convertedMouseMovement / 700;
                drawTrajectoryLine();
                

            }
        }
    }

    // set the basic vectors needs for throwing projectile
    private void ThrowProjectile(){
        _isThrowProjectileRunning = true;
        _stoneRB.useGravity = true;
        _firstthrow = false;
    }

    private void drawTrajectoryLine(){
        _lineRenderIndex = 0;
        _lineRender.positionCount = _maxNumRenderPoints;
        _lineRender.enabled = true;
        Vector3 startPosition = transform.position;
        
        _throwVector = (Vector3.SqrMagnitude(_mouseMovement) / 100 * _camera.transform.forward * 0.01f - _camera.transform.right*_mouseMovement.x * 0.01f - _camera.transform.up*_mouseMovement.y * 0.02f) / _stoneRB.mass;
        

        _lineRender.SetPosition(_lineRenderIndex,startPosition);
        for (float j=0;_lineRenderIndex<_lineRender.positionCount;j+=_renderTimeGap) {
            _lineRenderIndex++;
            Vector3 linePosition = startPosition + j * _throwVector;
            linePosition.y = startPosition.y + _throwVector.y * j + 0.5f * Physics.gravity.y*j*j;
            _lineRender.SetPosition(_lineRenderIndex, linePosition); 
        }
    }

    
}
