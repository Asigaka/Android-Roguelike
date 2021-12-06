using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Menu, Pause, Playing}
public class GameStatesManager : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private GameObject playerObj;

    private bool _isPlaying;

    public static GameStatesManager Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;
    }

    private void Start()
    {
        ChangeState(GameState.Menu);
    }

    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                _isPlaying = false;
                gameObj.SetActive(false);
                playerObj.SetActive(false);
                Time.timeScale = 1;
                break;
            case GameState.Pause:
                _isPlaying = false;
                gameObj.SetActive(true);
                playerObj.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                gameObj.SetActive(true);
                playerObj.SetActive(true);

                if (_isPlaying)
                {

                }

                break;
        }
    }
}
