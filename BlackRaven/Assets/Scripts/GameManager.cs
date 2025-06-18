using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<MiniGameManager> miniGames;
    public bool IsInit;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool IsAnyMiniGameIsOn()
    {
        return miniGames.Any(mg => mg.gameObject.activeInHierarchy);
    }

    public void ActivateMiniGame(MiniGameManager miniGame)
    {
        if (miniGames.Contains(miniGame))
        {
            Debug.Log("YEs");
            miniGame.gameObject.SetActive(true);
            IsInit = true;
        }
        else
        {
            Debug.Log("Попытка активировать мини-игру, которая не входит в список GameManager.");
        }
    }

    public void DeactivateMiniGame(MiniGameManager miniGame)
    {
        if (miniGames.Contains(miniGame))
        {
            miniGame.gameObject.SetActive(false);
            IsInit = false;
        }
        else
        {
            Debug.LogWarning("Попытка деактивировать мини-игру, которая не входит в список GameManager.");
        }
    }
    
    public void ActivateMiniGame()
    {
        miniGames[0].gameObject.SetActive(true);
        //miniGames[0].IsInit = true;
        IsInit = true;
    }

    public void DeactivateMiniGame()
    {
        miniGames[0].gameObject.SetActive(false);
        //miniGames[0].IsInit = false;
        IsInit = false;
    }
}
