#include <iostream>
#include <string>
#include <vector>
#include <locale>
using namespace std;

int main()
{
    setlocale(LC_ALL, "ru");

    std::vector<std::string> nicknames;
    std::string nickname;

    std::cout << "Введите никнеймы. Когда закончите, введите 'Ex':" << std::endl;

    while (true) {
        std::cin >> nickname;
        if (nickname == "Ex") {
            break;
        }
        nicknames.push_back(nickname);
    }

    for (const auto& name : nicknames) {
        std::cout << "ban " << name << " Набегатор 0" << std::endl;
    }

    std::cout << "Для продолжения нажмите любую клавишу . . ." << std::endl;
    std::cin.get(); // Для остановки консоли после вывода сообщений
    return 0;
}