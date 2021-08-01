SELECT id
FROM towns
WHERE `name` = 'Sofia';

INSERT INTO towns(`name`)
VALUES(
'SomeTown'
);

SELECT id
FROM villains
WHERE `name` = 'Carl';

INSERT INTO villains(`name`, evilness_factor)
VALUES(
'SomeVillain', 'evil'
);

INSERT INTO minions(`name`, age, town_id)
VALUES(
'Eshhh', 25, 1
);

SELECT id
FROM minions
WHERE `name` = '' AND age = 5;

INSERT INTO minions_villains(minion_id, villain_id)
VALUES(
1, 1
);