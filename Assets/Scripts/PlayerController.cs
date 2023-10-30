using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float speed = 10.0f;
    GameObject FocalPoint;
    Renderer RendererPlayer;

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

        Debug.Log("Mag: " + magnitude);
        Debug.Log("FI: " + forwardInput);

        if (forwardInput > 0)
        {
            RendererPlayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        } 
        else
        {
            RendererPlayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
        
    }
}
