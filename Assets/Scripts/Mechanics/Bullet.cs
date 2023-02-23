using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private float lifeloose;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private GameObject casquillo;
    //Audio
    [SerializeField] private GameObject onMiss;
    [SerializeField] private GameObject onHit;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Route();
        lifetime -= lifeloose * Time.deltaTime;
        if (lifetime < 1)
        {
            BulletDestruction();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Life_Controller>() != null)
        {
            Instantiate(onHit);
            collision.gameObject.GetComponent<Life_Controller>().BeingDamaged(damage);
        }
        else
        {
            Instantiate(onMiss);
        }
        BulletDestruction();
    }
    private void BulletDestruction()
    {
        Destroy(gameObject);
        Instantiate(casquillo, gameObject.transform);
    }
    private void Route()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }
}
