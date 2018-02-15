<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num1" />
    M: <input type="text" name="num2" />
    <input type="submit" />
</form>
<ul>
<?php
if(isset($_GET['num1'])){
    $list = intval($_GET['num1']);
    for ($p = 1; $p <= $list; $p++) {
?>

    <li><?php echo "List $p";
        ?>
        <ul>
    <?php
    if(isset($_GET['num2'])){
        $n = intval($_GET['num2']);
        for ($i = 1; $i <= $n; $i++) {
            ?>
            <li>
                <?php
                echo "Element $p.$i";
                ?>
            </li>
            <?php
        } }
    ?>
        </ul>
    </li>
    <?php
    }}
    ?>
</ul>
</body>
</html>