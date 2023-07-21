using Sirenix.OdinInspector;

namespace UtilityAI
{
    [NodeTint("#AF7AC5")]
    public abstract class BinderNode : AIBaseNode
    {
        [Output(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        [PropertyOrder(99)]
        [LabelText("Out")]
        public BinderNode binder;

#if UNITY_EDITOR
        [LabelText("注释")]
        [MultiLineProperty]
        public string Annotate;
#endif

        public abstract ScorerNode Scorers { get; }
    }
}