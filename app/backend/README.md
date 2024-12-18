# Backend Documentation

## Overview
This document provides an overview of the backend for the Azure Search OpenAI Demo application.

## Prerequisites
- Python 3.8 or higher
- Azure account
- Azure Cognitive Search service
- OpenAI API key

## Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-repo/azure-search-openai-demo.git
    cd azure-search-openai-demo/app/backend
    ```

2. Create a virtual environment and activate it:
    ```sh
    python -m venv venv
    source venv/bin/activate  # On Windows use `venv\Scripts\activate`
    ```

3. Install the required packages:
    ```sh
    pip install -r requirements.txt
    ```

## Configuration

1. Create a `.env` file in the `backend` directory with the following content:
    ```env
    AZURE_SEARCH_SERVICE_NAME=your-search-service-name
    AZURE_SEARCH_API_KEY=your-search-api-key
    OPENAI_API_KEY=your-openai-api-key
    ```

## Running the Application

1. Start the backend server:
    ```sh
    python app.py
    ```

2. The server will start on `http://localhost:5000`.

## API Endpoints

- `GET /search`: Perform a search query.
- `POST /generate`: Generate text using OpenAI.

## License
This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

## Contributing
Contributions are welcome! Please see the [CONTRIBUTING](../CONTRIBUTING.md) file for guidelines.

## Contact
For any questions or issues, please open an issue on the [GitHub repository](https://github.com/your-repo/azure-search-openai-demo).
