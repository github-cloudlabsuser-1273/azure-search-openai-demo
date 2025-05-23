from PyQt5.QtWidgets import QMainWindow, QWidget, QVBoxLayout, QLineEdit, QPushButton, QGridLayout, QLabel
from PyQt5.QtCore import Qt
from calculator.engine import CalculatorEngine

class FuturisticCalculator(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Futuristic Calculator")
        self.setStyleSheet("background-color: #181f2b; color: #00ffe7;")
        self.setFixedSize(400, 600)
        self.engine = CalculatorEngine()
        self.init_ui()

    def init_ui(self):
        central = QWidget()
        layout = QVBoxLayout()
        self.display = QLineEdit()
        self.display.setReadOnly(True)
        self.display.setAlignment(Qt.AlignRight)
        self.display.setStyleSheet("font-size: 28px; background: #232b3e; border: none; color: #00ffe7; padding: 20px;")
        layout.addWidget(self.display)
        grid = QGridLayout()
        buttons = [
            ['7', '8', '9', '/', 'sin'],
            ['4', '5', '6', '*', 'cos'],
            ['1', '2', '3', '-', 'tan'],
            ['0', '.', '=', '+', 'log'],
            ['(', ')', '√', '^', 'π'],
            ['C', 'e', '!', '%', 'exp']
        ]
        for row, row_vals in enumerate(buttons):
            for col, val in enumerate(row_vals):
                btn = QPushButton(val)
                btn.setStyleSheet("background: #232b3e; color: #00ffe7; font-size: 20px; border-radius: 10px; padding: 15px;")
                btn.clicked.connect(self.on_button_click)
                grid.addWidget(btn, row, col)
        layout.addLayout(grid)
        self.result_label = QLabel("")
        self.result_label.setStyleSheet("font-size: 18px; color: #00ffe7; padding: 10px;")
        layout.addWidget(self.result_label)
        central.setLayout(layout)
        self.setCentralWidget(central)

    def on_button_click(self):
        sender = self.sender()
        text = sender.text()
        if text == 'C':
            self.display.clear()
            self.result_label.clear()
        elif text == '=':
            expr = self.display.text()
            try:
                result = self.engine.evaluate(expr)
                self.result_label.setText(str(result))
            except Exception as e:
                self.result_label.setText("Error")
        elif text in ['sin', 'cos', 'tan', 'log', '√', '^', 'π', 'e', '!', '%', 'exp']:
            self.display.insert(self.engine.map_symbol(text))
        else:
            self.display.insert(text)
