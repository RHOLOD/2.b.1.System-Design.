using System.Collections;
abstract class BloomFilter<T>
{
    private int filterLen;
    private BitArray flags;
    private int MaxSize;
    private int count;
    private int add_status;
    private int delete_status;
    private int multiplier1 = 17;
    private int multiplier2 = 223;


    // интерфейс класса, реализующий АТД HashTable

    public const int ADD_NIL = 0;
    public const int ADD_OK = 1;
    public const int ADD_ERR = 2;

    // конструктор
    public BloomFilter(int value = 32, int maxSize = 10)
    {
        MaxSize = maxSize;
        filterLen = value;
        flags = new BitArray(filterLen, false);
        MaxSize = maxSize;
        count = 0;
        add_status = ADD_NIL;
    }

    // команды:

    // предусловие: в фильтре есть место для добавление нового элемента
    // постусловие: добавляет элемент в фильтр
    public void Add(T value)
    {
        if (value == null || count >= MaxSize)
        {
            add_status = ADD_ERR;
        }
        else
        {
            int index1 = (value.GetHashCode() * multiplier1) % filterLen;
            int index2 = (value.GetHashCode() * multiplier2) % filterLen;
            flags[index1] = true;
            flags[index2] = true;
            add_status = ADD_OK;
        }
        
    }
    // запросы:

    // предусловие: в фильтре есть элемент
    // постусловие: возращает tru если фильтр содержит элемент
    public bool IsValue(T value)
    {
        int index1 = (value.GetHashCode() * multiplier1) % filterLen;
        int index2 = (value.GetHashCode() * multiplier2) % filterLen;
        if (flags[index1] == true && flags[index2] == true)
        {
            return true;
        }
        return false;
    }
    // дополнительные запросы:
    public int get_add_status() 
    {
        return add_status;
    }

}
