using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 13, maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -4;
    private float random_X_Torque, random_Y_Torque, random_Z_Torque; 
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private int pointValue;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        random_X_Torque = RandomTorque();
        random_Y_Torque = RandomTorque(); 
        random_Z_Torque = RandomTorque();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(random_X_Torque, random_Y_Torque, random_Z_Torque, ForceMode.Impulse);
        
        transform.position = RandomSpawnPos();
    }

    void Update()
    {

    }
    private void OnMouseDown() {

        if(gameManager.GetIsGameActive())
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
