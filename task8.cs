//АТД NativeDictionary
abstract class NativeDictionary<T>
{
    private List<T> nativeDictionary = new List<T>();
    private List<string> listKey = new List<string>();
    private int size;
    private int put_status;
    private int delete_status;
    private int get_status;

    // интерфейс класса, реализующий АТД HashTable

    public const int PUT_NIL = 0;
    public const int PUT_OK = 1;
    public const int PUT_ERR = 2;
    public const int DELETE_NIL = 0;
    public const int DELETE_OK = 1;
    public const int DELETE_ERR = 2;
    public const int GET_NIL = 0;
    public const int GET_OK = 1;
    public const int GET_ERR = 2;
    // конструктор
    public NativeDictionary(int size = 16) // постусловие: создание нового словаря
    {
        put_status = PUT_NIL;
        delete_status = DELETE_NIL;
        get_status = GET_NIL;
    }
    // команды:
    // предусловие: в хранилище есть место
    // постусловие: добавляет элемент в словарь
    public void Put(string key, T value)
    {
        if (nativeDictionary.Count == size)
        {
            put_status = PUT_ERR;
        }
        else
        {
            nativeDictionary.Add(value);
            listKey.Add(key);
            put_status |= PUT_OK;
        }
    }
    // предусловие: словарь содержит элемент
    // постусловие: удалет элемент, если он есть в таблице
    public void Delete(string key)
    {
        if (listKey.Count != 0)
        {
            int index = listKey.IndexOf(key);
            if (index == -1)
            {
                delete_status = DELETE_ERR;
            }
            else
            {
                listKey.RemoveAt(index);
                nativeDictionary.RemoveAt(index);
                delete_status = DELETE_OK;
            }
        }
        else
        {
            delete_status = DELETE_ERR;
        }
    }
    // запросы:
    // предусловие: элемент присутствует в словаре
    // постусловие: возвращает true если ключ имеется
    public bool IsKey(string key)
    {
        int index = listKey.IndexOf(key);
        if (index == -1)
        {
            return false;
        }
        return true;
    }

    // предусловие: элемент присутствует в словаре
    // постусловие: // возвращает value для key
    public T Get(string key)
    {
        int index = listKey.IndexOf(key);
        if (index == -1)
        {
            get_status = DELETE_ERR;
            return default;
        }
        else
        {            
            delete_status = DELETE_OK;
            return nativeDictionary[index];
        }
    }

    // дополнительные запросы:
    public int get_put_status()
    {
        return put_status;
    }
    public int get_delte_status()
    {
        return delete_status;
    }
    public int get_get_status()
    {
        return get_status;
    }
}
