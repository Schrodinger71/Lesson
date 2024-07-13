### Ключевые слова в Python и примеры их применения

1. False: Логическое значение, представляющее ложь.
   ```python
   x \= False
   ```

2. None: Представляет отсутствие значения, эквивалентно null в других языках.
   ```python
   def func\(\):
       return None
   ```

3. True: Логическое значение, представляющее истину.
   ```python
   y \= True
   ```

4. and: Логический оператор И.
   ```python
   if x \> 0 and y \> 0:
       print\("Both x and y are greater than zero\."\)
   ```

5. as: Используется для создания алиаса при импорте модулей.
   ```python
   import numpy as np
   ```

6. assert: Проверяет, что утверждение истинно. В противном случае, возбуждает AssertionError.
   ```python
   assert x \> 0, "x must be greater than zero"
   ```

7. async: Объявляет корутину, асинхронную функцию.
   ```python
   async def fetch\_data\(\):
       \# код асинхронной работы
   ```

8. await: Ожидает завершения выполнения корутины в асинхронной функции.
   ```python
   result \= await fetch\_data\(\)
   ```

9. break: Прерывает выполнение цикла (for или while).
   ```python
   for i in range\(10\):
       if i \=\= 5:
           break
   ```

10. class: Определяет класс.
    ```python
    class MyClass:
        def \_\_init\_\_\(self, x\):
            self\.x \= x
    ```

11. continue: Прерывает текущую итерацию цикла и переходит к следующей.
    ```python
    for i in range\(10\):
        if i % 2 \=\= 0:
            continue
        print\(i\)
    ```

12. def: Определяет функцию.
    ```python
    def add\(a, b\):
        return a \+ b
    ```

13. del: Удаляет ссылку на объект.
    ```python
    del my\_list\[0\]
    ```

14. elif: Используется в условных выражениях как "else if".
    ```python
    if x \> 0:
        print\("Positive"\)
    elif x < 0:
        print\("Negative"\)
    ```

15. else: Ветка условного выражения, выполняемая, если условие ложно.
    ```python
    if x \> 0:
        print\("Positive"\)
    else:
        print\("Non\-positive"\)
    ```

16. except: Обрабатывает исключения в блоке try-except.
    ```python
    try:
        result \= 10 / 0
    except ZeroDivisionError:
        print\("Division by zero\!"\)
    ```

17. finally: Блок кода, который выполняется всегда после блока try, независимо от того, было ли исключение или нет.
    ```python
    try:
        file \= open\("file\.txt", "r"\)
        \# работа с файлом
    finally:
        file\.close\(\)
    ```

18. for: Итерирует по элементам последовательности.
    ```python
    for i in range\(5\):
        print\(i\)
    ```

19. from: Используется вместе с import для импорта определённых частей модуля.
    ```python
    from math import sqrt
    ```

20. global: Позволяет изменять переменные в глобальной области из локальной области видимости функции.
    ```python
    x \= 10
    def func\(\):
        global x
        x \+\= 1
    ```

21. if: Условный оператор, выполняет блок кода, если условие истинно.
    ```python
    if x \> 0:
        print\("Positive"\)
    ```

22. import: Импортирует модуль или часть модуля в текущий скрипт.
    ```python
    import math
    ```

23. in: Оператор проверки вхождения, используется для проверки, содержится ли элемент в последовательности.
    ```python
    if item in my\_list:
        print\("Item found"\)
    ```

24. is: Оператор проверки идентичности объектов.
    ```python
    if x is None:
        print\("x is None"\)
    ```

25. lambda: Определяет анонимную функцию.
    ```python
    square \= lambda x: x \* x
    ```

26. nonlocal: Объявляет переменную, которая не является локальной, но не глобальной.
    ```python
    def outer\(\):
        x \= 10
        def inner\(\):
            nonlocal x
            x \+\= 1
    ```

27. not: Логический оператор НЕ.
    ```python
    if not condition:
        print\("Condition is false"\)
    ```

28. or: Логический оператор ИЛИ.
    ```python
    if x \=\= 0 or y \=\= 0:
        print\("Either x or y is zero"\)
    ```

29. pass: Пустой оператор, который ничего не делает. Используется в теле функций, циклов или условных операторов, когда синтаксически требуется оператор, но ничего делать не нужно.
    ```python
    def func\(\):
        pass
    ```

30. raise: Вызывает исключение.
    ```python
    raise ValueError\("Invalid value"\)
    ```

31. return: Возвращает значение из функции.
    ```python
    def add\(a, b\):
        return a \+ b
    ```

32. try: Определяет блок кода, в котором проверяются исключения.
    ```python
    try:
        result \= 10 / 0
    except ZeroDivisionError:
        print\("Division by zero\!"\)
    ```

33. while: Определяет цикл, который выполняется, пока условие истинно.
    ```python
    i \= 0
    while i < 5:
        print\(i\)
        i \+\= 1
    ```

34. with: Используется для автоматического управления ресурсами, например, файлами.
    ```python
    with open\("file\.txt", "r"\) as file:
        content \= file\.read\(\)
    ```

