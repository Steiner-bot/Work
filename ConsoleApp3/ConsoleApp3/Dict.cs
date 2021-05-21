using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Dict <Tkey, Tvalue>
    {

        public struct Entry
        {
            public int HashCode;
            public int next;
            public Tkey key;
            public Tvalue value;
        }
        private int[] bucket;
        private Entry[] entries;
        private int freeList;
        private int freeCount;
        private int count;
        private IEqualityComparer<Tkey> comp;

        public Dict(int capacity)
        {
            comp = EqualityComparer<Tkey>.Default;
            bucket = new int[capacity];
            entries = new Entry[capacity];
            for(int i= 0;i<capacity;i++)
            {

                bucket[i] = -1;
                freeList = -1;

            }
        }

        private void Resize()
        {
            Resize(count * 2);
        }
        private void Resize(int newSize)
        {
            int[] newBuckets = new int[newSize];
            for (int i = 0; i < newBuckets.Length; i++)
                newBuckets[i] = -1;
            Entry[] newEntries = new Entry[newSize];
            Array.Copy(entries, 0, newEntries, 0, count);

            for (int i = 0; i < count; i++)
            {
                if (newEntries[i].HashCode >= 0)
                {
                    int bucket = newEntries[i].HashCode % newSize;
                    newEntries[i].next = newBuckets[bucket];
                    newBuckets[bucket] = i;
                }
            }
            bucket = newBuckets;
            entries = newEntries;
        }
        public void Add(Tkey key, Tvalue value)
        {
            int hashCode = comp.GetHashCode(key) & 0x7FFFFFFF;
            int targetBucket = hashCode % bucket.Length;

            for (int i = bucket[targetBucket]; i >= 0; i = entries[i].next)
            {
                if (entries[i].HashCode == hashCode && comp.Equals(entries[i].key, key))
                {
                    entries[i].value = value;
                    return;
                }
            }

            int index;
            if (freeCount > 0)
            {
                index = freeList;
                freeList = entries[index].next;
                freeCount--;
            }
            else
            {
                if (count == entries.Length)
                {
                    Resize();
                    targetBucket = hashCode % bucket.Length;
                }
                index = count;
                count++;
            }
            entries[index].HashCode = hashCode;
            entries[index].next = bucket[targetBucket];
            entries[index].key = key;
            entries[index].value = value;
            bucket[targetBucket] = index;
        }

        private int FindEntry(Tkey key)
        {
            if (bucket != null)
            {
                int hashCode = comp.GetHashCode(key) & 0x7FFFFFFF;
                for (int i = bucket[hashCode % bucket.Length]; i >= 0; i = entries[i].next)
                {
                    if (entries[i].HashCode == hashCode && comp.Equals(entries[i].key, key))
                        return i;
                }
            }
            return -1;
        }
        public Tvalue this[Tkey key]
        {
            get
            {
                int i = FindEntry(key);
                if (i >= 0)
                {
                    return entries[i].value;
                }
                return default(Tvalue);
            }
            set
            {
                Add(key, value);
            }
        }

        public bool ContainsKey(Tkey key)
        {
            return FindEntry(key) >= 0;
        }

        public void Print()
        {

            Console.WriteLine("Index \t Bucket\t\t Entries");
            for(int i =0; i< bucket.Length;i++)
            {

                Console.Write(i + "\t" + bucket[i]);
                Console.Write("\t\tKey: " + entries[i].key);
                Console.WriteLine(entries[i].next <= 0 ? "" : "->" + entries[i].next);

            }

        }
    }
}
