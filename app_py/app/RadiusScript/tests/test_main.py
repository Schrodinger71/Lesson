import unittest
from main import circle_area
from math import pi


class TestCircleArea(unittest.TestCase):
    
    def test_area(self):
        self.assertEqual(circle_area(3),pi*3**2)
        self.assertEqual(circle_area(1),pi)
        self.assertEqual(circle_area(0),0)
        self.assertEqual(circle_area(2.5),pi*2.5**2)
        