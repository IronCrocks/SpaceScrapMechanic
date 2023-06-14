using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public GameObject shoot_effect;
    public GameObject hit_effect;
    public GameObject shipScrap;
    public GameObject relictShipScrap;

    // Use this for initialization
    private void Start()
    {
        //GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 1), Quaternion.identity); //Spawn muzzle flash
        //obj.transform.parent = firing_ship.transform;
        //Destroy(gameObject, 5f); //Bullet will despawn after 5 seconds
    }

    // Update is called once per frame
    private void Update()
    {

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
