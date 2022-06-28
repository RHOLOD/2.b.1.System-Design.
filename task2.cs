abstract class LinkedList<T>

// скрытые поля
private bool is_head;
public bool is_head; 
private bool is_tail; 
private bool is_value;

// интерфейс класса, реализующий АТД LinkedList
public const int PUT_RIGH_NIL = 0;//  put_right() ещё не вызывалась
public const int PUT_RIGH_OK = 1; // узел добавлен
public const int PUT_RIGH_ERR = 2;// узел не добавлен

public const int PUT_LEFT_NIL = 0;//  put_left() ещё не вызывалась
public const int PUT_LEFT_OK = 1; // узел добавлен
public const int PUT_LEFT_ERR = 2;// узел не добавлен

public const int ADD_TAIL_NIL = 0;//  add_tail() ещё не вызывалась
public const int ADD_TAIL_OK = 1; // узел добавлен
public const int ADD_TAIL_ERR = 2;// узел не добавлен

public const int REMOVE_NIL = 0;//  remove() ещё не вызывалась
public const int REMOVE_OK = 1; // узел добавлен
public const int REMOVE_ERR = 2;// узел не добавлен

public const int REMOVE_ALL_NIL = 0;//  remove_all() ещё не вызывалась
public const int REMOVE_ALL_OK = 1; // узел добавлен
public const int REMOVE_ALL_ERR = 2;// узел не добавлен

//конструктор

// постусловие: очистить список
public LinkedList<T> LinkedList<T>;

// команды:
// предусловие: список не пустой
// постусловие: установит курсор на первый узел в списке
public void head;

// предусловие: список не пустой
// постусловие: установит курсор на последний узел в списке
public void tail;

// предусловие: список не пустой
// постусловие: сдвинет курсор на один узел вправо
public void right;

// постусловие: вставит следом за текущим узлом новый узел с заданным значением
public void put_right(T value);

// постусловие: ставит перед текущим узлом новый узел с заданным значением
public void put_left(T value);

// предусловие: список не пустой
// постусловие: удалит текущий узел
public void remove;

// постусловие: очистит список
public void clear;

// постусловие: добавит новый узел в хвост списка
public void add_tail(T value);

// предусловие: список не пустой
// постусловие: заменит значение текущего узла на заданное
public void replace(T value);

// предусловие: список не пустой
// постусловие: установит курсор на следующий узел с искомым значением 
public void find(T value);

// предусловие: список не пустой
// постусловие: удалит в списке все узлы с заданным значением
public void remove_all(T value);

// запросы:

// постусловие:получит значение текущего узла
public T get;

// постусловие: посчитает количество узлов в списке
public int size;

public bool Is_head; //находится ли курсор в начале списка?

public bool Is_tail; //находится ли курсор в конце списка?

public bool is_value; //установлен ли курсор на какой-либо узел в списке (по сути, непустой ли список)?

// дополнительные запросы:
public int get_put_right_status(); // возвращает значение PUT_RIGH_*
public int get_put_left_status(); // возвращает значение  PUT_LEFT_*
public int get_add_tail_status(); // возвращает значение  ADD_TAIL_*
public int get_remove_status(); // возвращает значение  REMOVE_*
public int get_remove_all_status(); // возвращает значение   REMOVE_ALL_*

