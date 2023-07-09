using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hit_effect;
    public GameObject shipScrap;
    public GameObject relictShipScrap;

    // Use this for initialization
    private void Start()
    {
        Destroy(gameObject, 3f); //Bullet will despawn
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if (col.gameObject.layer != LayerMask.NameToLayer("Enemies"))
        {
            return;
        }

        Instantiate(hit_effect, transform.position, Quaternion.identity);
        var position = col.gameObject.transform.position;

        Destroy(col.gameObject);
        Destroy(gameObject);

        var shipScrapGameObject = Instantiate(Random.value < 0.1f ? relictShipScrap : shipScrap);
        shipScrapGameObject.transform.position = position;
    }
}
