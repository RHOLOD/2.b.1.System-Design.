abstract class Queue<T>
{
    // скрытые поля
    private List<T> queue = new List<T>(); // основное хранилище очереди
    private int pop_status;
    private int dequeue_status;

    // интерфейс класса, реализующий АТД Stack

    public const int POP_NIL = 0;
    public const int POP_OK = 1;
    public const int POP_ERR = 2;
    public const int DEQUEUE_NIL = 0;
    public const int DEQUEUE_OK = 1;
    public const int DEQUEUE_ERR = 2;

    // конструктор
    public Queue()
    {
        clear();
    }

    // команды:
    // постусловие: вставляет элемента в хвост
    public void Enqueue(T item)
    {
        queue.Add(item);
    }
    // предусловие: очерендь не пуста
    // постусловие: удалет первый элемент из головы
    public void pop()
    {
        if (Size() != 0)
        {
            queue.RemoveRange(0, 1);
            pop_status = POP_OK;
        }
        else
        {
            pop_status = POP_ERR;
        }
    }

    // постусловие: очищает очередь
    public void clear()
    {
        queue.Clear();
    }

    // запросы:

    // предусловие: очерендь не пуста
    // постусловие: выдает первый элемент из головы
    public T Dequeue()
    {
        if (Size() != 0)
        {
            return queue[0];
            dequeue_status = DEQUEUE_OK;
        }
        else
        {            
            dequeue_status = DEQUEUE_ERR;
        }
        return default;
    }

    // постусловие: возращает размер очереди
    public int Size()
    {
        return queue.Count();
    }

    // дополнительные запросы:

    public int get_pop_status() // возвращает значение APPEND_*
    {
        return pop_status;
    }
    public int get_dequeue_status() // возвращает значение INSERT_*
    {
        return dequeue_status;
    }
}
