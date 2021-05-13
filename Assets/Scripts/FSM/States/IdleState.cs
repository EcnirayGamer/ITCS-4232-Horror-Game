using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FSM.States
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "Horror-FSM/States/Idel", order = 1)]
    public class IdleState : AbstractState
    {
        public override bool EnterState()
        {
            base.EnterState();
            Debug.Log("Entered Idle State");

            return true;
        }

        public override void UpdateState()
        {
            Debug.Log("Updating Idel State");
        }

        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("Exiting Idle State");

            return true;
        }
    }
}