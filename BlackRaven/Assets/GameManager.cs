using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<MiniGameManager> miniGames;
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
}
