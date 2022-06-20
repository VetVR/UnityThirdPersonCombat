using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int SpeedHash = Animator.StringToHash("Speed");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            //Debug.Log("In Range");
            //Debug.Log("Entering Chase State and giving chase...");
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }
        
        FacePlayer();
        
        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() { }
}
