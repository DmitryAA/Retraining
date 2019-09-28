using System;
using System.Collections.Generic;

namespace EdVision.Retraining.API.Cashe {
    public class TemporaryCashe<TId, TData> {
        TimeSpan actualityTime;
        Dictionary<TId, Tuple<DateTime, TData>> storage;

        public TData this[TId key] {
            get {
                Tuple<DateTime, TData> temporaryValue;
                if (!storage.TryGetValue(key, out temporaryValue)) {
                    return default(TData);
                }
                if (DateTime.Now - temporaryValue.Item1 > actualityTime) {
                    return default(TData);
                }
                return temporaryValue.Item2;
            }
            set {
                if (storage.ContainsKey(key)) {
                    storage.Remove(key);
                }
                storage.Add(key, new Tuple<DateTime, TData>(DateTime.Now, value));
            }
        }

        public TemporaryCashe(TimeSpan actualityTime) {
            this.storage = new Dictionary<TId, Tuple<DateTime, TData>>();
            this.actualityTime = actualityTime;
        }

        
    }
}
