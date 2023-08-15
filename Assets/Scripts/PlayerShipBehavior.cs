using UnityEngine;

public class PlayerShipBehavior : MonoBehaviour
{
    public GameObject onDestroyEffect;
    public GameObject onDestroySound;

    private PlayerLevelUp _playerScript;
    private GameObject _gameOverMenu;

    private void Awake()
    {
        _gameOverMenu = GameObject.FindGameObjectWithTag("GameOverMenu");
        _gameOverMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GetComponentInParent<PlayerLevelUp>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //  в чем разница между тригерентер и коллизионЕнтер. разница коолидер и коллизион(сигнатуры?)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Loot"))
        {
            if (collision.gameObject.CompareTag("Relict"))
            {
                _playerScript.CrystalsManager.AddOne();
            }
            else
            {
                _playerScript.expirienceCount++;
            }

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemies"))
        {
            Instantiate(onDestroyEffect, transform.position, Quaternion.identity);
            Instantiate(onDestroySound, transform.position, Quaternion.identity);
            _gameOverMenu.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            Progress.Instance.Save();
        }
    }
}
