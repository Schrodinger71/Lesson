import configparser


config = configparser.ConfigParser()
config.read('config.ini')

display_horizontal_size_x = int(config['display']['horizontal_size_x'])
display_vertical_size_y = int(config['display']['vertical_size_y'])
x1 = int(config['snake']['start_point_x'])
y1 = int(config['snake']['start_point_y'])
snake_size = int(config['snake']['size'])
game_speed = int(config['game']['speed'])

black = (0, 0, 0)
red = (255, 0, 0)
green = (0, 255, 0)
blue = (0, 0, 255)
