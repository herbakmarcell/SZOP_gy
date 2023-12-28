<?php
    $host = "localhost";
    $port = 3306;
    $socket = "";
    $user = "root";
    $password = "";
    $dbname = "QAGSVA";

    $connect = new mysqli($host, $user, $password, $dbname, $port, $socket)
        or die ("Kapcsolódás sikertelen: ".mysqli_connect_error());

    if($connect -> connect_errno> 0){
        printf("Kapcsolódási hiba %\n:", mysqli_connect_error);
        exit();
    }
?>