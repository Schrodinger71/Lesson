import random

from tabulate import tabulate

from config import en, rus


def create_polybius_square(alphabet):
    """Создает квадрат Полибия для заданного алфавита."""
    size = int(len(alphabet) ** 0.5) + 1  # Определяем размер квадрата
    square = [['' for _ in range(size)] for _ in range(size)]
    
    index = 0
    for i in range(size):
        for j in range(size):
            if index < len(alphabet):
                square[i][j] = alphabet[index]
                index += 1
            else:
                square[i][j] = random.choice('!@#$%^&*()_+=-`~|}{[]\:;?><,./')
    return square

def find_coordinates(square, char):
    """Находит координаты символа в квадрате Полибия."""
    for i, row in enumerate(square):
        if char in row:
            return (i + 1, row.index(char) + 1)  # Возвращаем координаты (i+1, j+1)
    return None

def print_polybius_square(square):
    """Выводит квадрат Полибия в виде таблицы с нумерацией строк и столбцов."""
    print("Квадрат Полибия:")
    # Создаем список заголовков для столбцов
    headers = [" "] + [str(i + 1) for i in range(len(square))]  # Изменяем на цифры
    # Добавляем нумерацию строк к квадрату
    numbered_square = [
        [str(i + 1)] + row for i, row in enumerate(square)
    ]
    # Выводим таблицу
    print(tabulate(numbered_square, headers=headers, tablefmt="fancy_grid"))
    print("\n")

def polybius():
    alphabet = rus # + en  # Объединяем алфавиты, если нужно
    square = create_polybius_square(alphabet)
    
    print_polybius_square(square)  # Выводим квадрат Полибия
    
    print("Выберите метод шифрования:")
    print("1. Метод 1")
    print("2. Метод 2")
    print("3. Метод 3")
    
    method = input("Введите номер метода: ")
    
    message = input("Введите сообщение, которое вы хотите зашифровать: ")
    encrypted_message = ''
    
    if method == '1':
        # Метод 1
        for char in message:
            coords = find_coordinates(square, char)
            if coords:
                new_row = coords[0] % len(square)  # Переход к следующей строке
                encrypted_message += square[new_row][coords[1] - 1]
            else:
                encrypted_message += char

    elif method == '2':
        # Метод 2
        coordinates = []
        for char in message:
            coords = find_coordinates(square, char)
            if coords:
                coordinates.append(coords)

        # Разбиваем на пары
        for i in range(0, len(coordinates), 2):
            if i + 1 < len(coordinates):
                encrypted_message += f"{coordinates[i][0]}{coordinates[i][1]}{coordinates[i + 1][0]}{coordinates[i + 1][1]}"
            else:
                encrypted_message += f"{coordinates[i][0]}{coordinates[i][1]}"
                
        # Создаем новую строку
        new_string = ""
        # Добавляем первые два символа
        new_string += encrypted_message[0:2]
        # Добавляем символы с четными индексами
        for i in range(2, len(encrypted_message), 2):
            new_string += encrypted_message[i]
        # Добавляем символы с нечетными индексами
        for i in range(3, len(encrypted_message), 2):
            new_string += encrypted_message[i]
        encrypted_message = new_string
        
        # # Инициализация пустой строки для сообщения
        # message = ""

        # # Проходим по строке с шагом 2, чтобы извлекать пары координат
        # for i in range(0, len(encrypted_message), 2):
        #     x = int(encrypted_message[i])   # Координата Y (вертикальная)
        #     y = int(encrypted_message[i + 1])  # Координата X (горизонтальная)
            
        #     # Проверяем, что координаты находятся в пределах массива
        #     if 0 <= y < len(square) and 0 <= x < len(square[y]):
        #         message += square[y][x]
        #     else:
        #         message += '?'  # Если координаты выходят за пределы

        # # Выводим расшифрованное сообщение
        # print(message)



    elif method == '3':
        # Метод 3
        coordinates = []
        for char in message:
            coords = find_coordinates(square, char)
            if coords:
                coordinates.append(coords)

        # Сдвигаем влево на один шаг
        coordinates = coordinates[-1:] + coordinates[:-1]  # Сдвиг на один влево

        for i in range(0, len(coordinates), 2):
            if i + 1 < len(coordinates):
                encrypted_message += f"{coordinates[i][0]}{coordinates[i][1]}{coordinates[i + 1][0]}{coordinates[i + 1][1]}"
            else:
                encrypted_message += f"{coordinates[i][0]}{coordinates[i][1]}"

    print('Зашифрованное сообщение:', encrypted_message)
    
    from choice import choice  
    choice()