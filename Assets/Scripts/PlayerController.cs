using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool wasShrinked = false;
    [SerializeField] private float sizeModify = 0.8f;
    [SerializeField] float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void ModifySize()
    {
        if (!wasShrinked)
        {
            transform.localScale = new Vector3(sizeModify, sizeModify, sizeModify);
        } 
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        wasShrinked = !wasShrinked;
    }

    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Translate the object
        transform.Translate(-z, 0, x);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.collider.name;
        bool isPortal = name == "Warp";
        Debug.Log($"Name: {name} - Is Shrinker?: {isPortal}");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Portal")
        {
            Debug.Log($"Name: {col.name} - Is Shrinker?: {true}");
        }
    }
}
