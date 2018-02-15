<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
$result = 0;
for ($i = 0; $i <5; $i++){
    $start = intval($i) * 51;
    $result = $start;
    for ($j = 1; $j <= 10; $j++){

        echo "<div style='background-color:rgb($result,$result,$result);'></div>";
        $result += 5;
    }
    ?>
    <br>
<?php "\n";
}
?>
</body>
</html>