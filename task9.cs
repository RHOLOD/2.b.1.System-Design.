abstract class HashTable<T>
{
    protected List<T> hashTable = new List<T>();
    protected int size;
    protected int put_status;
    protected int delete_status;

    // интерфейс класса, реализующий АТД HashTable

    public const int PUT_NIL = 0;
    public const int PUT_OK = 1;
    public const int PUT_ERR = 2;
    public const int DELETE_NIL = 0;
    public const int DELETE_OK = 1;
    public const int DELETE_ERR = 2;

    // конструктор
    public HashTable(int value = 16) // постусловие: создание новой хэш-таблцы заданного максимального размера
    {
        size = value;
    }

    // команды:

    // предусловие: в хранилище есть место
    // постусловие: добавляет элемент в хэш-таблицу
    virtual public void Put(T value)
    {
        if (hashTable.Count == size)
        {
            put_status = PUT_NIL;
        }
        else
        {
            hashTable.Add(value);
            put_status |= PUT_OK;
        }
    }


    // предусловие: таблица содержит элемент
    // постусловие: удалет элемент, если он есть в таблице
    public void Delete(T value)
    {
        if (hashTable.Count != 0)
        {
            int index = hashTable.IndexOf(value);
            if (index == -1)
            {
                delete_status = DELETE_ERR;
            }
            else
            {
                hashTable.RemoveAt(index);
                delete_status = DELETE_OK;
            }
        }
        else
        {
            delete_status = DELETE_ERR;
        }
    }

    // запросы:

    // предусловие:  таблица содержит элемент
    // постусловие: возращает tru если таблица содержит элемент
    public bool Get(T value)
    {
        int index = hashTable.IndexOf(value);
        if (index == -1)
        {
            return false;
        }
        return true;
    }

    // постусловие: возращает количество элементов в таблице
    public int Size()
    {
        return hashTable.Count();
    }

    // дополнительные запросы:

    public int get_put_status() // возвращает значение PUT_*
    {
        return put_status;
    }
    public int get_delte_status() // возвращает значение DELETE_*
    {
        return delete_status;
    }
}

abstract class PowerSet<T> : HashTable<T>
{
    public PowerSet(int size = 16) // постусловие: создание нового множества
    {
        base.size = size;
        put_status = PUT_NIL;
        delete_status = DELETE_NIL;
    }
    public override void Put(T value)
    {
        if (Size() == size)
        {
            put_status = PUT_NIL;
        }
        else
        {
            int index = hashTable.IndexOf(value);
            if (index == -1)
            {
                base.Put(value);
                put_status = PUT_OK;
            }
            else
            {
                put_status = DELETE_OK;
            }           
        }
    }
}