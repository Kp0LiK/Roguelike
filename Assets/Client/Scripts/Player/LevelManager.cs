using System;
using System.Collections;
using System.Collections.Generic;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private bool _isActive;

    private Collider2D _collider;
    private Vector2 _respawnPoint;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        SetRespawnPoint(transform.position);
    }

    private void Update()
    {
        if (!_isActive)
            return;
    }

    public void Die()
    {
        _isActive = false;
        _collider.enabled = false;
        StartCoroutine(Respawn());
    }

    public void SetRespawnPoint(Vector2 position)
    {
        _respawnPoint = position;
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        transform.position = _respawnPoint;
        _isActive = true;
        _collider.enabled = true;
    }
}
