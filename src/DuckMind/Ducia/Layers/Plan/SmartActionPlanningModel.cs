using System.Reflection;

namespace Ducia {
    /// <summary>
    /// automatically implements the more tedious Clone, Equality, and HashCode methods
    /// make sure only the model data fields are properties
    /// any and all properties will be included in cloning, equality, and hashcode calculation
    /// however, this comes at a performance cost
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SmartActionPlanningModel<T> : ActionPlanningModel<T> where T : new() {
        private PropertyInfo[] propertyCache;

        public SmartActionPlanningModel() {
            var properties = GetType().GetProperties();
            propertyCache = properties;
        }

        public override T Clone(T b) {
            for (int i = 0; i < propertyCache.Length; i++) {
                var mine = propertyCache[i].GetValue(this);
                propertyCache[i].SetValue(b, mine);
            }

            return b;
        }

        public override bool Equals(T b) {
            for (int i = 0; i < propertyCache.Length; i++) {
                var mine = propertyCache[i].GetValue(this);
                var other = propertyCache[i].GetValue(b);
                if (!mine.Equals(other)) {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                for (int i = 0; i < propertyCache.Length; i++) {
                    hash = (hash * 23) + propertyCache[i].GetValue(this).GetHashCode();
                }

                return hash;
            }
        }
    }
}