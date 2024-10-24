from config import en, rus


def caesar():
    try:
        print("\nЦезарь.")
        shift = int(input("Введите величину сдвига: "))
        encrypted_message = ''
        message = input("Введите сообщение которое вы хотите зашифровать: ")
        
        for char in message:
            if char in rus:
                # Находим индекс символа в русском алфавите
                t = rus.find(char)
                
                # Вычисляем новый индекс, сдвигая исходный на 'shift' позиций по модулю длины русского алфавита
                new_key = (t + shift) % len(rus)
                
                # Добавляем в шифрованное сообщение символ с новым индексом из русского алфавита
                encrypted_message += rus[new_key]
                
            elif char in en:
                t = en.find(char)
                new_key = (t + shift) % len(en)
                encrypted_message += en[new_key]
                
            # Если символ не русский и не английский, добавляем его в шифрованное сообщение без изменения
            else:
                encrypted_message += char
                
        print('Зашифрованное сообщение:', encrypted_message)
        print("\n")
        
        from choice import choice  
        choice()
        
    except ValueError:
        print("Некорректный ввод. Введите целое число.")
        caesar()