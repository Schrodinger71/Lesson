from config import en, rus


def atbash():
    try:
        print("\nАтбаш.")
        encrypted_message = ''
        message = input("Введите сообщение которое вы хотите зашифровать: ")

        for char in message:
            if char in rus:
                # Находим индекс символа в русском алфавите
                t = rus.find(char)

                # Вычисляем новый индекс, используя правило Атбаш: n - i 
                new_key = len(rus) - t - 1
                
                # Добавляем в шифрованное сообщение символ с новым индексом из русского алфавита
                encrypted_message += rus[new_key]

            elif char in en:
                t = en.find(char)
                new_key = len(en) - t - 1
                encrypted_message += en[new_key]

            else:
                encrypted_message += char

        print('Зашифрованное сообщение:', encrypted_message)
        print("\n")

        from choice import choice  
        choice()

    except ValueError:
        print("Некорректный ввод. Введите целое число.")
        atbash()