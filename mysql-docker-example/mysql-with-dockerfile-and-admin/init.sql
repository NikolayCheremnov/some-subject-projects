USE users_db;

CREATE TABLE IF NOT EXISTS users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(50) NOT NULL
);

INSERT INTO users (login) VALUES ('user1'), ('user2'), ('user3');