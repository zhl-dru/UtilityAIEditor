using UnityEngine;

namespace UtilityAI.Tests
{
    [CreateAssetMenu]
    public class HealthScene : SceneScriptableObject
    {
        public override float Evaluate(IAIContext context)
        {
            TestContext testContext = context as TestContext;
            return testContext.healthPre;
        }
    }
}
