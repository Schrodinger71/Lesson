import configparser

# Чтение конфигурации из файла
config = configparser.ConfigParser()
config.read('config.ini')

# Получение значения из секции 'database'
username = config['database']['username']
password = config['database']['password']

# Изменение значения в секции 'general'
config['general']['debug'] = 'True'

debug = config['general']['debug']

# Сохранение изменений в файл
with open('config.ini', 'w') as configfile:
    config.write(configfile)
    
print(f"{username}\n{password}\n{debug}")