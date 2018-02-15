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
if(isset($_GET['num']))
{
    $n = intval($_GET['num']);

    for ($i = $n; $i >= 2; $i--)
    {
        if($i % 2 > 0 && $i % 3 > 0 && $i % 5 > 0)
        {
            echo "$i ";
        }
    }
    echo "5 3 2";
}
?>
</body>
</html>