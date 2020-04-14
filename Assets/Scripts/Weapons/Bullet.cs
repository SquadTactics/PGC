using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public int BulletDamage;

    private Collider BulletCollider;

    void Start()
    {
        BulletCollider = gameObject.GetComponentInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
        Destroy(gameObject, 5f);
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
