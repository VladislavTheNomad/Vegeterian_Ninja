using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager manager;
    private Rigidbody targetRb;
    public int valueScore;
    public ParticleSystem explosion;


    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        if (!gameObject.CompareTag("Bad"))
        {
            targetRb.AddForce(Vector3.up * Random.Range(12f, 16f), ForceMode.Impulse);
            transform.position = new Vector3(Random.Range(-4.5f, 4.5f), -2f, 0);
            targetRb.AddTorque(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        }
        else { 
            transform.position = new Vector3(Random.Range(-4.5f, 4.5f), -4f, 0);
            targetRb.AddForce(Vector3.up * Random.Range(14f, 16f), ForceMode.Impulse);
            targetRb.AddTorque(new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(manager.isGameActive)
        {
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(gameObject);
            manager.UpdateScore(valueScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            manager.GameOverMenu();
        }
        Destroy(gameObject);
     
    }
}

