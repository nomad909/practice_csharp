namespace lib.collections
{
    public abstract class BaseHeap<T> where T : IComparable<T>
    {
        protected T[] heap;
        protected int capacity;
        protected int size;

        public BaseHeap(int _capacity)
        {
            this.heap = new T[_capacity];
            this.capacity = _capacity;
            this.size = 0;
        }

        public void Enqueue(T _item)
        {
            if(this.size >= this.capacity) {
                throw new InvalidOperationException("heap is full");
            }

            int lastIndex = this.size;
            this.heap[lastIndex] = _item;
            ++this.size;

            HeapifyUp(lastIndex);
        }

        public T Dequeue()
        {
            if(this.size <= 0) {
                throw new InvalidOperationException("heap is empty");
            }

            T root = this.heap[0];
            this.heap[0] = this.heap[this.size - 1];
            --this.size;

            HeapifyDown(0);

            return root;
        }

        public T Peek()
        {
            if(this.size <= 0) {
                throw new InvalidOperationException("heap is empty");
            }

            return this.heap[0];
        }

        public void Clear()
        {
            for(int i = 0; i < size; ++i) {
                this.heap[i] = default(T);
            }
            
            this.size = 0;
        }

        protected int GetParentIndex(int _index)
        {
            return (_index - 1) / 2;
        }

        protected int GetLeftChildIndex(int _index)
        {
            return _index * 2 + 1;
        }

        protected int GetRightChildIndex(int _index)
        {
            return _index * 2 + 2;
        }

        protected void Swap(int _a, int _b)
        {
            T temp = this.heap[_a];
            this.heap[_a] = this.heap[_b];
            this.heap[_b] = temp;
        }

        protected virtual void HeapifyUp(int _index)
        {
        }

        protected virtual void HeapifyDown(int _index)
        {
        }
    }

    public class MinHeap<T> : BaseHeap<T> where T : IComparable<T>
    {
        public MinHeap(int _capacity) : base(_capacity)
        {
        }
        // private T[] heap;
        // private int capacity;
        // private int size;

        // public MinHeap(int _capacity)
        // {
        //     this.heap = new T[_capacity];
        //     this.capacity = _capacity;
        //     this.size = 0;
        // }

        // public void Enqueue(T _item)
        // {
        //     if(this.size >= this.capacity) {
        //         throw new InvalidOperationException("heap is full");
        //     }

        //     int lastIndex = this.size;
        //     this.heap[lastIndex] = _item;
        //     ++this.size;

        //     HeapifyUp(lastIndex);
        // }

        // public T Dequeue()
        // {
        //     if(this.size <= 0) {
        //         throw new InvalidOperationException("heap is empty");
        //     }

        //     T root = this.heap[0];
        //     this.heap[0] = this.heap[this.size - 1];
        //     --this.size;

        //     HeapifyDown(0);

        //     return root;
        // }

        // public T Peek()
        // {
        //     if(this.size <= 0) {
        //         throw new InvalidOperationException("heap is empty");
        //     }

        //     return this.heap[0];
        // }

        // private int GetParentIndex(int _index)
        // {
        //     return (_index - 1) / 2;
        // }

        // private int GetLeftChildIndex(int _index)
        // {
        //     return _index * 2 + 1;
        // }

        // private int GetRightChildIndex(int _index)
        // {
        //     return _index * 2 + 2;
        // }

        protected override void HeapifyUp(int _index)
        {
            int smallest = _index;
            while (_index > 0 && this.heap[_index].CompareTo(this.heap[GetParentIndex(_index)]) < 0) {
                smallest = GetParentIndex(_index);
                Swap(_index, smallest);
                _index = smallest;
            }
        }

        protected override void HeapifyDown(int _index)
        {
            int biggest = _index;

            int leftChildIndex = GetLeftChildIndex(_index);
            int rightChildIndex = GetRightChildIndex(_index);

            if(leftChildIndex < size && this.heap[biggest].CompareTo(this.heap[leftChildIndex]) > 0) {
                biggest = leftChildIndex;
            }
            
            if(rightChildIndex < size && this.heap[biggest].CompareTo(this.heap[rightChildIndex]) > 0) {
                biggest = rightChildIndex;
            }

            if(biggest != _index) {
                Swap(_index, biggest);
                HeapifyDown(biggest);
            }
        }

        // private void Swap(int _a, int _b)
        // {
        //     T temp = this.heap[_a];
        //     this.heap[_a] = this.heap[_b];
        //     this.heap[_b] = temp;
        // }
    }

    public class MaxHeap<T> : BaseHeap<T> where T : IComparable<T>
    {
        public MaxHeap(int _capacity) : base(_capacity)
        {
        }
        // private T[] heap;
        // private int capacity;
        // private int size;

        // public MaxHeap(int _capacity)
        // {
        //     this.heap = new T[_capacity];
        //     this.capacity = _capacity;
        //     this.size = 0;
        // }

        // public void Enqueue(T _item)
        // {
        //     if(this.size >= this.capacity) {
        //         throw new InvalidOperationException("MaxHeap:heap is full");
        //     }

        //     int lastIndex = this.size;
        //     this.heap[lastIndex] = _item;
        //     ++this.size;

        //     HeapifyUp(lastIndex);
        // }

        // public T Dequeue()
        // {
        //     if(this.size <= 0) {
        //         throw new InvalidOperationException("MaxHeap:heap is empty");
        //     }

        //     T root = this.heap[0];
        //     this.heap[0] = this.heap[this.size - 1];
        //     --this.size;

        //     HeapifyDown(0);

        //     return root;
        // }

        // public T Peek()
        // {
        //     if(this.size <= 0) {
        //         throw new InvalidOperationException("MaxHeap:heap is empty");
        //     }

        //     return this.heap[0];
        // }

        // private int GetParentIndex(int _index)
        // {
        //     return (_index - 1) / 2;
        // }

        // private int GetLeftChildIndex(int _index)
        // {
        //     return _index * 2 + 1;
        // }

        // private int GetRightChildIndex(int _index)
        // {
        //     return _index * 2 + 2;
        // }

        protected override void HeapifyUp(int _index)
        {
            int biggest = _index;
            while(_index > 0 && this.heap[_index].CompareTo(this.heap[GetParentIndex(_index)]) > 0) {
                biggest = GetParentIndex(_index);
                Swap(_index, biggest);
                _index = biggest;
            }
        }

        protected override void HeapifyDown(int _index)
        {
            int smallest = _index;

            int leftChildIndex = GetLeftChildIndex(_index);
            int rightChildIndex = GetRightChildIndex(_index);

            if(leftChildIndex < size && this.heap[smallest].CompareTo(this.heap[leftChildIndex]) < 0) {
                smallest = leftChildIndex;
            }

            if(rightChildIndex < size && this.heap[smallest].CompareTo(this.heap[rightChildIndex]) < 0) {
                smallest = rightChildIndex;
            }

            if(smallest != _index) {
                Swap(_index, smallest);
                HeapifyDown(smallest);
            }
        }

        // private void Swap(int _a, int _b)
        // {
        //     T temp = this.heap[_a];
        //     this.heap[_a] = this.heap[_b];
        //     this.heap[_b] = temp;
        // }
    }
}