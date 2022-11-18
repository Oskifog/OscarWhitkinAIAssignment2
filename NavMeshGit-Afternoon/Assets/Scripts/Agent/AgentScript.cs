using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentScript : MonoBehaviour
{
  [SerializeField] public UnityEngine.AI.NavMeshAgent agent;
  public int keyCount = 0;
  private bool seesPlayer;
  [SerializeField] public PlayerScript playerScript;
  [SerializeField] public Transform player;
  [SerializeField] public Transform[] waypoints;
  [SerializeField] public Animator animator;
  [SerializeField] public Rigidbody rigidbody;
  [SerializeField] public int chaseDistance = 10;
  [SerializeField] public int captureDistance = 3;
  private int targetWaypointIndex;
  [SerializeField] Collider collider;

  void Update()
  {
    IsPlayerNearby();
    //If player is sighted, change agenda to chase them
    if (seesPlayer)
    {
      ChasePlayer();
    }
    else //Otherwise, move to target waypoint
    {
      agent.SetDestination(waypoints[targetWaypointIndex].position);
    }
    IsAtWaypoint();
    if (rigidbody.velocity.x > 0)
    {
      animator.SetBool("IsMoving", true);
    }
  }

  private void IsAtWaypoint()
  { //If the agent is close enough, change target to the next waypoint
    if (Vector3.Distance(transform.position, waypoints[targetWaypointIndex].position) < 5)
    {
      int nextIndex = targetWaypointIndex + 1;
      ChangeTargetWaypoint(nextIndex);
    }
  }

  //Allows changing of the target waypoint
  public void ChangeTargetWaypoint(int newIndex)
  {
    //If we've reached the end of the waypoints, reset to the beginning.
    if (newIndex >= 4)
    {
      newIndex = 1;
    }
    targetWaypointIndex = newIndex;
  }

  private void IsPlayerNearby()
  { //If player is within a certain distance, give chase!
    if (Vector3.Distance(transform.position, player.position) < 2)
    {
      Application.Quit();
    }
    else if (Vector3.Distance(transform.position, player.position) < 10)
    {
      seesPlayer = true;
    } //If on top of player, kill player and end the game.
    else
    { //Otherwise, the agent is out of range.
      seesPlayer = false; 
    }
  }

  public void ChasePlayer()
  {
    agent.SetDestination(player.position);
  }
}