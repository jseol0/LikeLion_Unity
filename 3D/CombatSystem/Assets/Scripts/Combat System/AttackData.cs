using UnityEngine;

[CreateAssetMenu(menuName = "Combat Systam/Create a new Attack")]
public class AttackData : ScriptableObject
{
    [field: SerializeField] public string animName { get; private set; }
    [field: SerializeField] public float impactStartTime { get; private set; }
    [field: SerializeField] public float impactEndTime { get; private set; }

}
