using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class collisions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text scoretext;
    [SerializeField] private float m_Thrust;

    void Start() { 
  
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "car 1(Clone)")
        {
            scoretext.text = (float.Parse(scoretext.text) + 1).ToString();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * m_Thrust);
            Vector3 p = collision.contacts[0].point;

            for (int i = 0; i < 33; i++)
            {
                
                scoretext.text = (float.Parse(scoretext.text) + 3).ToString();
                scoretext.fontSize = 85;
                yield return new WaitForSeconds(0.001f);
                scoretext.fontSize = 80;
                yield return new WaitForSeconds(0.001f);

            }
 
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
