using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Weapon Config", menuName = "Guns/Gun", order = 0)]
public class Gun : ScriptableObject
{
    public Weapon Name;
    public int Maxammo;
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    public GameObject ModelPrefab;
    public int reloadCount;
    public int damage;
    public BulletEffects BulletEffects;
    private Transform PartPos;

    public float Fireingspeed;
    public Vector3 Spread;
    private int ammocount;
    private int hitdamage;
    private float lastShot;
    private GameObject Model;
    private MonoBehaviour ActiveMono;
    private ObjectPool<TrailRenderer> objectPool;


    public void Spawn(Transform Parent, Transform Patpos, MonoBehaviour ActiveMono)
    {
        this.ActiveMono = ActiveMono;
        lastShot = 0;
        //objectPool = new ObjectPool<TrailRenderer>(CreateTrail);
        //PartPos = Patpos;
        ammocount = Maxammo;
        Model = Instantiate(ModelPrefab);
        Model.transform.SetParent(Parent, false);
        Model.transform.localPosition = SpawnPoint;
        Model.transform.localRotation = Quaternion.Euler(SpawnRotation);
        hitdamage = damage;
    }

    //private IEnumerator PlayTrail(Vector3 Start, Vector3 end, RaycastHit Hit)
    //{
    //    TrailRenderer instance = objectPool.Get();
    //    instance.gameObject.SetActive(true);
    //    instance.transform.position = Start;
    //    yield return null;

    //    instance.emitting = true;

    //    float distance = Vector3.Distance(Start, end);
    //    float remainingDistance = distance;
    //    while(remainingDistance > 0)
    //    {
    //        instance.transform.position = Vector3.Lerp(Start, end, Mathf.Clamp01( 1 - (remainingDistance / distance)));
    //        remainingDistance -= BulletEffects.SimulationSpeed * Time.deltaTime;
    //    }

    //    instance.transform.position = end;

    //    if(Hit.collider != null)
    //    {
    //        //Hit.transform.gameObject
    //    }

    //    yield return new WaitForSeconds(BulletEffects.Duration);
    //    yield return null;
    //    instance.emitting = false;
    //    instance.gameObject.SetActive(false);
    //    objectPool.Release(instance);
    //}
    //private TrailRenderer CreateTrail()
    //{
    //    GameObject instance = new GameObject("Bullet Trail");
    //    TrailRenderer trail = instance.AddComponent<TrailRenderer>();
    //    trail.colorGradient = BulletEffects.color;
    //    trail.material = BulletEffects.Material;
    //    trail.minVertexDistance = BulletEffects.MinVertexDistance;

    //    trail.emitting = false;
    //    trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    //    return trail;
    //}

    public void Fire()
    {
        if(Time.time > Fireingspeed + lastShot && ammocount != 0)
        {
            --ammocount;
            lastShot = Time.time;
            Vector3 accuracy = Camera.main.transform.forward +
                    new Vector3(Random.Range(-Spread.x, Spread.x), Random.Range(-Spread.y, Spread.y), Random.Range(-Spread.z, Spread.z));
            accuracy.Normalize();
            Debug.DrawRay(Camera.main.transform.position, accuracy, Color.red, 5);
            if(Physics.Raycast(Camera.main.transform.position, accuracy, out RaycastHit hit, 100)) //Replace 0 with a layer mask
            {
                Debug.Log("HIT " + hit.transform.name);
                //ActiveMono.StartCoroutine(PlayTrail(Camera.main.transform.forward, hit.point, hit));
                //Future code to make but ensuring it is there
                if(hit.transform.tag == "Enemy")
                {
                    Debug.Log("Enemy Shot!");
                    hit.collider.gameObject.GetComponent<EnemyHealth>().DealDamage(hitdamage, hit.point);
                }
            }
            else
            {
                //ActiveMono.StartCoroutine(
                //    PlayTrail(PartPos.forward,
                //    PartPos.forward + (accuracy * BulletEffects.MissDistance), 
                //    new RaycastHit()
                //    )
                //);
            }
            
        }
    }

    public void Reload()
    {
        ammocount += reloadCount;
    }

    public void Despawn()
    {
        Destroy(Model);
    }

}