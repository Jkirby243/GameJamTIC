using UnityEngine;
[CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Bullet trail config", order = 1)]
public class BulletEffects : ScriptableObject
{
    public Material Material;
    public AnimationCurve WidthCurve;
    public float Duration = 0.5f;
    public float MinVertexDistance = 0.1f;
    public Gradient color;

    public float MissDistance = 100f;
    public float SimulationSpeed = 100f;
}
