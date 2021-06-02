using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManageer : MonoBehaviour
{
    /// <summary>
    /// ��Ϸ����״̬
    /// </summary>
    public enum GameState
    {
        GameReady,
        Gaming,
        GameOver
    }

    /// <summary>
    /// ��ǰ��Ϸ����
    /// </summary>
    public GameState m_State;

    /// <summary>
    /// ��ʼ��ť
    /// </summary>
    public Button startBtn;

    /// <summary>
    /// ��Ϸ�Ʒְ�
    /// </summary>
    public GameObject scoreBoard;

    /// <summary>
    ///  С��
    /// </summary>
    public Rigidbody2D bird;

    /// <summary>
    ///  �ܵ�
    /// </summary>
    public GameObject pipe;

    /// <summary>
    /// ��Ϸ��ͣ״̬
    /// </summary>
    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        m_State = GameState.GameReady;

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case GameState.GameReady:

                break;
            case GameState.Gaming:
                bird.gravityScale = 800;

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
                {
                    bird.velocity = new Vector2(0, 2250);
                }

                if (bird.velocity.y > 0)
                    bird.rotation = 15.0f;
                else
                    bird.rotation = Mathf.Clamp(bird.velocity.y, -1800.0f, 0.0f) * 0.02f;
                break;
            case GameState.GameOver:
                bird.transform.GetComponent<Animation>().Stop();

                break;
        }
    }
}
