using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class HandScript : MonoBehaviour
{
  [SerializeField] private GameObject projectile;
  [SerializeField] private string m_ShootInput;
  [SerializeField] private float projectileSpeed;
  public FollowTarget enemy;
  public QuestHandler questHandler;

  [HideInInspector] public int rockNumber = 0;
  [HideInInspector] public int laptopNumber = 0;
  [HideInInspector] public int bottleNumber = 0;
  [HideInInspector] public int objInHand = -1;
  [HideInInspector] public bool hasCard = false;
  
  public void ThrowProjectile() {
    if (rockNumber > 0)
    {
      GameObject m_projectile = Instantiate(projectile, transform.position, transform.rotation);
      Vector3 projectileVelocity = new Vector3(0, 0, projectileSpeed);
      m_projectile.GetComponent<Rigidbody>().velocity = projectileVelocity;
      LoudTrigger trigger = m_projectile.GetComponent<LoudTrigger>();
      trigger.thrown = true;
      trigger.enemy = enemy;
      m_projectile.SetActive(true);
      rockNumber --;
    }
  }

  void Start() {
    if (questHandler == null) {
      Debug.Log("QuestHandler reference not set on hand!");
    }
  }

  void Update()
  {
    // if (Input.GetButtonDown(m_ShootInput))
    // {
    //   ThrowProjectile();
    // }
  }

  public void throwAction(CallbackContext context) {
    if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed) {
      ThrowProjectile();
    }
  }

  public void equipItem(int type) {
    objInHand = type;
    Debug.Log("equipped: " + type);
  }

  public bool isFull() {
    return objInHand > -1;
  }

  public void emptyHand() {
    questHandler.depositItem(objInHand);

    objInHand = -1;
  }

  public void equipCard() {
    hasCard = true;
    questHandler.depositItem((int)QuestTypes.cartela);
  }
}
