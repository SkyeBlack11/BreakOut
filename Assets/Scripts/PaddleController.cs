using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public Color PressedColor;
    public Vector3 StartPosition, StartScale;
    private Color _startColor;
    public float Speed;
    public Transform MinBounds, MaxBounds; //let’s re-use those handy min and max bounds variables (1.4 walls)
    //public GameObject MaxPositionX, MinPositionX;
    public static PaddleController Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _startColor = GetComponent<SpriteRenderer>().color;
        transform.position = StartPosition;
        transform.localScale = StartScale;    
    
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x - StartScale.x /2f > MinPositionX.transform.position.x){
            transform.position += Vector3.left * Time.deltaTime * Speed;

        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x + StartScale.x /2f < MaxPositionX.transform.position.x){
            transform.position += Vector3.right * Time.deltaTime * Speed;

        }

        if (Input.GetKeyDown(KeyCode.Space)){
            GetComponent<SpriteRenderer>().color = PressedColor;
            Debug.Log("Hello");
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            GetComponent<SpriteRenderer>().color = _startColor;
        }
    
        //Pseudo Code if(BallPosition >= Left Wall || BallPosition <= Right Wall){ HoriVelocity = 0-HoriVelocity}
        //if(BallPosition >= MaxBound.y){Velocity = 0-Velocity}
    }
}
