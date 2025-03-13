
CREATE TABLE tbl_accounts (
    u_id INT PRIMARY KEY IDENTITY(1,1),
    u_username NVARCHAR(50) NOT NULL,
    u_password NVARCHAR(50) NOT NULL
);


CREATE TABLE tbl_info (
    u_id INT PRIMARY KEY IDENTITY(1,1),
    u_lastname NVARCHAR(50) NOT NULL,
    u_firstname NVARCHAR(50) NOT NULL,
    u_middlename NVARCHAR(50) NULL
);

INSERT INTO tbl_accounts (u_username, u_password) VALUES ('user1', 'password1');
INSERT INTO tbl_accounts (u_username, u_password) VALUES ('user2', 'password2');

INSERT INTO tbl_info (u_lastname, u_firstname, u_middlename) VALUES ('Doe', 'John', 'A');
INSERT INTO tbl_info (u_lastname, u_firstname, u_middlename) VALUES ('Smith', 'Jane', 'B');