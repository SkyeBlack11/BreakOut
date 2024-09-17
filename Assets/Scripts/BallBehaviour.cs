using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBahaviour : MonoBehaviour
{
    public float Speed;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _velocity = Vector3.down;
        _velocity = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.localScale.x
            >= PaddleController.Instance.transform.position.x - PaddleController.Instance.transform.localScale.x/ 2f){
            Debug.Log("Circle in Rectangle");
            //transform.position += _velocity * Speed * Time.deltaTime;
        }
        
    }
}
