using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager> {

    [Header("Player")]
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float duration = .5f;
    [SerializeField] float delay = .5f;
    [SerializeField] Ease playerEase = Ease.OutBack;

    private GameObject _currentPlayer;

    void Start() {
        SpawnPlayer();    
    }

    void SpawnPlayer() {
        _currentPlayer = Instantiate(playerPrefab);
        _currentPlayer.transform.position = spawnPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetDelay(delay).SetEase(playerEase).From();
    }

}
