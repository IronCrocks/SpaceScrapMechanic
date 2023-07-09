using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShipBehavior : MonoBehaviour
{
    public GameObject onDestroyEffect;
    public GameObject onDestroySound;

    private PlayerLevelUp playerScript;
    private GameObject _gameOverMenu;

    private void Awake()
    {
        _gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
        _gameOverMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponentInParent<PlayerLevelUp>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //  в чем разница между тригерентер и коллизионЕнтер. разница коолидер и коллизион(сигнатуры?)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            Instantiate(onDestroyEffect, transform.position, Quaternion.identity);
            Instantiate(onDestroySound, transform.position, Quaternion.identity);
            Destroy(transform.gameObject);
            _gameOverMenu.SetActive(true);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Loot"))
        {
            if (collision.gameObject.CompareTag("Relict"))
            {
                GameData.RelictCrystalsCount++;
            }
            else
            {
               playerScript.expirienceCount++;
            }

            Destroy(collision.gameObject);
        }
    }
}
