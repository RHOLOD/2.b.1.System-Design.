class BoundedStack<T>
{
	// скрытые поля
	private int maxSize = 0; // максимальный размер стека
	private List<T> stack = new List<T>(); // основное хранилище стека
	private int peek_status; // статус запроса peek()
	private int pop_status; // статус команды pop()
	private int push_status; // статус команды push()

	// интерфейс класса, реализующий АТД BoundedStack
	public const int POP_NIL = 0; // push() ещё не вызывалась
	public const int POP_OK = 1; // последняя pop() отработала нормально
	public const int POP_ERR = 2;  // стек пуст
	public const int PEEK_NIL = 0; // push() ещё не вызывалась
	public const int PEEK_OK = 1; // последняя peek() вернула корректное значение
	public const int PEEK_ERR = 2; // стек пуст
	public const int PUSH_NIL = 0; // push() ещё не вызывалась
	public const int PUSH_OK = 1; // элемент добавлен в стек
	public const int PUSH_ERR = 2; // стек переполнен


	public BoundedStack(int maxSizeStack = 32) // конструктор
	{
		if (maxSizeStack > 0)
		{
			maxSize = maxSizeStack;
		}
		clear();
	}
	public void push(T value) // добавляющая свой аргумент новым верхним элементом в стек;
	{
		if (size() < MaxSize())
		{
			stack.Add(value);
			push_status = PUSH_OK;
		}
		else
		{
			push_status = PUSH_ERR;
		}
	}
	public T pop() //возвращающая верхний элемент стека и одновременно удаляющая его
	{
		T result;
		if (size() > 0)
		{
			result = stack[size()-1];
			stack.RemoveAt(size() - 1);
			pop_status = POP_OK;
		}
		else
		{
			result = default;
			pop_status = POP_ERR;
		}
		return result;
	}
	public void clear()  //очищающая весь стек.
	{
		stack.Clear(); // пустой список/стек
		 // начальные статусы для предусловий peek() и pop() и push()
		peek_status = PEEK_NIL;
		pop_status = POP_NIL;
		push_status = PUSH_NIL;
	}
	public T peek() //возвращающая верхний элемент стека;
	{
		T result;
		if (size() > 0)
		{
			result = stack[size() - 1];
			peek_status = PEEK_OK;
		}
		else
		{
			result = default;
			peek_status = PEEK_ERR;
		}
		return result;
	}

	public int size() // возвращающая количество элементов в стеке;
	{
		return stack.Count;

	}
	public int MaxSize()//возращает максимальный размер стека
	{
		return maxSize;
	}
	// запросы статусов
	public int get_pop_status()
	{
		return pop_status;
	}
	public int get_peek_status()
	{
		return peek_status;
	}
	public int get_push_status()
	{
		return push_status;
	}
}