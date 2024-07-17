# from pytube import YouTube
# import os

# # the function takes the video url as an argument
# def video_downloader(video_url):
#     # passing the url to the YouTube object
#     my_video = YouTube(video_url)
#     # downloading the video in high resolution
#     my_video.streams.get_highest_resolution().download()
#     # return the video title
#     return my_video.title


# # the try statement will run if there are no errors
# try:
#     # getting the url from the user
#     youtube_link = input('Enter the YouTube link:')
#     print(f'Downloading your Video, please wait.......')
#     # passing the url to the function
#     video = video_downloader(youtube_link)
#     # printing the video title
#     print(f'"{video}" downloaded successfully!!')
# #the except will catch ValueError, URLError, RegexMatchError and simalar
# except:
#     print(f'Failed to download video\nThe '\
#           'following might be the causes\n->No internet '\
#           'connection\n->Invalid video link')
    
    
# import youtube_dl

# video_url = "https://www.youtube.com/watch?v=S4lhWeI5d5o"
# output_path = "C:/Lesson/app_py/app/YouTubeLoad/src/"

# dl_options = {'format': 'best', 'outtmpl': output_path + "/%(title)s.%(ext)s"}
# with youtube_dl.YoutubeDL(dl_options) as dl:
#     dl.download([video_url])






from pytube import YouTube

def download_youtube_audio(url, save_path):
    yt = YouTube(url)
    audio_stream = yt.streams.filter(only_audio=True).first()
    audio_stream.download(output_path=save_path)

if __name__ == "__main__":
    url = "https://www.youtube.com/watch?v=9bZkp7q19f0"
    save_directory = "C:/Lesson/app_py/app/YouTubeLoad/src/"  # Укажите путь к каталогу для сохранения аудио
    download_youtube_audio(url, save_directory)