﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FSM.States
{
    [CreateAssetMenu(fileName = "Chase State", menuName = "Horror/States/Chase", order = 2)]
    public class ChaseState : AbstractState
    {
        private GameObject player;
        public float chaseRadius;
        private float playerDistance;

        public void OnEnable()
        {
            base.OnEnable();
            player = GameObject.FindGameObjectWithTag("player");
            StateType = FSMStateType.CHASING;
        }

        public override bool EnterState()
        {
            EnterdState = false;
            if (base.EnterState())
            {
                playerDistance = Vector3.Distance(_navMeshAgent.transform.position, player.transform.position);
                if (playerDistance <= chaseRadius)
                {
                    Chase(player.transform.position);
                    EnterdState = true;
                }
            }

            return EnterdState;
        }

        public override void UpdateState()
        {
            if (EnterdState)
            {
                playerDistance = Vector3.Distance(_navMeshAgent.transform.position, player.transform.position);
                if (playerDistance <= chaseRadius)
                {
                    Chase(player.transform.position);
                }
                else
                {
                    _fsm.EnterState(FSMStateType.IDLE);
                }
            }
        }

        private void Chase(Vector3 playePostion)
        {
            if (_navMeshAgent != null && playePostion != null)
            {
                _navMeshAgent.SetDestination(playePostion);
            }
        }
    }
}