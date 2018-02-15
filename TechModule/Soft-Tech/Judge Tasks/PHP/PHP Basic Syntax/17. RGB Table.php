<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        table * {
            border: 1px solid black;
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
<table>
    <tr>
        <td>
            Red
        </td>
        <td>
            Green
        </td>
        <td>
            Blue
        </td>
    </tr>
    <?php
    for ($i = 1; $i <=5; $i++){
        $current = intval($i) * 51;
        ?>
        <tr>
            <?php
            echo "<td style='background-color:rgb($current,0,0);'></td>";
            echo "<td style='background-color:rgb( 0,$current,0);'></td>";
            echo "<td style='background-color:rgb( 0,0,$current);'></td>";
            ?>
        </tr>
    <?php
    }
    ?>
</table>
</body>
</html>