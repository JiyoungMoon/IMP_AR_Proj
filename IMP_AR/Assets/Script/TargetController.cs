using UnityEngine;

public enum TargetType
{
    Crate = 5,
    Treasure = 10
}

public class TargetController : MonoBehaviour
{
    public TargetType type;
}
