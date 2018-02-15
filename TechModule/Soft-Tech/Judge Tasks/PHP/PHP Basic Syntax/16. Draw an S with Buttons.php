<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
for ($i = 1; $i <=5; $i++){
    ?>
<button style="background-color: blue">1</button>
<?php
}
;
?>
<?php
for ($row = 1; $row<=3; $row++){
    "\n" ?><br>
    <button style="background-color: blue">1</button>
    <?php
    for ($i = 1; $i <=4; $i++){
        ?>
        <button>0</button>
        <?php
}
}
"\n"?><br>
<?php
for ($i = 1; $i <=5; $i++){
    ?>
    <button style="background-color: blue">1</button>
    <?php
}
;
?>
<?php
for ($row = 1; $row<=3; $row++){
    "\n" ?><br>

    <?php
    for ($i = 1; $i <=4; $i++){
        ?>
        <button>0</button>
        <?php
    }
    ?>
<button style="background-color: blue">1</button>
<?php
}
"\n"?><br>
<?php
for ($i = 1; $i <=5; $i++){
    ?>
    <button style="background-color: blue">1</button>
    <?php
}
?>
</body>
</html>