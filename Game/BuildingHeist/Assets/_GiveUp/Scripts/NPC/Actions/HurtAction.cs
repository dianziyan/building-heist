//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace GiveUp.Core
{
    public class HurtAction : ActionBase
		{

            public float hurtSpeed;
            NpcMovement _movementManager;
            NpcCore _npc;
			ActionTimer _hurtTimer;
            public float HurtTime
            {
                get
                {
                    return _hurtTimer.TimeLimit;
                }
                set
                {
                    _hurtTimer.TimeLimit = value;
                }

            }
            public HurtAction(NpcCore npc,  NpcMovement movementManager, float hurtTime, float speed)
	        {
                hurtSpeed = speed;
				_npc = npc;
                _movementManager = movementManager;
				_hurtTimer = new ActionTimer(hurtTime, HurtExpire);
			}
			
			void HurtExpire()
			{
                this.EndAction();

	        }

			public override void Update()
			{
                if (IsActionHappening)
                {
                    _hurtTimer.Update();
                }
			}

            public override void StartAction()
            {
                _movementManager.SetSpeed(hurtSpeed);
                _hurtTimer.Reset();
                _hurtTimer.Start();

                base.StartAction();
            }

		}
}
