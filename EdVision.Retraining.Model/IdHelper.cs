using System;
using System.Collections.Generic;

namespace EdVision.Retraining.Model {
    // TODO: УБРАТЬ КОСТЫЛЬ!!!!
    public class IdHelper {
        static IdHelper instance = new IdHelper();
        Dictionary<Type, int> LastIds = new Dictionary<Type, int>();

        public static IdHelper Instance => instance;

        private IdHelper() {

        }

        public int GetNextId<T>() {
            Type type = typeof(T);
            int lastValue = 0;
            if (!LastIds.ContainsKey(type)) {
                lastValue = 1;
                LastIds.Add(type, lastValue);
            } else {
                lastValue = LastIds[type] + 1;
                LastIds[type] = lastValue;
            }
            return lastValue;
        }
    }
}
