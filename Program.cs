using System;

namespace CircularQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = new MyCircularQueue(4); // null
            q.EnQueue(3); // true
            q.Front(); // 3
            q.IsFull();  // false
            q.EnQueue(7); // true
            q.EnQueue(2); // true
            q.EnQueue(5); // true
            q.DeQueue(); // true
            q.EnQueue(4); // true
            q.EnQueue(2); //false
            q.IsEmpty(); // false
            q.Rear(); //4
        }
    }

    public class MyCircularQueue
    {
        private int?[] obj;
        private int? head = null;
        private int? tail = null;

        public MyCircularQueue(int k)
        {
            obj = new int?[k];
        }

        public bool EnQueue(int value)
        {
            if (head == null) head = 0;
            if (tail == null) tail = -1;
            if (IsFull()) return false;
            tail++;
            if (tail == obj.Length && obj[0] != null)
            {
                tail--;
                return false;
            }
            if (tail == obj.Length && obj[0] == null)
            {
                tail = 0;
                obj[(int)tail] = value;
                return true;
            }
            else if (obj[(int)tail] == null)
            {
                obj[(int)tail] = value;
                if (tail == obj.Length)
                {
                    tail--;
                }
                return true;
            }
            return false;
        }

        public bool DeQueue()
        {
            if (IsEmpty()) return false;
            obj[(int)head] = null;
            head++;
            if (head == obj.Length) head = 0;
            if (obj[(int)head] == null && head == tail)
            {
                head = null;
                tail = null;
            }
            return true;
        }

        public int Front()
        {
            if (IsEmpty()) return -1;
            else return (int)obj[(int)head];
        }

        public int Rear()
        {
            if (IsEmpty()) return -1;
            else return (int)obj[(int)tail];
        }

        public bool IsEmpty()
        {
            for(int i = 0; i < obj.Length; i++)
            {
                if (obj[i] != null) return false;
            }
            return true;
        }

        public bool IsFull()
        {
            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i] == null) return false;
            }
            return true;
        }
    }
}
