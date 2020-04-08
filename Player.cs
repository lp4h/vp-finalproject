using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is the character controller for the player, also does animations for the player
public class Player : MonoBehaviour
{

    [SerializeField] private Generator terrainGenerator;
    private Animator animator;
    private bool isHopping; 
    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isHopping == false)
        {
            animator.SetTrigger("hop");
            isHopping = true;
            float zDifference = 0;
            if (transform.position.z % 1 != 0)  //this is if the player gets off the movement grid such as .1,.3,.8, etc. it will round up
            {
                zDifference = (transform.position.z - Mathf.Round(transform.position.z) - transform.position.z);
            }
            moveCharacter(new Vector3(1, 0, zDifference)); ; //make the player move along the z axis(Left and right)
        }
        else if (Input.GetKeyDown(KeyCode.A) && isHopping == false)
        {

            moveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && isHopping == false)
        {

            moveCharacter(new Vector3(0, 0, -1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Vehicle>() != null)
        {
            if (collision.collider.GetComponent<Vehicle>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }


    private void moveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);
        terrainGenerator.spawnTerrain(false, transform.position);
    }

    public void FinishHop()
    {
        isHopping = false;
    }

}
