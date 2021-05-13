using Assets.Scripts.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemies.Eyes
{
    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField]
        private PatrolPoints[] _patrolPoints;

        private NavMeshAgent _navMeshAgent;

        private FiniteStateMachine fsm;

        private void Awake()
        {
            _navMeshAgent = this.GetComponent<NavMeshAgent>();
            fsm = this.GetComponent<FiniteStateMachine>();
        }

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public PatrolPoints[] PatrolPoints
        {
            get
            {
                return _patrolPoints;
            }
        }
    }
}