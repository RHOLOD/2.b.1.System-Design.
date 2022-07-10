//АТД DynArray
abstract class DynArray<T>

// конструктор
public DynArray<T> DynArray(); // постусловие: создание нового массива

// команды:

// предусловие: 
// постусловие: создаеться новый массив заданного значения, не меньше 16 элементов. Предыдущие значениz копируються в новый массив
public void MakeArray(int value)

// предусловие:
// постусловие: добавление нового элемента в конец массива
public void Append(T item)

// предусловие: в i-й позиции есть элемент, индекс находиться в рамках границ
// постусловие:  вставляет в i-ю позицию объект item, сдвигая вперёд все последующие элементы
public void Insert(T item, int value)

// предусловие: в i-й позиции есть элемент, индекс находиться в рамках границ
// постусловие: удаляет объект из i-й позиции, при необходимости выполняя сжатие буфера.
public void Remove(int value)

// запросы:

// предусловие: массив не пустой
// постусловие: получение объекта по его индексу
public T GetItem(int value)

public bool IsArrayEmpty // пустой ли массив?

public int CountItem //текущее количество элементов в массиве

public int SizeBuffer // текущая ёмкость буфера

// дополнительные запросы:

public int get_make_array_status(); // возвращает значение MAKER_ARRAY_*

public int get_append_status(); // возвращает значение APPEND_*

public int get_insert_status(); // возвращает значение INSERT_*

public int get_remove_status(); // возвращает значение REMOVE_*
