def choice() -> None:
    from encryp.atbash import atbash
    from encryp.caesar import caesar
    from encryp.polybius import polybius

    while True:
        user_choice = input("Меню выбора шифра:\n1. Цезарь\n2. Атбаш\n3. Квадрат Полибия\n4. Завершить программу\n\nВведите число: ")
        try:
            user_choice = int(user_choice)
            if 1 <= user_choice <= 4:
                if user_choice == 1:
                    caesar()
                elif user_choice == 2:
                    atbash()
                elif user_choice == 3:
                    polybius()
                    pass
                elif user_choice == 4:
                    exit()
            else:
                print("Некорректный ввод. Введите число от 1 до 4.")
        except ValueError:
            print("Некорректный ввод.")