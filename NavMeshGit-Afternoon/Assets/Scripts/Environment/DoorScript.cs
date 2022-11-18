using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
 [SerializeField] public bool shouldMoveUp = false;
 [SerializeField] public Collider collider;
 [SerializeField] public bool locked;

  private void OnTriggerEnter(Collider collider)
  {
    //If we collide and the door is not a specially locked door, then open.
    if (collider.name == "Player" & !locked)
    {
      Debug.Log("Door opening.");
      shouldMoveUp = true;
    }
    else
    {
      shouldMoveUp = false;
    }
  }

  private void Update()
  { //If player is within range and the door is not locked, open up!
    if (shouldMoveUp && !locked)
    {
      Debug.Log("Door opening!!!");
      transform.position += new Vector3(0, 1 * Time.deltaTime, 0);
    }
  }
  //Utility function for when player unlocks all keys
  public void UnlockAll()
  {
    locked = false;
    shouldMoveUp = true;
  }
}