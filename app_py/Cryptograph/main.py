import os
import sys

from choice import choice
from text import head_text

head_text()

def main() -> None:
    sys.stdout.write("\x1b]2;EncryptionApp\x07") # даём имя окошку консоли.
    choice()
    
if __name__ == "__main__":
    main()
