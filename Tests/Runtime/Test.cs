using UnityEngine;

namespace UtilityAI.Tests
{
    /*
    * 简单测试
    * AI有治疗，开火，填装三个动作
    * 生命值较低时优先治疗，其余时间如果可以开火则开火，否则填装
    * AI从0生命与弹药开始，每秒都自动损失生命
    */
    public class Test : MonoBehaviour
    {
        public AIGraph AI;
        private float time;
        private float timer;
        private TestContext testContext = new TestContext();

        public float health;
        public float maxHealth = 100f;
        public int ammo;
        public int maxAmmo = 40;

        private float lastHurt = 1f;

        void Start()
        {
            time = AI.Decider.UpdateInterval;
            timer = time;
        }


        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                IAIContext context = GetAIContext();
                IAction action = AI.Decider.Decision(context);
                if (action != null)
                {
                    action.Execute(context);
                }
                timer = time;
            }
            UpdateState();
        }

        void UpdateState()
        {
            lastHurt -= Time.deltaTime;
            if (lastHurt <= 0)
            {
                Hurt();
                lastHurt = 1f;
            }
        }

        public void Cure()
        {
            health += 10f;
            Debug.Log(string.Format("{0}执行了治疗+{1}", gameObject.name, Time.time));
        }

        public void Fill()
        {
            ammo = maxAmmo;
            Debug.Log(string.Format("{0}执行了装填+{1}", gameObject.name, Time.time));
        }

        public void OpenFire()
        {
            ammo -= 5;
            Debug.Log(string.Format("{0}执行了开火+{1}", gameObject.name, Time.time));
        }

        public void Hurt()
        {
            health -= 2f;
        }

        public IAIContext GetAIContext()
        {
            testContext.healthPre = health / maxHealth;
            testContext.ammoPre = ammo / (float)maxAmmo;
            testContext.test = this;
            return testContext;
        }
    }

    public class TestContext : IAIContext
    {
        public float healthPre;
        public float ammoPre;
        public Test test;
    }
}

