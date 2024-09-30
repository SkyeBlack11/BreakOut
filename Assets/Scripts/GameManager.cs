using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject BallPrefab;
    public GameObject[] Bricks;
    public float RespawnTimer;
    [HideInInspector] public bool GameRunning;
    [SerializeField] private GameObject _failurePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _ballText;
    [SerializeField, Range(0, 10)] private int _maxRespawns;
    private int _respawnCount = 0;


    void Start()
    {
        _failurePanel.SetActive(false);
        _winPanel.SetActive(false);
        GameRunning = true;
        Instantiate(BallPrefab);
        UpdateBallText();
        Instance = this;
        
    }
    void Update()
    {
    }

    public void BallOutofBounds(GameObject ball)
    {
        Destroy(ball);
        if (_respawnCount < _maxRespawns)
        {
            StartCoroutine(WaitandRespawn());
        }
        else
        {
            GameRunning = false;
            _failurePanel.SetActive(true);
        }
    }

    public void CheckForWin(GameObject ball)
    {
        foreach (GameObject brick in Bricks)
        {
            if (brick != null) return; 
        }
        GameRunning = false;
        Destroy(ball);
        _winPanel.SetActive(true);
        //Debug.LogWarning("Hurray!");
    }

    private IEnumerator WaitandRespawn()
    {
        yield return new WaitForSeconds(RespawnTimer);
        GameObject ballObject = Instantiate(BallPrefab);
        _respawnCount += 1;
        UpdateBallText();
        
    }

    private void UpdateBallText()
    {
        _ballText.text = "Balls Remaining: " + (_maxRespawns - _respawnCount) + "/" + _maxRespawns +"";
    }
}
