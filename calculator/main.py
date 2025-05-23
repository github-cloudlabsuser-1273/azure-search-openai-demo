import sys
from PyQt5.QtWidgets import QApplication
from ui.futuristic_calculator import FuturisticCalculator

if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = FuturisticCalculator()
    window.show()
    sys.exit(app.exec_())
