import random

from tabulate import tabulate

from config import en, rus


def create_polybius_square(alphabet, keyword):
    special_chars = "!@#$%^&*()-_=+[]{}|;:',.<>?/~`"
    # Удаляем дубликаты из ключевого слова
    seen = set()
    filtered_keyword = ''.join([char for char in keyword if not (char in seen or seen.add(char))])
    
    # Создаем строку для квадрата Полибия
    square_string = filtered_keyword + ''.join([char for char in alphabet if char not in filtered_keyword])
    
    # Формируем квадрат
    size = int(len(square_string)**0.5) + (len(square_string) % 2 > 0)  # Определяем размер квадрата
    square = []
    
    for i in range(size):
        row = []
        for j in range(size):
            index = i * size + j
            if index < len(square_string):
                row.append(square_string[index])
            else:
                row.append(random.choice(special_chars))
        square.append(row)
    
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
    # Ввод кодового слова
    keyword = input("Введите кодовое слово: ")
    square = create_polybius_square(alphabet, keyword)
    
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
        
        message_list = list(encrypted_message)
        for i in range(0, len(message_list) - 1, 2):
            message_list[i], message_list[i + 1] = message_list[i + 1], message_list[i]
        encrypted_message = ''.join(message_list)
        print(f"Координаты: {encrypted_message}")
        
        # Исходные данные
        coordinates = encrypted_message
        new_string = ''
        for i in range(len(coordinates)):
            if i % 2 == 0:
                new_string += coordinates[i]
        for i in range(len(coordinates)):
            if i % 2 == 1:
                new_string += coordinates[i]
        print(f"Новые координаты: {new_string}")
        
        # Преобразуем строку координат в список пар координат
        coordinates = [new_string[i:i+2] for i in range(0, len(new_string), 2)]
        # Извлекаем буквы по координатам
        result = []
        for coord in coordinates:
            row = int(coord[0]) - 1  # Преобразуем в индекс строки
            col = int(coord[1]) - 1  # Преобразуем в индекс столбца
            if 0 <= row < len(square) and 0 <= col < len(square[0]):
                result.append(square[col][row])
        # Выводим результат
        output_string = ''.join(result)
        #print("Результат:", output_string)
        encrypted_message = output_string


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