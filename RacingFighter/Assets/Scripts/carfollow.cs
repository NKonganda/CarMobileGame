using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carfollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject follow;
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = follow.transform.position;
        transform.rotation = follow.transform.rotation;
        transform.GetComponent<Rigidbody>().velocity = follow.gameObject.GetComponent<Rigidbody>().velocity;
    }
}
