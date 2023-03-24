using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ProjectileController;

public class HandleProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject _projectile;

    private bool _isMouseClick = false;

    private Vector3 _firstMousePosition;
    private Vector3 _currentMousePosition;

    private Camera _mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        // instantiate projectile (will be changed based on the game procedure)
        // temporaly, I'll set the instantiate condition as spacebar input
        if ((Input.GetKeyDown(KeyCode.Space)) && (_projectile==null)){
            _projectile = Instantiate(projectilePrefab, _mainCamera.transform.position + _mainCamera.transform.forward - _mainCamera.transform.up * 0.2f, _mainCamera.transform.rotation);
            _projectile.transform.SetParent(transform);
        }

    }

}
