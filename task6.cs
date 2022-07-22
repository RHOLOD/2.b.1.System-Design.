abstract class ParentQueue<T>
{
    // скрытые поля
    protected List<T> queue = new List<T>(); // основное хранилище очереди
    protected int delete_front_status;
    protected int get_front_status;

    // интерфейс класса, реализующий АТД Stack

    public const int DELETE_FRONT_NIL = 0;
    public const int DELETE_FRONT_OK = 1;
    public const int DELETE_FRONT_ERR = 2;
    public const int GET_FRONT_NIL = 0;
    public const int GET_FRONT_OK = 1;
    public const int GET_FRONT_ERR = 2;

    // конструктор
    public ParentQueue()
    {
        clear();
        get_front_status = GET_FRONT_NIL;
        delete_front_status = DELETE_FRONT_NIL;
    }

    // команды:
    // постусловие: вставляет элемента в хвост
    public void add_tail(T item)
    {
        queue.Add(item);
    }
    // предусловие: очерендь не пуста
    // постусловие: удалет первый элемент из головы
    public void delete_front()
    {
        if (Size() != 0)
        {
            queue.RemoveRange(0, 1);
            delete_front_status = DELETE_FRONT_OK;
        }
        else
        {
            delete_front_status = DELETE_FRONT_ERR;
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
    public T get_front()
    {
        if (Size() != 0)
        {
            return queue[0];
            get_front_status = GET_FRONT_OK;
        }
        else
        {
            get_front_status = GET_FRONT_ERR;
        }
        return default;
    }

    // постусловие: возращает размер очереди
    public int Size()
    {
        return queue.Count();
    }

    // дополнительные запросы:
    public int get_delete_front_status() // возвращает значение INSERT_*
    {
        return delete_front_status;
    }
    public int get_get_front_status() // возвращает значение APPEND_*
    {
        return get_front_status;
    }
}
abstract class Queue<T> : ParentQueue<T>
{
    public Queue()
    {
        clear();
    }
}
abstract class Deque<T> : ParentQueue<T>
{
    // скрытые поля
    private int delete_tail_status;
    private int get_tail_status;

    // интерфейс класса, реализующий АТД Stack

    public const int DELETE_TAIL_NIL = 0;
    public const int DELETE_TAIL_OK = 1;
    public const int DELETE_TAIL_ERR = 2;
    public const int GET_TAIL_NIL = 0;
    public const int GET_TAIL_OK = 1;
    public const int GET_TAIL_ERR = 2;
    public Deque()
    {
        clear();       
        delete_tail_status = DELETE_TAIL_NIL;
        get_tail_status= GET_TAIL_NIL;
        this.get_front_status = GET_FRONT_NIL;
        this.delete_front_status = DELETE_FRONT_NIL;
    }

    // команды:
    // постусловие: вставляет элемента в голову
    public void add_front(T item)
    {        
        queue.Add(item);
    }
    // предусловие: очерендь не пуста
    // постусловие: удалет первый элемент из хвоста
    public void delete_tail()
    {
        if (Size() != 0)
        {
            queue.RemoveRange(Size()-1, 1);
            delete_tail_status = DELETE_TAIL_OK;
        }
        else
        {
            delete_tail_status = DELETE_TAIL_ERR;
        }
    }

    // запросы:

    // предусловие: очерендь не пуста
    // постусловие: выдает первый элемент из хвоста
    public T get_tail()
    {
        if (Size() != 0)
        {
            return queue[Size()-1];
            get_tail_status = GET_TAIL_OK;
        }
        else
        {
            get_tail_status = GET_TAIL_ERR;
        }
        return default;
    }

    // дополнительные запросы:
    public int get_delete_tail_status() // возвращает значение INSERT_*
    {
        return delete_tail_status;
    }
    public int get_get_tail_status() // возвращает значение APPEND_*
    {
        return get_tail_status;
    }

}