<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if(isset($_GET['num'])){
    $n = intval($_GET['num']);
    $result = 1;
    $prevNum1 = 1;
    $prevNum2 = 0;

    for ($i = 0; $i <$n; $i++){
        if($i ===0){
            echo "1 ";
        }
        else
        {
            if($i === $n - 1)
            {
                $result = $prevNum1 + $prevNum2;
                echo "$result";
            }
            else
            {
                $result = $prevNum1 + $prevNum2;
                echo "$result ";
                $prevNum2 = $prevNum1;
                $prevNum1 = $result;
            }
        }

    }
}
?>
</body>
</html>