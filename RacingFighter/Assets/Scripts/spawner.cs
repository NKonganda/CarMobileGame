using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnie;
    [SerializeField] private GameObject car;
    private float totaltime = 0;
    private float lasttime = 0;
    // Start is called before the first frame update
    void Start()
    {
    
           
     

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totaltime += Time.deltaTime;
        if (totaltime > lasttime + 0.5)
        {
            totaltime = 0;
            lasttime = 0;
            float dist = 0;
            Vector3 spawnvector = new Vector3(0.0f,0.0f,0.0f);
            while (dist < 80)
            {
                spawnvector = new Vector3(car.transform.position.x + Random.Range(-200.0f, 200.0f), 1.5f, car.transform.position.z + Random.Range(-200.0f, 200.0f));
                dist = Vector3.Distance(spawnvector, car.transform.position);
            }
            

            transform.Rotate(0, Random.Range(0.0f, 360.0f), 0, Space.Self);
            var spawnrot = transform.rotation;
            var go = Instantiate(spawnie, spawnvector, spawnrot);
        
        }

    }
}
