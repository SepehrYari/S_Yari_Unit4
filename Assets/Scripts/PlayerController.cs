using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float speed = 10.0f;
    GameObject FocalPoint;
    Renderer RendererPlayer;
    public float powerUpSpeed = 10.0f;
    public GameObject powerupind;

    bool hasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
        RendererPlayer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(FocalPoint.transform.forward * magnitude, ForceMode.Impulse);

        //Debug.Log("Mag: " + magnitude);
        //Debug.Log("FI: " + forwardInput);

        if (forwardInput > 0)
        {
            RendererPlayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        } 
        else
        {
            RendererPlayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }

        powerupind.transform.position = transform.position;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerupind.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(hasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("the Player has collid with " + collision.gameObject + "\n with powerup set to:" + hasPowerUp);
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - transform.position;


            rbEnemy.AddForce(awayDirection * powerUpSpeed, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerupind.SetActive(false);
    }


}
