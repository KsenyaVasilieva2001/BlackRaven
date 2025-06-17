using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Recipe, Ingredient }

[CreateAssetMenu(menuName = "Alchemy/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject prefab;
    [SerializeField] private string title;
    [SerializeField] private string description;
    [SerializeField] private ItemType type;

    public Sprite Icon => icon;
    public GameObject Prefab => prefab;
    public string Title => title;
    public string Description => description;
    public ItemType Type => type;
}
