#  Snake Game

- Snake Game implementation in Python 3.

![Game Screen](assets/snake_screen.png?raw=true)

Examples based on:
- [edureka](https://www.edureka.co/blog/snake-game-with-pygame/)

## Table of contents
* [Running app](#running-app)
* [Working principle](#working-principle)

## Running app

It is recommended to run this project over virtual environment. Run following commands in your terminal:
```powershell
python -m venv snake-game
cd ./snake-game
./Scripts/activate
mkdir code
cd ./code
# here clone this repository
pip install -r requirements.txt
python ./main.py
```

## Working principle

### Creating screen

To create screen use following pygame methods:
```python
import pygame

pygame.init()  # initialize pygame module

dis = pygame.display.set_mode((400, 300))  # set screen dimensions
pygame.display.update()  # apply changes in the game window
```

### Waiting for events

While loop can avoid instant closing of game window:
```python
game_over = False
while game_over is False:
    for event in pygame.event.get():
        print(event)  # prints out all the actions made on the screen
```
Here above console will print every event which will occur inside game window (like cursor movement or button press).

In order to close game window after clicking window cross button exchange body of while loop:
```python
game_over=False
while game_over is False:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            game_over = True
```

### Create the sake

Snake here will created as rectangle - over use draw.rect() method.

Firstly define colours inside our game (in RGB schema).
```python
blue = (0, 0, 255)
red = (255, 0, 0)
```
In the next step inside while loop put call of draw.rect() and update() methods:
```python
while game_over is False:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            game_over = True
    pygame.draw.rect(dis, blue, [200, 150, 10, 10])
    pygame.display.update()
```

### Move the snake

Before while loop add start point, movement calculation and time handler :
```python
x1 = 200
y1 = 200

x1_change = 0
y1_change = 0

clock = pygame.time.Clock()
```

To move snake will be used arrow keys. Put it inside while loop:
```python
while game_over is False:
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

    x1 += x1_change
    y1 += y1_change
    dis.fill(black)  # can be used to change background
    pygame.draw.rect(dis, blue, [x1, y1, 10, 10])
    pygame.display.update()
    clock.tick(30)
```

### Hitting boundaries

Snake game is finished when player hits the boundaries. To realize this add this if inside while loop:
```python
if x1 >= display_horizontal_size_x or x1 < 0 or y1 >= display_vertical_size_y or y1 < 0:
    game_over = True
```
At this stage to clean up code structure it was introduced configuration ini file.

### Placing the food

To place the food add this **before** while loop:
```python
food_x = round(random.randrange(0, dis_width - snake_block) / 10.0) * 10.0
food_y = round(random.randrange(0, dis_width - snake_block) / 10.0) * 10.0
```
Also add this import statement at the beginning of code:
```python
import random
```
Drawing food block can be done over:
```python
pygame.draw.rect(dis, conf.red, [food_x, food_y, conf.snake_size, conf.snake_size])
```
Checking if food was caught by snake we can use:
```python
if x1 == food_x and y1 == food_y:
    print("Food eaten!")
```

### Game replay

To allow to replay the game after loosing put entire while loop inside function **game_session()**.
Additionally at the first part of the function add following - nested while loop:
```python
while game_quit is True:
    dis.fill(conf.black)
    message("Game Over - Press q for quit or c for replay", conf.red, font_style,
            conf.display_horizontal_size_x,
            conf.display_vertical_size_y)
    pygame.display.update()
    for event in pygame.event.get():
        print(event)
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_q:
                print('The End...')
                game_over = True
                game_quit = False
            if event.key == pygame.K_c:
                print('New game!')
                game_session()  # recursive call of entire game
```

Now on the top level call game_session()
```python
if __name__ == "__main__":
    game_session()
```

### Adding new parts to snake

Snake body is depicted as a list. To allow that snake can grow up - place inside main while loop:
```python
snake_head = (x1, y1)
snake_list.append(snake_head)
```
After it - remove trailing element - to simulate snake movement
```python
if len(snake_list) > snake_length:
    del snake_list[0]
```
Check that snake have not made collision to himself:
```python
for element in snake_list[:-1]:
    if element == snake_head:
        game_quit = True
```
In the if statement with food eating - add this code:
```python
if x1 == food_x and y1 == food_y:
    food_x = round(random.randrange(0, conf.display_horizontal_size_x - conf.snake_size) / 10.0) * 10.0
    food_y = round(random.randrange(0, conf.display_vertical_size_y - conf.snake_size) / 10.0) * 10.0
    snake_length += 1
    game_speed += 2
```
Redrawing whole snake is done inside function:
```python
def redraw_snake(snake_block, snake_list):
    for item in snake_list:
        pygame.draw.rect(dis, conf.blue, [item[0], item[1], snake_block, snake_block])
```

### Displaying score

To display score add following function;
```python
def show_score(score):
    score_font = pygame.font.SysFont("comicsansms", 20)
    value = score_font.render("Score: " + str(score), True, conf.green)
    dis.blit(value, [0, 0])
```
Place this calls before redrawing snake and at the game over while loop:
```python
show_score(snake_length - 1)
```
