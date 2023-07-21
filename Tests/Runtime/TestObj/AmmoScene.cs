using UnityEngine;

namespace UtilityAI.Tests
{
    [CreateAssetMenu]
    public class AmmoScene : SceneScriptableObject
    {
        public override float Evaluate(IAIContext context)
        {
            TestContext testContext = context as TestContext;
            return testContext.ammoPre;
        }
    }
}
