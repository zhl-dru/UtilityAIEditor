using UnityEngine;

namespace UtilityAI.Tests
{
    [CreateAssetMenu]
    public class CureAction : ActionScriptableObject
    {
        public override void Execute(IAIContext context)
        {
            TestContext test = context as TestContext;
            test.test.Cure();

        }
    }
}
