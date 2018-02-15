<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    X: <input type="text" name="num1" />
    Y: <input type="text" name="num2" />
    Z: <input type="text" name="num3" />
    <input type="submit" />
</form>
<?php
if(isset($_GET['num1']) && isset($_GET['num2']) && isset($_GET['num3'])){
    $counter = 0;
    $n = $_GET['num1'];
    $m = $_GET['num2'];
    $p = $_GET['num3'];
    if($n < 0)
    {
        $counter +=1;
    }
    if($m < 0)
    {
        $counter +=1;
    }
    if($p < 0)
    {
        $counter +=1;
    }

    if($counter % 2 == 0 || $p == 0 || $m == 0 || $n == 0){
        echo "Positive";
    }
    else{
        echo "Negative";
    }
}
?>
</body>
</html>