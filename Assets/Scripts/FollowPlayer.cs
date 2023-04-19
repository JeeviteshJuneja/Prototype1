using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset1 = new Vector3(0, 7, -10);
    private Vector3 offset2 = new Vector3(0, 5, 0);
    private bool firstPerson = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstPerson = !firstPerson;
        }
        //offset camera position
        if (firstPerson)
        {
            transform.position = player.transform.position + offset2;
        }
        else
        {
            transform.position = player.transform.position + offset1;
        }
    }
}
