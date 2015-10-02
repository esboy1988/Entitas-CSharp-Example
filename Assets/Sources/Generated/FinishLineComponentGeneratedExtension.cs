using Entitas;

namespace Entitas {
    public partial class Entity {
        static readonly FinishLineComponent finishLineComponent = new FinishLineComponent();

        public bool isFinishLine {
            get { return HasComponent(CoreComponentIds.FinishLine); }
            set {
                if (value != isFinishLine) {
                    if (value) {
                        AddComponent(CoreComponentIds.FinishLine, finishLineComponent);
                    } else {
                        RemoveComponent(CoreComponentIds.FinishLine);
                    }
                }
            }
        }

        public Entity IsFinishLine(bool value) {
            isFinishLine = value;
            return this;
        }
    }

    public partial class Pool {
        public Entity finishLineEntity { get { return GetGroup(CoreMatcher.FinishLine).GetSingleEntity(); } }

        public bool isFinishLine {
            get { return finishLineEntity != null; }
            set {
                var entity = finishLineEntity;
                if (value != (entity != null)) {
                    if (value) {
                        CreateEntity().isFinishLine = true;
                    } else {
                        DestroyEntity(entity);
                    }
                }
            }
        }
    }
}

    public partial class CoreMatcher {
        static IMatcher _matcherFinishLine;

        public static IMatcher FinishLine {
            get {
                if (_matcherFinishLine == null) {
                    _matcherFinishLine = Matcher.AllOf(CoreComponentIds.FinishLine);
                }

                return _matcherFinishLine;
            }
        }
    }
