 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  [SerializeField] public Camera camera;
  [SerializeField] public UnityEngine.AI.NavMeshAgent agent;
  [SerializeField] public DoorScript[] doors;
  [SerializeField] public Animator animator;
  public int score = 0;
  public Vector3 targetLocation;
  public int keyCount = 0;
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      //If mouse is clicked, raycast to the click position.
      Ray ray = camera.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      //If click was valid, move the player agent to the location.
      if (Physics.Raycast(ray, out hit))
      {
        agent.SetDestination(hit.point);
        animator.SetBool("IsMoving", true);
        hit.point = targetLocation;
      }

      if (Vector3.Distance(transform.position, hit.point) < 10)
      {
        animator.SetBool("IsMoving", false);
      }
    }
  }

  public void AddKey()
  {
    //Increment key count
    keyCount += 1;
    Debug.Log("Key count:" + keyCount);
    //If two keys are collected, you win!
    if (keyCount >= 2)
    {
      Debug.Log("Keys collected!");
      UnlockDoors();
    }
  }

  //Unlock all locked doors
  public void UnlockDoors()
  {
    foreach (DoorScript door in doors)
    {
      door.UnlockAll();
    }
  }

  public void AddScore(int amount)
  {
    score += amount;
    Debug.Log("Score: " + score);
  }
}
