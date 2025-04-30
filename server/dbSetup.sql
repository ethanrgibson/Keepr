CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts
ADD cover_img VARCHAR(1000);

SELECT * FROM accounts;

SELECT * FROM accounts WHERE id = '67e1d01f295e7e41d97fdd24';

-- KEEP TABLE

CREATE TABLE keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  views INT UNSIGNED DEFAULT 0,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE
);

SELECT * FROM keeps;

SELECT 
keeps.*,
accounts.*
FROM keeps
INNER JOIN accounts ON accounts.id = keeps.creator_id
WHERE keeps.id = 2;

-- VAULT TABLE

CREATE TABLE vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  is_private BOOLEAN NOT NULL DEFAULT false,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE

)

SELECT * FROM vaults;

DELETE FROM vaults WHERE id = 3 LIMIT 1;

-- VAULTKEEP TABLE

CREATE TABLE vaultkeeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  keep_id INT NOT NULL,
  vault_id INT NOT NULL,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (keep_id) REFERENCES keeps(id) ON DELETE CASCADE,
  FOREIGN KEY (vault_id) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (creator_id) REFERENCES accounts(id) ON DELETE CASCADE

);

SELECT * FROM vaultkeeps;


SELECT
keeps.*, 
accounts.*,
vaultkeeps.id AS vault_keep_id
FROM vaultkeeps
INNER JOIN accounts ON accounts.id = vaultkeeps.creator_id
INNER JOIN keeps ON keeps.id = vaultkeeps.keep_id
WHERE vaultkeeps.vault_id = 17;


SELECT
keeps.*, 
accounts.*
FROM vaultkeeps
INNER JOIN accounts ON accounts.id = vaultkeeps.creator_id
INNER JOIN keeps ON keeps.id = vaultkeeps.keep_id
WHERE keeps.creator_id = '67e1d01f295e7e41d97fdd24';


SELECT
keeps.*,
COUNT(vaultkeeps.id) AS kept_count,
accounts.*
FROM keeps
INNER JOIN accounts ON accounts.id = keeps.creator_id
LEFT OUTER JOIN vaultkeeps ON vaultkeeps.keep_id = keeps.id
WHERE keeps.id = 191
GROUP BY keeps.id;