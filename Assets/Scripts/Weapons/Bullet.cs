using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedBullet;
    public float damageBullet;
    public float distanceBullet;

    private float currentDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.forward * speedBullet * Time.deltaTime, Space.World);
        currentDistance = Vector3.Magnitude(transform.position);
        if (currentDistance > distanceBullet)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().lifePlayer -= damageBullet;
            Destroy(gameObject);
        }
    }
}
