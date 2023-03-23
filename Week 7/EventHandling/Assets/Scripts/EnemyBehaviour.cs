using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject playerGameObject;
    private float CurrentSpeed = 0;

    void OnEnable()
    {
        Messenger.AddListener(GameEvent.MOVE_ENEMIES, OnMoveEnemy);
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.MOVE_ENEMIES, OnMoveEnemy);
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnMoveEnemy()
    {
        Vector3 directionTowardPlayer = playerGameObject.transform.position - gameObject.transform.position;
        Vector3 directionInXandZ = new Vector3(directionTowardPlayer.x, 0, directionTowardPlayer.z);
        Vector3 oneUnitTowardsPlayer = Vector3.Normalize(directionInXandZ);
        Vector3 enemyDisplacement = CurrentSpeed * oneUnitTowardsPlayer;
        transform.Translate(enemyDisplacement);
    }

    private void OnSpeedChanged(float newSpeed)
    {
        this.CurrentSpeed = newSpeed;
    }
}
