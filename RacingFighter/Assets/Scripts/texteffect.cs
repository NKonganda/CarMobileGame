using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class texteffect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text scoretext;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(float.Parse(scoretext.text) % 100);
        if (float.Parse(scoretext.text) % 100 == 0.0f)
        {
            scoretext.fontSize = 100;
            wait();
            scoretext.fontSize = 80;
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
