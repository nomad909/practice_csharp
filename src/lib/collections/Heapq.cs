namespace lib.collections
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] heap;
        private int capacity;
        private int size;

        public MinHeap(int _capacity)
        {
            this.heap = new T[_capacity];
            this.capacity = _capacity;
            this.size = 0;
        }

        public void Insert(T _item)
        {
            if(this.size >= this.capacity) {
                throw new InvalidDataException("heap is full");
            }

            int currentIndex = this.size;
            this.heap[currentIndex] = _item;
            ++this.size;

            HeapifyUp(currentIndex);
        }

        public T Delete()
        {
            if(this.size <= 0) {
                //throw new InvalidDataException("heap is empty");
                return default;
            }

            T root = this.heap[0];
            this.heap[0] = this.heap[this.size - 1];
            --this.size;

            HeapifyDown(0);

            return root;
        }

        public T Min()
        {
            if(this.size <= 0) {
                //throw new InvalidDataException("heap is empty");
                return default;
            }

            return this.heap[0];
        }

        private int GetParentIndex(int _index)
        {
            return (_index - 1) / 2;
        }

        private int GetLeftChildIndex(int _index)
        {
            return _index * 2 + 1;
        }

        private int GetRightChildIndex(int _index)
        {
            return _index * 2 + 2;
        }

        private void HeapifyUp(int _index)
        {
            while(this.size > 0 && this.heap[_index].CompareTo(this.heap[GetParentIndex(_index)]) < 0) {
                int parentIndex = GetParentIndex(_index);
                Swap(_index, parentIndex);
            }
        }

        private void HeapifyDown(int _index)
        {
            if(this.size < 1) {
                return;
            }

            int biggest = _index;

            int leftChildIndex = GetLeftChildIndex(_index);
            if(leftChildIndex < size && this.heap[_index].CompareTo(this.heap[leftChildIndex]) > 0) {
                biggest = leftChildIndex;
                Swap(_index, leftChildIndex);
            }

            int rightChildIndex = GetRightChildIndex(_index);
            if(rightChildIndex < size && this.heap[_index].CompareTo(this.heap[rightChildIndex]) > 0) {
                biggest = rightChildIndex;
                Swap(_index, rightChildIndex);
            }

            if(biggest != _index) {
                HeapifyDown(biggest);
            }
        }

        private void Swap(int _a, int _b)
        {
            T temp = this.heap[_a];
            this.heap[_a] = this.heap[_b];
            this.heap[_b] = temp;
        }
    }
}