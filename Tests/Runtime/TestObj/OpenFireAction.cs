using UnityEngine;

namespace UtilityAI.Tests
{
    [CreateAssetMenu]
    public class OpenFireAction : ActionScriptableObject
    {
        public override void Execute(IAIContext context)
        {
            TestContext test = context as TestContext;
            test.test.OpenFire();
        }
    }
}
