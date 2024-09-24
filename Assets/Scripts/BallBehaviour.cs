using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBahaviour : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxHorizontalVelocity;
    private Vector3 _position, _scale, _paddlePosition, _paddleScale;
    void Start()
    {

    }

    void Update()
    {

        //Debug.Log(PaddleController.Instance.transform.position.x);
        _position = transform.position;
        _scale = transform.localScale;
        _paddlePosition = PaddleController.Instance.transform.position;
        _paddleScale = PaddleController.Instance.transform.localScale;

        if( //This one is for intersection
            _position.x + _scale.x /2f >= _paddlePosition.x - _paddleScale.x /2f &&
            _position.x - _scale.x /2f <= _paddlePosition.x + _paddleScale.x /2f &&
            _position.y + _scale.y /2f >= _paddlePosition.y - _paddleScale.y /2f &&
            _position.y - _scale.y /2f <= _paddlePosition.y + _paddleScale.y /2f)
            {
                //Debug.Log("Maybe we are intersecting");
                Velocity.y = -Velocity.y;
                Velocity.x = Random.Range(-MaxHorizontalVelocity, MaxHorizontalVelocity);
            }

        //This one is for bounce and walls
        if(_position.y > PaddleController.Instance.MaxPosition.transform.position.y)//Too High
            Velocity.y = -Velocity.y;
        if(_position.x > PaddleController.Instance.MaxPosition.transform.position.x || 
            _position.x < PaddleController.Instance.MinPosition.transform.position.x) //Walls
        {
            Velocity.x = -Velocity.x;
        }
        if(_position.y < PaddleController.Instance.MinPosition.transform.position.y)//Too Low
        {
            GameManager.Instance.BallOutofBounds(gameObject);
        }
            

        transform.position += Velocity * Time.deltaTime;
    }
        
}

