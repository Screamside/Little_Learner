using UnityEngine;

namespace Script.Player
{
    public class PlayerWalkState : PlayerBaseState
    {
        
        public PlayerWalkState(PlayerMotor playerMotor) : base(playerMotor)
        {
        }
        
        public override void InitializeState()
        {
            
            PlayerMotor.ChangeAnimation(PlayerStates.WALK);
            
        }

        public override void UpdateState()
        {
            CheckSwitchState();
        }

        public override void FixedUpdateState()
        {
            
            PlayerMotor.MovePlayer(PlayerMotor.MaxWalkSpeed);
            
        }

        protected override void CheckSwitchState()
        {

            if (PlayerMotor._currentDirection == Vector2.zero)
            {
                PlayerMotor.ChangePlayerState(PlayerStates.IDLE);
            }
            
        }

        public override void ExitState()
        {
            
        }
    }
}