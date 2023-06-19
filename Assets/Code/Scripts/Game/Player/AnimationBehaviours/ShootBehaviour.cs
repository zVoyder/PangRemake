namespace PangRemake.Player.Behaviours
{
    using UnityEngine;
    using PangRemake.Constants;
    using PangRemake.Managers;

    public class ShootBehaviour : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.s_Inputs.Player.Movement.Disable();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.s_Inputs.Player.Movement.Enable();
        }
    }
}