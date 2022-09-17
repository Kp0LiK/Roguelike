using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private Transform _respawn;
    [SerializeField] private GameObject _playerPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        Instantiate(_playerPrefab, _respawn.position, Quaternion.identity);
    }
}
