using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyChasingState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    
    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        
    }

    public override void Tick(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            //Debug.Log("Out of range, stopping chase, returning to Idle state");
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }
        else if (IsInAttackingRange())
        {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }

        MoveToPlayer(deltaTime);
        FacePlayer();
        
        stateMachine.Animator.SetFloat(SpeedHash, 1f, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }
    
    private void MoveToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;
        Move(stateMachine.Agent.desiredVelocity.normalized * stateMachine.MovementSpeed, deltaTime);
        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }    
    private bool IsInAttackingRange()
    {
       float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
       return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }    
}