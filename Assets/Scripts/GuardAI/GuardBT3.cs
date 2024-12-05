using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using Tree = BehaviorTree.Tree;

public class GuardBT3 : Tree
{
    public Transform[] waypoints;
    public Transform SphereDeposit;

    public float speed = 2f;
    public static float fovRange = 7.5f;
    public static float attackRange = 2f;
    public static float DetectObjRange = 5f;
    public static float GrabRange = 1f;
    public NavMeshAgent agent;
    private float tempspeed;

    protected override Node SetupTree()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        Node root = new Selector(new List<Node>
        {
            #region SphereSelector
            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new Hassphere(),
                    new MoveToDeposit(transform, SphereDeposit, agent),
                    new Deposit(transform), 
                }),
                new Sequence(new List<Node>
                {
                    new CheckOBJinGrabRange(transform, GrabRange),
                    new GrabObject(transform),
                }),
                new Sequence (new List<Node>
                {
                    new CheckOBJinRange(transform, DetectObjRange),
                    new ApproachObject(transform, agent),
                }),
            }),
            #endregion
            #region SkelAndPatrol
            new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    //new DebugNode("attack"),
                    new CheckEnemyInAttackRange(transform, attackRange),
                    new TaskAttack(transform),
                    new DebugNode("attack"),
                }),
                new Sequence(new List<Node>
                {
                    //new DebugNode("chase"),
                    new CheckEnemyInFOVRange(transform, fovRange,"Enemy"),
                    new TaskGoToTarget(transform, speed*2, agent),
                }),
                //new DebugNode("patrol"),
                new TaskPatrol2(transform, waypoints, speed, agent),
            })
            #endregion
        });

        return root;
    }

    #region Function
    public void ReduceSpeed(float percent, float time)
    {
        StartCoroutine(ReduceSpeedCoroutine(percent, time));
    }


    public IEnumerator ReduceSpeedCoroutine(float percent, float time)
    {
        tempspeed = speed;

        agent.speed *= percent;
        yield return new WaitForSeconds(time);
        agent.speed /= percent;
    }
    #endregion
}
