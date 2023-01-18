using UnityEngine;

namespace Script.Player
{
    public class PlayerIdleState : PlayerBaseState
    {
        
        public PlayerIdleState(PlayerMotor playerMotor) : base(playerMotor)
        {
            
        }
        
        public override void InitializeState()
        {
            
            PlayerMotor.ChangeAnimation(PlayerStates.IDLE);
            
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            
        }

        protected override void CheckSwitchState()
        {

            if (PlayerMotor._currentDirection != Vector2.zero)
            {
                PlayerMotor.ChangePlayerState(PlayerStates.WALK);
            }
            
        }

        public override void ExitState()
        {
            
        }

    }
}