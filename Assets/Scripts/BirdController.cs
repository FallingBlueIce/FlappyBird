using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    private GameManager mgr;

    private void OnEnable()
    {
        mgr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        mgr.status = GameManager.GameState.GameOver;
        mgr.GameOver.SetActive(true);
        mgr.Gaming.SetActive(false);
        mgr.scoreEndGame.text = mgr.score.ToString();
        mgr.bestScoreEndGame.text = mgr.bestScore.ToString();
        Time.timeScale = 0.0f;
        Debug.Log("hit");
    }
}
