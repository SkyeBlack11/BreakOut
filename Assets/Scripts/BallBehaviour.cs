using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBahaviour : MonoBehaviour
{
    public float VerticalSpeed; //Renamed to make it's purpose clearer
    private float _maxHorizontalSpeed; //Add new float, TODO:give it a range???
    public static float Range(0-_maxHorizontalSpeed,_maxHorizontalSpeed); //Generate a random velocity
    private Vector3 _velocity;


    // Start is called before the first frame update
    void Start()
    {
        _velocity = Vector3.down;
        _velocity = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    private static _paddle;
    public static PaddleSize; //It's angry with the ";" ??
    void Update()
    {
        _paddle = PaddleController.Instance;
        PaddleSize = transform.localScale;

        if (transform.position.x + PaddleSize.x
            >= _paddle.transform.position.x - _paddle.PaddleSize.x / 2f){
            //Debug.Log("Circle in Rectangle"); //I think the if statement is a bit broken cause this prints when the ball hasn't even moved
            transform.position += newVector3(_velocity.x, _velocity.y * VerticalSpeed) * Time.deltaTime; //Break up _velocity * Speed
            _velocity = 0 - _velocity; // set the ball’s vertical velocity to negative its current value TODO: give random horizontal velocity (x)
        }
        
    }
}
