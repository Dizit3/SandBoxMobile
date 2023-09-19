using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HashSet<string> keys = new HashSet<string>();

    public event Action OnKeyAdded;

    public void AddKey(string keyID)
    {
        keys.Add(keyID);

        OnKeyAdded?.Invoke();
    }

    public bool HasKey(string keyID)
    {
        return keys.Contains(keyID);
    }
}