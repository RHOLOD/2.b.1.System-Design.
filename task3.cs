class ParentList<T>
{
    // скрытые поля
    private int indicator; // указатель
    private List<T> parentList = new List<T>(); // основное хранилище связного списка
    private bool is_head_status;
    private bool is_tail_status;
    private bool is_value_status;
    private int head_status;
    private int tail_status;
    private int right_status;
    private int put_right_status;
    private int put_left_status;
    private int remove_status;
    private int replace_status;
    private int find_status;
    private int get_status;

    // интерфейс класса, реализующий АТД LinkedList

    public const int HEAD_NIL = 0;
    public const int HEAD_RIGH_OK = 1; 
    public const int HEAD_RIGH_ERR = 2;

    public const int TAIL_NIL = 0;
    public const int TAIL_OK = 1;
    public const int TAIL_ERR = 2;

    public const int RIGHT_NIL = 0;
    public const int RIGHT_OK = 1;
    public const int RIGHT_ERR = 2;

    public const int PUT_RIGH_NIL = 0;//  put_right() ещё не вызывалась
    public const int PUT_RIGH_OK = 1; // узел добавлен
    public const int PUT_RIGH_ERR = 2;// узел не добавлен

    public const int PUT_LEFT_NIL = 0;//  put_left() ещё не вызывалась
    public const int PUT_LEFT_OK = 1; // узел добавлен
    public const int PUT_LEFT_ERR = 2;// узел не добавлен

    public const int REMOVE_NIL = 0;//  remove() ещё не вызывалась
    public const int REMOVE_OK = 1; // узел удален
    public const int REMOVE_ERR = 2;// узел не удален

    public const int REPLACE_NIL = 0;
    public const int REPLACE_OK = 1;
    public const int REPLACE_ERR = 2;

    public const int FIND_NIL = 0;
    public const int FIND_OK = 1;
    public const int FIND_ERR = 2;

    public const int GET_NIL = 0;
    public const int GET_OK = 1;
    public const int GET_ERR = 2;

    // конструктор
    // постусловие: создан новый пустой список
    public ParentList()
    {
        clear();
    }
    // команды
    // предусловие: список не пуст;
    // постусловие: курсор установлен на первый узел в списке
    public void head()
    {        
        if (size() >= 1)
        {
            indicator = 0;
            head_status = HEAD_RIGH_OK;
            is_head_status = true;
            is_tail_status = false;
        }
        else
        {
            head_status = HEAD_RIGH_ERR;
        }
    }    
    // предусловие: список не пуст;
    // постусловие: курсор установлен на последний узел в списке
    public void tail()
    {
        if (size() >= 1)
        {
            indicator = size()-1;
            tail_status = TAIL_OK;
            is_head_status = false;
            is_tail_status = true;
        }
        else
        {
            tail_status = TAIL_ERR;
        }
    }
    // предусловие: правее курсора есть элемент;
    // постусловие: курсор сдвинут на один узел вправо
    public void right()
    {
        if (size() > indicator+1)
        {
            indicator++;
            tail_status = TAIL_OK;
            is_head_status = false;
        }
        else
        {
            is_tail_status = false;
            right_status = RIGHT_ERR;
        }
    }
    // предусловие: список не пуст;
    // постусловие: следом за текущим узлом добавлен
    // новый узел с заданным значением
    public void put_right(T value)
    {
        if (size() >= 1)
        {
            indicator++;
            parentList.Insert(indicator, value);
            put_right_status = PUT_RIGH_OK;
            if (size() == indicator + 1)
            {
                is_head_status = false;
                is_tail_status = true;
            }
            else
            {
                is_head_status = false;
                is_tail_status = false;
            }
        }
        else
        {
            put_right_status = PUT_RIGH_OK;
        }
    }
    // предусловие: список не пуст;
    // постусловие: перед текущим узлом добавлен
    // новый узел с заданным значением
    public void put_left(T value)
    {
        if (size() >= 1)
        {
            if (indicator == 0)
            {
                parentList.Insert(0, value);
            }
            else
            {
                indicator--;
                parentList.Insert(indicator, value);
            }
            put_left_status = PUT_LEFT_OK;
            if (size() == 1)
            {
                is_head_status = true;
                is_tail_status = false;
            }
            else
            {
                is_head_status = false;
                is_tail_status = false;
            }
        }
        else
        {
            put_left_status = PUT_LEFT_ERR;
        }
    }
    // предусловие: список не пуст;
    // постусловие: текущий узел удалён,
    // курсор смещён к правому соседу, если он есть,
    // в противном случае курсор смещён к левому соседу,
    // если он есть
    public void remove()
    {
        if (size() >= 1)
        {
            if (size() == 1)
            {
                parentList.RemoveAt(indicator);
                remove_status = REMOVE_OK;
                indicator = 0;
                is_head_status = false;
                is_tail_status = false;
                is_value_status = false;
            }
            if (size() > indicator+1)
            {
                parentList.RemoveAt(indicator);
                remove_status = REMOVE_OK;
                is_head_status = false;
                if (size() == indicator+1)
                {
                    is_tail_status = true;
                }
                else
                {
                    is_tail_status = false;
                }
                is_value_status = true;
            }
            if (size() == indicator+1)
            {
                parentList.RemoveAt(indicator);
                remove_status = REMOVE_OK;
                indicator--;
                is_head_status = false;
                is_tail_status = true;
                is_value_status = true;
            }
        }
        else
        {
            is_head_status = false;
            is_tail_status = false;
            is_value_status = false;
            remove_status = REMOVE_ERR;
        }
    }
    // постусловие: список очищен от всех элементов
    public void clear()
    {
        indicator = 0;
        parentList.Clear();
        is_head_status = false;
        is_tail_status = false;
        is_value_status = false;
        head_status = HEAD_NIL;
        tail_status = TAIL_NIL;
        right_status = RIGHT_NIL;
        put_left_status = PUT_LEFT_NIL;
        put_left_status = PUT_LEFT_NIL;
        remove_status = REMOVE_NIL;
        replace_status = REPLACE_NIL;
        find_status = FIND_NIL;
        get_status = GET_NIL;
    }
    // постусловие: новый узел добавлен в хвост списка
    public void add_tail(T value)
    {
        parentList.Add(value);
        indicator = size()-1;
        if (size() == 1)
        {
            is_head_status = true;
            is_tail_status = false;
        }
        else
        {
            is_head_status = false;
            is_tail_status = true;
        }        
        is_value_status = true;
    }
    // постусловие: в списке удалены все узлы с заданным значением
    public void remove_all(T value)
    {
        Predicate<T> predicate = (T x) => x.Equals(value);
        parentList.RemoveAll(predicate);
    }
    // предусловие: список не пуст;
    // постусловие: значение текущего узла заменено на новое
    public void replace(T value)
    {
        if (size() >= 1)
        {
            parentList[indicator] = value;
            remove_status = REMOVE_OK;
            indicator = size() - 1;
            tail_status = TAIL_OK;
        }
        else
        {
            remove_status = REPLACE_ERR;
        }
    }
    // постусловие: курсор установлен на следующий узел
    // с искомым значением, если такой узел найден
    public void find(T value)
    {
        Predicate<T> predicate = (T x) => x.Equals(value);
        T item = parentList.Find(predicate);
        if (item is not null)
        {
            find_status = FIND_OK;
        }
        else
        {
            find_status = FIND_ERR;
        }
    }
    // запросы
    public T get() // предусловие: список не пуст
    {
        if (size() == 0)
        {
            get_status = GET_ERR;
            is_head_status = false;
            is_tail_status = false;
            is_value_status = false;
            return default;
        }
        else
        {
            get_status = GET_OK;
            return parentList[indicator];
        }        
    }
    public bool is_head()
    {
        return is_head_status;
    }
    public bool is_tail()
    {
        return is_tail_status;
    }
    public bool is_value()
    {
        return is_value_status;
    }
    public int size()
    {
        return parentList.Count;
    }
    // запросы статусов (возможные значения статусов)
    public int get_head_status() // успешно; список пуст
    {
        return head_status;
    }
    public int get_tail_status() // успешно; список пуст
    {
        return tail_status;
    }
    public int get_right_status() // успешно; правее нету элемента
    {
        return right_status;
    }
    public int get_put_right_status() // успешно; список пуст
    {
        return put_right_status;
    }
    public int get_put_left_status() // успешно; список пуст
    {
        return put_left_status;
    }
    public int get_remove_status() // успешно; список пуст
    {
        return remove_status;
    }
    public int get_replace_status() // успешно; список пуст
    {
        return replace_status;
    }
    public int get_find_status() // следующий найден;// следующий не найден; список пуст
    {
        return find_status;
    }

}