import numpy as np
import sympy as sp

class CalculatorEngine:
    def __init__(self):
        self.symbol_map = {
            'sin': 'sin(', 'cos': 'cos(', 'tan': 'tan(',
            'log': 'log(', '√': 'sqrt(', '^': '**',
            'π': 'pi', 'e': 'E', '!': 'factorial(', '%': '/100', 'exp': 'exp('
        }

    def map_symbol(self, symbol):
        return self.symbol_map.get(symbol, symbol)

    def evaluate(self, expr):
        try:
            expr = expr.replace('π', 'pi').replace('e', 'E')
            expr = expr.replace('√', 'sqrt')
            result = sp.sympify(expr).evalf()
            return result
        except Exception:
            return 'Error'
