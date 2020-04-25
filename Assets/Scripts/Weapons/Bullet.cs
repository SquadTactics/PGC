using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public float DistanceShoot;
    public float BulletDamage;

    private Collider BulletCollider;

    void Start()
    {
        BulletCollider = gameObject.GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceShoot += transform.position.x * Time.deltaTime;
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
        if (DistanceShoot > 400f)
        {
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            Debug.Log("Bala Colidiu");
            other.gameObject.GetComponent<Teste>().CubeLife -= BulletDamage;
            Destroy(gameObject);
        }
    }
}
