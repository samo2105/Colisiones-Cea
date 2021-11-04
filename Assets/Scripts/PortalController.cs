using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] bool isColliding = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerExit()
    {
        isColliding = false;
    }

    void OnTriggerStay(Collider col)
    {
        if (isColliding) return;
        isColliding = true;
        if (col.tag == "Player")
        {
            player.GetComponent<PlayerController>().ModifySize();
        }
    }

}
