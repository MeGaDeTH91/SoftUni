USE minions;
CREATE TABLE minions (
id INT AUTO_INCREMENT, 
NAME VARCHAR(255),
age INT,
PRIMARY KEY(id)
);

CREATE TABLE towns (
town_id INT AUTO_INCREMENT, 
NAME VARCHAR(255),
PRIMARY KEY(town_id)
);