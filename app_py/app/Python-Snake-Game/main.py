import random
import time

import pygame

import conf
import console


def message(msg, color, font_type, dis_width, dis_height):
    shown_text = font_type.render(msg, True, color)
    dis.blit(shown_text, [dis_width/10, dis_height/2])


def redraw_snake(snake_block, snake_list):
    for item in snake_list:
        pygame.draw.rect(dis, conf.blue, [item[0], item[1], snake_block, snake_block])


def show_score(score):
    score_font = pygame.font.SysFont("comicsansms", 20)
    value = score_font.render("Score: " + str(score), True, conf.green)
    dis.blit(value, [0, 0])


console.display_title_screen()
pygame.init()
font_style = pygame.font.SysFont(None, 25)  # can be set after initialized pygame module

dis = pygame.display.set_mode((conf.display_horizontal_size_x, conf.display_vertical_size_y))
pygame.display.update()

pygame.display.set_caption('Snake game by Adam Bemski')


def game_session():
    x1 = conf.x1
    y1 = conf.y1

    x1_change = 0
    y1_change = 0

    snake_list = []
    snake_length = 1

    clock = pygame.time.Clock()
    game_speed = conf.game_speed

    food_x = round(random.randrange(0, conf.display_horizontal_size_x - conf.snake_size) / 10.0) * 10.0
    food_y = round(random.randrange(0, conf.display_vertical_size_y - conf.snake_size) / 10.0) * 10.0

    game_over = False
    game_quit = False

    while game_over is False:
        while game_quit is True:
            dis.fill(conf.black)
            message("Game Over - Press q - quit or r - replay", conf.red, font_style,
                    conf.display_horizontal_size_x,
                    conf.display_vertical_size_y)
            show_score(snake_length - 1)
            pygame.display.update()
            for event in pygame.event.get():
                if event.type == pygame.QUIT:
                    game_over = True
                    game_quit = False
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_q:
                        game_over = True
                        game_quit = False
                    if event.key == pygame.K_r:
                        game_session()  # recursive call of entire game

        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                game_over = True
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_LEFT:
                    x1_change = -10
                    y1_change = 0
                elif event.key == pygame.K_RIGHT:
                    x1_change = 10
                    y1_change = 0
                elif event.key == pygame.K_UP:
                    y1_change = -10
                    x1_change = 0
                elif event.key == pygame.K_DOWN:
                    y1_change = 10
                    x1_change = 0

        # hitting the borders
        if x1 >= conf.display_horizontal_size_x or x1 < 0 \
                or y1 >= conf.display_vertical_size_y or y1 < 0:
            game_quit = True

        x1 += x1_change
        y1 += y1_change
        dis.fill(conf.black)  # allow change background
        pygame.draw.rect(dis, conf.red, [food_x, food_y, conf.snake_size, conf.snake_size])

        snake_head = (x1, y1)
        snake_list.append(snake_head)

        # remove trailing element - during snake movement
        if len(snake_list) > snake_length:
            del snake_list[0]

        # collision detection
        for element in snake_list[:-1]:
            if element == snake_head:
                game_quit = True

        redraw_snake(conf.snake_size, snake_list)
        show_score(snake_length - 1)
        pygame.display.update()

        # food eating
        if x1 == food_x and y1 == food_y:
            food_x = round(random.randrange(0, conf.display_horizontal_size_x - conf.snake_size) / 10.0) * 10.0
            food_y = round(random.randrange(0, conf.display_vertical_size_y - conf.snake_size) / 10.0) * 10.0
            snake_length += 1
            game_speed += 2

        clock.tick(game_speed)

    pygame.quit()
    quit()


if __name__ == "__main__":
    game_session()
