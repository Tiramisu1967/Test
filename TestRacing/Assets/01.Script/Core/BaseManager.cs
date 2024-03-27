using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [HideInInspector] public GameManager _gameManager;
    public virtual void init(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
}
