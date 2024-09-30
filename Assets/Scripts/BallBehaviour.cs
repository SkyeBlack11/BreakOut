using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBahaviour : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxHorizontalVelocity;

    void Update()
    {
        if (CollidesWithGameObject(PaddleController.Instance.gameObject))
        {
            Velocity.y = -Velocity.y;
            Vector3 PaddleToBall = transform.position - PaddleController.Instance.transform.position;
            Velocity.x = PaddleToBall.x * MaxHorizontalVelocity;
        }
        for(int i = 0; i < GameManager.Instance.Bricks.Length; i++)
        {
            if (GameManager.Instance.Bricks[i] && CollidesWithGameObject(GameManager.Instance.Bricks[i]))
            {
                Destroy(GameManager.Instance.Bricks[i]);
                GameManager.Instance.Bricks[i] = null;
                Velocity.y = -Velocity.y;
                GameManager.Instance.CheckForWin(gameObject);
                break;
            }
        }

        //This one is for bounce and walls
        if (transform.position.y > PaddleController.Instance.MaxPosition.transform.position.y)//Too High
            Velocity.y = -Velocity.y;
        if (transform.position.x > PaddleController.Instance.MaxPosition.transform.position.x ||
            transform.position.x < PaddleController.Instance.MinPosition.transform.position.x) //Walls
        {
            Velocity.x = -Velocity.x;
        }
        if (transform.position.y < PaddleController.Instance.MinPosition.transform.position.y)//Too Low
        {
            GameManager.Instance.BallOutofBounds(gameObject);
        }


        transform.position += Velocity * Time.deltaTime;
    }

    private bool CollidesWithGameObject(GameObject other)
    {
        return
        transform.position.x + transform.localScale.x / 2f >= other.transform.position.x - other.transform.localScale.x / 2f &&
        transform.position.x - transform.localScale.x / 2f <= other.transform.position.x + other.transform.localScale.x / 2f &&
        transform.position.y + transform.localScale.y / 2f >= other.transform.position.y - other.transform.localScale.y / 2f &&
        transform.position.y - transform.localScale.y / 2f <= other.transform.position.y + other.transform.localScale.y / 2f;
    }
        
}

