import os
import sys
import time
import config.config
from os import system
import configparser


import pytube
from pytube import YouTube

from modules.interface import ConsoleInterface

interface = ConsoleInterface

def main():
    # Конфиг
    myCoolTitle = "Download YouTube"
    system("title " + myCoolTitle)
    #console = 'mode 114,30'
    #os.system(console)
    ps = config.config.password
    print(ps)
    



    interface.display_screen()
    
    url_video = input("Введите ссылку на видео: ")
    youtube = pytube.YouTube(url_video)
    # Получаем текущий каталог
    current_dir = os.path.dirname(os.path.abspath(__file__))

    # Переходим на одну папку назад
    parent_dir = os.path.dirname(current_dir)

    # Соединяем путь к родительскому каталогу с "Videos"
    videos_path = os.path.join(parent_dir, "Video")

    
    
    print(f"Название видео: {youtube.title}")
    print(f"Автор видео: {youtube.author}")
    print(f"Описание видео: {youtube.description}")
    print(f"Url video: {youtube.channel_url}")
    print(f"Rating: {youtube.rating}")
    print(f"Views: {youtube.views}]\n")
    #print(f"Разрешение видео: {stream.resolution}")
    
    #stream = youtube.streams.get_highest_resolution()
    print("Подождите идёт загрузка!!.......\n")
    video = youtube.streams.first()
    video.download(videos_path)
    
    print("Загрузка завершена!")
    
    time.sleep(10)
    


    
    pass









if __name__ == "__main__":
    main()
    
    
    
# Pytube - это библиотека Python, которая позволяет вам легко скачивать видео и аудио с YouTube. В ней есть множество методов, которые позволяют вам управлять процессом скачивания и получать информацию о видео.

# Вот некоторые из основных методов Pytube:

# Получение информации о видео:

# · YouTube.streams: Возвращает объект StreamQuery, который представляет собой набор доступных потоков для загрузки.
# · Stream.default_filename: Возвращает имя файла по умолчанию для потока.
# · Stream.title: Возвращает название видео.
# · Stream.author: Возвращает имя автора видео.
# · Stream.description: Возвращает описание видео.
# · Stream.thumbnail_url: Возвращает URL-адрес изображения обложки видео.
# · Stream.filesize: Возвращает размер файла в байтах.
# · Stream.resolution: Возвращает разрешение видео.
# · Stream.mime_type: Возвращает тип MIME-файла.

# Загрузка видео:

# · Stream.download(filename=None, output_path=None): Загружает видео в указанную папку.
# · Stream.download(filename=None, skip_existing=True): Загружает видео только в том случае, если файл с таким именем не существует.
# · Stream.download(filename=None, progress_bar=False): Отключает индикатор прогресса загрузки.
# · Stream.download(filename=None, merge_status_file=True): Объединяет файлы фрагментов в один файл после завершения загрузки.
# · Stream.download(filename=None, open_progress_bar=False): Отключает отображение окна с индикатором прогресса.
# · Stream.download(filename=None, output_path=None, merge_status_file=True, skip_existing=True, progress_bar=False, open_progress_bar=False): Сочетает в себе все вышеперечисленные опции.

# Другие методы:

# · YouTube.watch_url_suffix: Возвращает суффикс URL-адреса видео.
# · YouTube.watch_url: Возвращает полный URL-адрес видео.
# · YouTube.embed_url: Возвращает URL-адрес видео для встраивания.
# · YouTube.age_restricted: Возвращает True, если видео имеет возрастные ограничения.
# · YouTube.is_live: Возвращает True, если видео является прямым эфиром.
# · YouTube.video_id: Возвращает идентификатор видео.

    # x = os.get_terminal_size().lines
    # y = os.get_terminal_size().columns
    # print(x)
    # print(y)