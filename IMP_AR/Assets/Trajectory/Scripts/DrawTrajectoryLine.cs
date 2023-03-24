using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectoryLine : MonoBehaviour
{

    
    private float Power = 3f;

    private Vector3 normalVector;
    private Vector3 unitDirection;

    private Vector3 throwVector;
    private bool isThrowStone = false;

    private Transform parabolaTop;
    private Transform parabolaBottom;


    public GameObject Stone;
    private GameObject ChildStone;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
    }

    private void OnDrawGizmosSelected() {

        if (Input.GetMouseButton(0)){
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position,transform.position+throwVector);
        }
    }
    
}
