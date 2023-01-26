using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MonsterFaction.Util
{
    public class TimeLimitedCollection<T> : IEnumerable<T>
    {
        private List<Tuple<T, long>> list = new();
        private long counter = 0;

        public void Add(T item, long lifespan)
        {
            if (lifespan > 0)
                list.Add(new Tuple<T, long>(item, counter + lifespan));
        }

        public void Tick()
        {
            counter++;
            list = list.Where(p => p.Item2 > counter).ToList();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var i in list)
                yield return i.Item1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in list)
                yield return i.Item1;
        }
    }
}
