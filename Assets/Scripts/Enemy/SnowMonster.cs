using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public enum AIState
{
    Idle,
    Wandering,
    Attacking,
    Fleeing,
    run
}



public class SnowMonster : MonoBehaviour ,IDamagable
{
    [Header("Stats")]
    public bool IsRange;
    public GameObject Bullet;
    public int health;
    public float walkSpeed;
    public float runSpeed;
    public ItemData[] dropOnDeath;

    [Header("AI")]
    private AIState aiState;
    public float detectDistance;
    public float safeDistance;

    [Header("Wandering")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;


    [Header("Combat")]
    public int MonsterDMG;
    public float attackRate;
    private float lastAttackTime;
    public float attackDistance;
    public float runDistance;
    private float playerDistance;

    public GameObject player;
    public float fieldOfView = 120f;
    private float time;
    private bool _AttackTimeCheck = false;
    public  float _AttackTime = 150f;

    private NavMeshAgent agent;
    private Animator animator;
    private MeshRenderer[] meshRenderers;


    public ParticleSystem ParticleSystem;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void Start()
    {
        SetState(AIState.Wandering);
    }

    private void Update()
    {

        /*if (IsRange && health <= 0)// 죽으면 테스트
        {
            MonsterManager.instance.split(this.gameObject);
            Destroy(this.gameObject,0f);
        }*/

        playerDistance = Vector3.Distance(transform.position, player.transform.position);
        time = time + Time.deltaTime;

        if (time > _AttackTime && !_AttackTimeCheck)
        {
            detectDistance = 150;
            _AttackTimeCheck = true;
        }

        if (playerDistance < runDistance && health <= 5)
            SetState(AIState.run);

        animator.SetBool("Moving", aiState != AIState.Idle);

        switch (aiState)
        {
            case AIState.Idle: PassiveUpdate(); break;
            case AIState.Wandering: PassiveUpdate(); break;
            case AIState.Attacking: AttackingUpdate(); break;
            case AIState.Fleeing: FleeingUpdate(); break;
            case AIState.run: runUpdate(); break;
        }
    }

    private void runUpdate()
    {
        if (playerDistance < runDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(transform.position - player.transform.position * 1);
        }
        else
        {
            SetState(AIState.Fleeing);
        }
    }

    private void FleeingUpdate()
    {
        if (agent.remainingDistance < 0.1f)
        {
            agent.SetDestination(GetFleeLocation());
        }
        else
        {
            SetState(AIState.Wandering);
        }
    }

    private void AttackingUpdate()
    {
        if ((playerDistance > attackDistance) || !IsPlaterInFireldOfView())
        {
            agent.isStopped = false;
            NavMeshPath path = new NavMeshPath();
            if (agent.CalculatePath(player.transform.position, path))
            {
                agent.SetDestination(player.transform.position);
            }
            else
            {
                SetState(AIState.Fleeing);
            }
        }
        else if(playerDistance < attackDistance)
        {
            agent.isStopped = true;
            if (Time.time - lastAttackTime > attackRate)
            {
                lastAttackTime = Time.time;
                player.GetComponent<IDamagable>().TakePhysicalDamage(MonsterDMG);
                animator.speed = 1;
                animator.SetTrigger("Attack");
                if (IsRange)
                {
                    transform.LookAt(player.transform);
                    if (transform.localScale.x > 0.5f)
                    {
                        transform.localScale = transform.localScale * 0.98f;
                    }
                    GameObject bullet = Instantiate(Bullet,transform.position,transform.rotation);
                    Destroy(bullet, 2f);
                }
            }
        }
    }

    private void PassiveUpdate()
    {
        if (aiState == AIState.Wandering && agent.remainingDistance < 0.1f)
        {
            SetState(AIState.Idle);
            Invoke("WanderToNewLocation", Random.Range(minWanderWaitTime, maxWanderWaitTime));
        }

        if (playerDistance < runDistance&& health <= 5)
        {
            SetState(AIState.run);
        }
        else if (playerDistance < detectDistance)
        {
            SetState(AIState.Attacking);
        }
    }

    bool IsPlaterInFireldOfView()
    {
        Vector3 directionToPlayer = player.transform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < fieldOfView * 0.5f;
    }

    private void SetState(AIState newState)
    {
        aiState = newState;
        switch (aiState)
        {
            case AIState.Idle:
                {
                    agent.speed = walkSpeed;
                    agent.isStopped = true;
                }
                break;
            case AIState.Wandering:
                {
                    agent.speed = walkSpeed;
                    agent.isStopped = false;
                }
                break;

            case AIState.Attacking:
                {
                    agent.speed = runSpeed;
                    agent.isStopped = false;
                }
                break;
            case AIState.Fleeing:
                {
                    agent.speed = runSpeed;
                    agent.isStopped = false;
                }
                break;
            case AIState.run:
                {
                    agent.speed = runSpeed;
                    agent.isStopped = false;
                }
                break;
        }

        animator.speed = agent.speed / walkSpeed;
    }

    void WanderToNewLocation()
    {
        if (aiState != AIState.Idle)
        {
            return;
        }
        SetState(AIState.Wandering);
        agent.SetDestination(GetWanderLocation());
    }


    Vector3 GetWanderLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (Vector3.Distance(transform.position, hit.position) < detectDistance)
        {
            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * Random.Range(minWanderDistance, maxWanderDistance)), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30)
                break;
        }

        return hit.position;
    }

    Vector3 GetFleeLocation()
    {
        NavMeshHit hit;

        NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * safeDistance), out hit, maxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while (GetDestinationAngle(hit.position) > 90 || playerDistance < safeDistance)
        {

            NavMesh.SamplePosition(transform.position + (Random.onUnitSphere * safeDistance), out hit, maxWanderDistance, NavMesh.AllAreas);
            i++;
            if (i == 30)
                break;
        }

        return hit.position;
    }

    float GetDestinationAngle(Vector3 targetPos)
    {
        return Vector3.Angle(transform.position - player.transform.position, transform.position + targetPos);
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health -= damageAmount;
        if (IsRange && health <= 0)
        {
            CreatetParticles();

            Debug.Log("split");
            MonsterManager.instance.split(this.gameObject);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 3f);
        }
        if (health <= 0)
            Die();
        else
        StartCoroutine(DamageFlash());

    }
    public void CreatetParticles()
    {
        ParticleSystem.transform.position = this.transform.position;
        ParticleSystem.Play();
    }

    //데미지 테스트용 삭제하기

        /*private void OnCollisionEnter(Collision collision)
        {
            TakePhysicalDamage(3);
        }*/

    void Die()
    {
        for (int x = 0; x < dropOnDeath.Length; x++)
        {
            Instantiate(dropOnDeath[x].dropPrefab, transform.position + Vector3.up * 2, Quaternion.identity);
        }
        MonsterManager.instance.count--;
        Destroy(gameObject);
    }

    IEnumerator DamageFlash()
    {
        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();

        for (int x = 0; x < meshRenderers.Length; x++) {
            meshRenderers[x].material.color = new Color(1.0f, 0.6f, 0.6f);

            /*meshRenderers[x].GetPropertyBlock(propBlock);
            propBlock.SetColor("_Color", new Color(1.0f, 0.6f, 0.6f));
            meshRenderers[x].SetPropertyBlock(propBlock);*/
        }
        //
        yield return new WaitForSeconds(0.4f);
        for (int x = 0; x < meshRenderers.Length; x++) {
            meshRenderers[x].material.color = Color.white;

           /* meshRenderers[x].GetPropertyBlock(propBlock);
            propBlock.SetColor("_Color", Color.white);
            meshRenderers[x].SetPropertyBlock(propBlock);*/
        }

    }
}

