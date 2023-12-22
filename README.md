# Game Store Project

## Description
This C# project represents a simple game store application. It includes models for customers, purchases, file management, and games. The application allows customers to browse available games, add them to their shopping cart, and complete purchases. The project is designed to be a starting point for a game store management system.

## Table of Contents
- [Models](#models)
  - [Cliente.cs](#cliente-cs)
  - [CarrinhoDeCompras.cs](#carrinhodecompras-cs)
  - [Compra.cs](#compra-cs)
  - [GerirFicheiros.cs](#gerirficheiros-cs)
  - [Jogo.cs](#jogo-cs)
- [How to Use](#how-to-use)
- [Contributing](#contributing)
- [License](#license)

## Models

### Cliente.cs (Customer)
- Represents a customer in the game store.
- Properties include name, email, password, shopping cart (`CarrinhoDeCompras`), and purchase history (`HistoricoCompras`).
- Methods for editing the profile, deleting the account, adding games to the cart, and more.

### CarrinhoDeCompras.cs (Shopping Cart)
- Represents a customer's shopping cart.
- Contains a list of games (`Jogo`) and the associated customer (`Cliente`).
- Methods for adding games to the cart, calculating the total price, and removing games from the cart.

### Compra.cs (Purchase)
- Represents a purchase made by a customer.
- Contains a list of purchased games (`Jogo`) and the purchase date.
- Method (`RealizarCompra`) for finalizing the purchase, updating game quantities, and saving the purchase in the customer's purchase history.

### GerirFicheiros.cs (File Management)
- A static class for managing reading and writing data to files.
- Methods for loading and saving lists of customers, administrators, and games from/to JSON files.

### Jogo.cs (Game)
- Represents a game available in the store.
- Properties for the game's name, price, platform, genre, and available quantity.
- Method (`Comprar`) for purchasing a specified quantity of the game.

## How to Use
1. Clone the repository: `git clone <repository-url>`
2. Open the project in your preferred C# IDE.
3. Explore and modify the code based on your requirements.

## Contributing
Contributions are welcome! If you'd like to contribute to the project, please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature: `git checkout -b feature-name`.
3. Make your changes and commit them: `git commit -m 'Description of changes'`.
4. Push to the branch: `git push origin feature-name`.
5. Open a pull request.

## License
This project is licensed under the [MIT License](LICENSE).
