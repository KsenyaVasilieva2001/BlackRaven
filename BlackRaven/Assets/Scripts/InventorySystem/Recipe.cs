using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Alchemy/Recipe")] 
public class Recipe : ScriptableObject
{
    [SerializeField] private List<Item> requiredItems;
    [SerializeField] private Item resultItem;
    [SerializeField] private Action onCompleted;

    public bool IsMatch(List<Item> inputItems)
    {
        return inputItems.OrderBy(x => x).SequenceEqual(requiredItems.OrderBy(x => x));
    }
}
